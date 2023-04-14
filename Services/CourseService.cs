using webapi_Francisco_1033769977.Models;

namespace webapi_Francisco_1033769977.Services
{
    // CourseService implements ICourseService interface
    public class CourseService : ICourseService
    {

        SchoolContext context;

        // Constructor receives a SchoolContext object as a parameter
        public CourseService(SchoolContext dbcontext)
        {
            context = dbcontext;
        }

        // Returns all courses from the database
        public IEnumerable<Course> get()
        {
            return context.Courses;
        }

        // Adds a new course to the database
        public async Task Save(Course course)
        {
            context.Add(course);
            await context.SaveChangesAsync();
        }

        // Updates an existing course in the database
        public async Task Update(Guid IdCourse, Course course)
        {
            // Find the course in the database by its ID
            var CurrentCourse = context.Courses.Find(IdCourse);

            if (CurrentCourse != null)
            {
                // Update the course's properties with the values from the parameter object
                CurrentCourse.Name = course.Name;
                course.Description = course.Description;

                // Save the changes to the database
                await context.SaveChangesAsync();
            }

        }

        // Deletes a course from the database
        public async Task Delete(Guid IdCourse)
        {
            // Find the course in the database by its ID
            var CurrentCourse = context.Courses.Find(IdCourse);

            if (CurrentCourse != null)
            {
                // Remove the course from the database
                context.Remove(CurrentCourse);
                await context.SaveChangesAsync();
            }

        }

    }

    // ICourseService defines the methods that CourseService must implement
    public interface ICourseService
    {
        IEnumerable<Course> get();
        Task Save(Course course);
        Task Update(Guid IdCourse, Course course);
        Task Delete(Guid IdCourse);

    }
}
