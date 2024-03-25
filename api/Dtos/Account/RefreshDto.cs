using System.ComponentModel.DataAnnotations;


namespace api.Dtos.Account
{
    public class RefreshDto
    {
        [Required]
        public string AccessToken { get; set; }

        [Required]
        public string RefreshToken { get; set; }
    }
}