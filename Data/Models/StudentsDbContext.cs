using Microsoft.EntityFrameworkCore;

namespace Data.Models
{
    internal class StudentsDbContext : DbContext
    {
        public DbSet <Student>Students { get; set; }
        public DbSet<Address> Adresses { get; set; }
        public DbSet<Mark> Marks { get; set; }

        public DbSet<Course> Courses { get; set; }




        public StudentsDbContext()
        {
                Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder Builder)
        {
            Builder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\sandu\Desktop\C#\Proiecte C#\Proiect1\Data\Students.mdf"";Integrated Security=True");
        }
        
           
        
    }
}
