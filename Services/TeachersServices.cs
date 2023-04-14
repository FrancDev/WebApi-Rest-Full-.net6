using webapi_Francisco_1033769977.Models;
namespace webapi_Francisco_1033769977.Services
{
    public class TeachersServices : ITeachersServices
    {
        // define a context variable to hold the SchoolContext instance
        SchoolContext context;

        // define a constructor that takes in a SchoolContext instance and sets the context variable
        public TeachersServices(SchoolContext dbcontext)
        {
            context = dbcontext;
        }

        // define a get method that returns all teachers from the context
        public IEnumerable<Teacher> get()
        {
            return context.Teachers;
        }

        // define a Save method that adds a new teacher to the context and saves the changes
        public async Task Save(Teacher teacher)
        {
            context.Add(teacher);
            await context.SaveChangesAsync();
        }

        // define an Update method that updates an existing teacher in the context and saves the changes
        public async Task Update(Guid IdTeacher, Teacher teacher)
        {
            // find the current teacher in the context based on their Id
            var CurrentTeacher = context.Teachers.Find(IdTeacher);

            // if the current teacher exists, update their properties and save the changes
            if (CurrentTeacher != null)
            {
                CurrentTeacher.Name = teacher.Name;
                teacher.LastName = teacher.LastName;
                teacher.Address = teacher.Address;
                teacher.Celphone = teacher.Celphone;
                teacher.EmailAddress = teacher.EmailAddress;
                teacher.Description = teacher.Description;
                teacher.Specialty = teacher.Specialty;

                await context.SaveChangesAsync();
            }

        }

        // define a Delete method that removes a teacher from the context and saves the changes
        public async Task Delete(Guid IdTeacher)
        {
            // find the current teacher in the context based on their Id
            var CurrentTeacher = context.Teachers.Find(IdTeacher);

            // if the current teacher exists, remove them from the context and save the changes
            if (CurrentTeacher != null)
            {
                context.Remove(CurrentTeacher);
                await context.SaveChangesAsync();
            }

        }

    }

    // define an interface for the TeachersServices class
    public interface ITeachersServices
    {
        IEnumerable<Teacher> get();
        Task Save(Teacher teacher);
        Task Update(Guid IdTeacher, Teacher teacher);
        Task Delete(Guid IdTeacher);
    }

}
