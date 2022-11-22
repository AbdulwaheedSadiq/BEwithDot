using Boats.Data;
using Microsoft.AspNetCore.Mvc;

namespace auth{
    [ApiController]
    [Route("Api/Login")]
    public class LoginController : ControllerBase{
        private readonly ApplicationDbContext dbContextRepo;
        
        public LoginController(ApplicationDbContext dbContext){
            dbContextRepo = dbContext;
        }


        // public Actionresult<Login> MyProperty { get; set; }
    }
}