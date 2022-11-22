using auth;
using BoatPayments.Models;
using boats.Models;
using fboats.Models;
using fishers.Models;
using loans;
using Microsoft.EntityFrameworkCore;
using Users.Models;

namespace Boats.Data{

    public class ApplicationDbContext : DbContext{

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {

        }

        public DbSet<BoatStock> boatStock { get; set; }
        public DbSet<Fishboats> fishBoats { get; set; }
        public DbSet<FisherMansGroup> fisherMansgroup { get; set; }
        public DbSet<GroupMembers> fisherMansGroupMembers { get; set; }
        public DbSet<LoanBoat> loanBoats { get; set; }
        public DbSet<Login> logins { get; set; }
         public DbSet<Payment> payments { get; set; }
          public DbSet<Roles> roles { get; set; }
           public DbSet<Supplier> suppliers { get; set; }





    }
}