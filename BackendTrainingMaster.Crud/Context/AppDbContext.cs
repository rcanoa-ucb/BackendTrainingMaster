using BackendTrainingMaster.Crud.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendTrainingMaster.Crud.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {

        }

        public DbSet<Person> Persons { get; set; }
    }
}