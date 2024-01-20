using Microsoft.EntityFrameworkCore;

namespace WebDepartment.Models
{
    public class Context :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=LAPTOP-S4ROCGFN\\SQLEXPRESS01;database=corepersonel; integrated security=true;");
        }
        public DbSet<departman> departmens { get; set; }    
        public DbSet<personel> personels { get; set; }  
    }
}
