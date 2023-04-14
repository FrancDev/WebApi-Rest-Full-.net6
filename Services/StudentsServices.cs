using webapi_Francisco_1033769977.Models;

namespace webapi_Francisco_1033769977.Services
{
    public class StudentsServices : IStudentsService
    {
        SchoolContext context;

        // Constructor that injects the database context
        public StudentsServices(SchoolContext dbcontext)
        {
            context = dbcontext;
        }

        // Method that returns all students
        public IEnumerable<Student> get()
        {
            return context.Students;
        }

        // Method that saves a new student
        public async Task Save(Student student)
        {
            context.Add(student);
            await context.SaveChangesAsync();
        }

        // Method that updates a student by IdStudent
        public async Task Update(Guid IdStudent, Student student)
        {
            var CurrentStudent = context.Students.Find(IdStudent);

            if (CurrentStudent != null)
            {
                // Update the properties of the current student with the new values
                CurrentStudent.Name = student.Name;
                student.LastName = student.LastName;
                student.Address = student.Address;
                student.Celphone = student.Celphone;
                student.EmailAddress = student.EmailAddress;
                student.Description = student.Description;

                await context.SaveChangesAsync();
            }

        }

        // Method that deletes a student by IdStudent
        public async Task Delete(Guid IdStudent)
        {
            var CurrentStudent = context.Students.Find(IdStudent);

            if (CurrentStudent != null)
            {
                context.Remove(CurrentStudent);
                await context.SaveChangesAsync();
            }

        }


    }

    // Interface that defines the contract for the Student Service
    public interface IStudentsService
    {
        IEnumerable<Student> get();
        Task Save(Student student);
        Task Update(Guid IdStudent, Student student);
        Task Delete(Guid IdStudent);
    }


}
