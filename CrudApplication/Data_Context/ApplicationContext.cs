using CrudApplication.Models;
using CrudApplication.Models.Cascade;
using Microsoft.EntityFrameworkCore;

namespace CrudApplication.Data_Context
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<EmpModel> EmpModels { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Country> Countrys { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cityes { get; set; }
    }
}
