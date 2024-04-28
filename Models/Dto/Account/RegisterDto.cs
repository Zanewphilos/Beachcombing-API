namespace Beachcombing_API.Models.Dto.Account
{
    public class RegisterDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }

        public string AvatarUrl { get; set; }

        public string SelfIntro { get; set; }
    }
}
