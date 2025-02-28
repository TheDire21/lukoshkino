using lukoshkino.Models;

namespace lukoshkino.ViewModels
{
    public class VM_Authorization
    {
        public string Login { get; set; } = "";

        public string Password { get; set; } = "";

        public bool Authorize(out ApplicationUser user)
        {
            if (string.IsNullOrEmpty(Login) || string.IsNullOrEmpty(Password))
            {
                user = null;
                return false;
            }

            using (var db = new ApplicationContext())
            {
                var t_user = db.Users.FirstOrDefault(x => x.Email == Login && x.Password == Password);
                if (t_user is not null)
                {
                    user = t_user;
                    return true;
                }
                    
            }
            user = null;
            return false;
        }
    }
}
