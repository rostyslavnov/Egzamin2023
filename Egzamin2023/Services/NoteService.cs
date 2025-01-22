// Novytskyi Rostyslav 15204
using Egzamin2023.Models;

namespace Egzamin2023.Services
{
    public class NoteService
    {
        private readonly List<Note> _notes = new List<Note>();
        private readonly IDateProvider _dateProvider;

        public NoteService(IDateProvider dateProvider)
        {
            _dateProvider = dateProvider;
        }

        public void Add(Note note)
        {
            _notes.Add(note);
        }

        public List<Note> GetAll()
        {
            var currentDate = _dateProvider.CurrentDate;
            return _notes.Where(note => note.Deadline > currentDate).ToList();
        }

        public Note GetById(string title)
        {
            return _notes.FirstOrDefault(note => note.Title == title);
        }
    }
}