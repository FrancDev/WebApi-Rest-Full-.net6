using webapi_Francisco_1033769977.Models;

namespace webapi_Francisco_1033769977.Services
{
    public class NotesService : INotesService
    {
        SchoolContext context;

        public NotesService(SchoolContext dbcontext)
        {
            context = dbcontext;
        }

        // Get all notes
        public IEnumerable<Note> get()
        {
            return context.Notes;
        }

        // Save a new note
        public async Task Save(Note note)
        {
            context.Add(note);
            await context.SaveChangesAsync();
        }

        // Update an existing note
        public async Task Update(Guid IdNote, Note note)
        {
            var CurrentNote = context.Notes.Find(IdNote);

            if (CurrentNote != null)
            {
                // Update note properties
                CurrentNote.note = note.note;
                note.Description = note.Description;

                await context.SaveChangesAsync();
            }

        }

        // Delete an existing note
        public async Task Delete(Guid IdNote)
        {
            var CurrentNote = context.Notes.Find(IdNote);

            if (CurrentNote != null)
            {
                context.Remove(CurrentNote);
                await context.SaveChangesAsync();
            }

        }
    }

    // Interface for NotesService
    public interface INotesService
    {
        IEnumerable<Note> get();
        Task Save(Note note);
        Task Update(Guid IdNote, Note note);
        Task Delete(Guid IdNote);
    }
}
