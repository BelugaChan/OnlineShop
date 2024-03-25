using api.Dtos.Account;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/Account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private ITokenService tokenService;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, ITokenService tokenService)
        {
            this.userManager = userManager;
            this.tokenService = tokenService;
            this.signInManager = signInManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var user = await userManager.Users.FirstOrDefaultAsync(t => t.UserName == loginDto.UserName);
                if (user is null)
                    return Unauthorized("Invalid userName");
                
                var result = await signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
                if(!result.Succeeded)
                    return Unauthorized("username not found and/or password is incorrect");

                var refreshToken = tokenService.GenerateRefreshToken();
                user.RefreshToken = refreshToken;
                user.RefreshTokenExpiry = DateTime.Now.AddDays(7);

                await userManager.UpdateAsync(user);

                return Ok(
                    new NewUserDto
                    {
                        UserName = user.UserName,
                        Email = user.Email,
                        Token = tokenService.CreateToken(user),
                        RefreshToken = user.RefreshToken
                    }
                );
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }           
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] RefreshDto refreshDto)
        {
            var principal = tokenService.GetPrincipalFromExpiredToken(refreshDto.AccessToken);       

            if(principal?.Identity?.Name is null)
                return Unauthorized();

            var user = await userManager.FindByNameAsync(principal.Identity.Name);

            if(user is null || user.RefreshToken != refreshDto.RefreshToken 
            || user.RefreshTokenExpiry < DateTime.Now)
                return Unauthorized();

            var refreshToken = tokenService.GenerateRefreshToken();
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiry = DateTime.Now.AddDays(7);

            await userManager.UpdateAsync(user);
            
            return Ok(
                    new NewUserDto
                    {
                        UserName = user.UserName,
                        Email = user.Email,
                        Token = tokenService.CreateToken(user),
                        RefreshToken = refreshToken
                    }
                );
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                
                var user = new User
                {
                    UserName = registerDto.UserName,
                    Email = registerDto.Email
                };       

                var createdUser = await userManager.CreateAsync(user, registerDto.Password);

                if (createdUser.Succeeded)
                {
                    var roleResult = await userManager.AddToRoleAsync(user, "User");
                    if (roleResult.Succeeded)
                    {                       
                        return Ok(
                            new NewUserDto{
                                UserName = user.UserName,
                                Email = user.Email,
                                Token = tokenService.CreateToken(user)
                            }
                        );
                    }
                    else
                    {
                        return BadRequest(roleResult.Errors);
                    }
                }
                else
                {
                    return BadRequest(createdUser.Errors);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);          
            }
        }
    }
}