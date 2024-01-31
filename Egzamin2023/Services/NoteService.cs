using Egzamin2023.Models;

namespace Egzamin2023.Services;

public class NoteService
{
    private List<Note> _notes = new ();
    private IDateProvider _dateProvider;

    public NoteService(IDateProvider dateProvider)
    {
        _dateProvider = dateProvider;
    }

    public void Add(Note note)
    {
        if (_notes.Find(n => n.Title == note.Title) is null)
        {
            _notes.Add(note);   
        }
        else
        {
            throw new ArgumentException("Title is not unique!");
        }
    }

    public List<Note> GetAll()
    {
        return _notes.Where(n => n.Deadline > _dateProvider.CurrentDate).ToList();
    }

    public Note? GetById(string title)
    {
        return _notes.Find(n => n.Title == title);
    }
}