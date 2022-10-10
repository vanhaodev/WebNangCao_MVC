using System.ComponentModel.DataAnnotations;
public enum UserRole
{
    None = 0, Mod, Admin
}
namespace WebNangCao_MVC.Models.Auth
{
    
    public class UserLogin
    {
        public UserLogin()
        {

        }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9]+$")]
        public string userName { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9]+$")]
        public string password { get; set; }
        public UserRole role { get; set; } = UserRole.None;

        public UserLogin(string userName, string password, UserRole role)
        {
            this.userName = userName;
            this.password = password;
            this.role = role;
        }
    }
}
