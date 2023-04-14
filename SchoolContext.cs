using Microsoft.EntityFrameworkCore;

namespace webapi_Francisco_1033769977.Models
{
    // DbContext for the School database
    public class SchoolContext : DbContext
    {
        // DbSets for each entity in the database
        public DbSet<Course> Courses { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        // Constructor that takes options for the DbContext
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options) { }

        // Override method for configuring the model that will be used to build the database schema
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Call base method
            base.OnModelCreating(modelBuilder);

            // Configure the primary key for the Student entity
            modelBuilder.Entity<Student>()
                .HasKey(s => s.IdStudent);

            // Configure the foreign key relationship between Course and Teacher entities
            modelBuilder.Entity<Course>()
                .HasOne<Teacher>()
                .WithMany()
                .HasForeignKey(c => c.IdTeacher);

            // Configure the foreign key relationship between Note and Student entities
            modelBuilder.Entity<Note>()
                .HasOne<Student>()
                .WithMany()
                .HasForeignKey(n => n.IdStudent);

            // Configure the foreign key relationship between Note and Course entities
            modelBuilder.Entity<Note>()
                .HasOne<Course>()
                .WithMany()
                .HasForeignKey(n => n.IdCourse);
        }
    }
}

