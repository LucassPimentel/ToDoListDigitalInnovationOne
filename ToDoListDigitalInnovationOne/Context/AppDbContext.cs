using Microsoft.EntityFrameworkCore;
using ToDoListDigitalInnovationOne.Models;

namespace ToDoListDigitalInnovationOne.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts)
        {

        }

        public DbSet<ToDoList> ToDoList { get; set; }
    }
}
