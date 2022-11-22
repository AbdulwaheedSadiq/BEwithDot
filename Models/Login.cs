using Users.Models;

namespace auth{
    public class Login{
        public int LoginId { get; set; }
        public string UserName { get; set; }
        public string passwords { get; set; }

        public int status { get; set; }

        public Supplier Supplier { get; set; }

        public int RolesId { get; set; }
        public Roles Roles { get; set; }
    }
}