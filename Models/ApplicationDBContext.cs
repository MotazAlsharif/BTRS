
using Microsoft.EntityFrameworkCore;
using System.Configuration;
    
namespace BRTS.Web.Models
{
    public class ApplicationDBContext : DbContext
    {   
        private readonly IConfiguration _configuration;
        public ApplicationDBContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public ApplicationDBContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=ASP_PROJ;Integrated Security=True;Trust Server Certificate=True");
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<BookedRequests> BookedRequests { get; set; }
        public DbSet<Bus> Buses { get; set; }
        public DbSet<Image> Images{ get; set; }
        public DbSet<Trip> Trips{ get; set; }






    }
} 
 