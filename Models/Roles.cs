using System.Collections.Generic;

namespace auth{
    public class Roles{
        public int RolesId { get; set; }
        public string RoleName { get; set; }

        public List<Login> logins { get; set; }
    }
}