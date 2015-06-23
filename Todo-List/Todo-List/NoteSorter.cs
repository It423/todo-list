// NoteSorter.cs
// <copyright file="NoteSorter.cs"> This code is protected under the MIT License. </copyright>
using System.Collections.Generic;
using System.Linq;

namespace Todo_List
{
    /// <summary>
    /// A static class containing a list of notes and methods for sorting them.
    /// </summary>
    public static class NoteSorter
    {
        /// <summary>
        /// Initializes static members of the <see cref="NoteSorter" /> class.
        /// </summary>
        public static NoteSorter()
        {
            Notes = new List<Note>();
        }

        /// <summary>
        /// Gets or sets the list of notes currently stored in the program.
        /// </summary>
        public static List<Note> Notes { get; set; }

        /// <summary>
        /// Gets all the notes with certain category tags.
        /// </summary>
        /// <param name="categoryNames"> The list of categories. </param>
        /// <returns> The list of notes under the category. </returns>
        /// <remarks> No category names in the list means all categories. </remarks>
        public static List<Note> GetNotesByCatagory(List<string> categoryNames)
        {
            IEnumerable<Note> notesUnderCategories = Notes;
            foreach (string catergory in categoryNames)
            {
                notesUnderCategories = notesUnderCategories.Where(n => n.Categories.Select(c => c = c.ToUpper()).Contains(catergory.ToUpper()));
            }

            return notesUnderCategories.ToList();
        }

        /// <summary>
        /// Adds a note to the collection of notes.
        /// </summary>
        /// <param name="note"> The note to add. </param>
        public static void AddNote(Note note)
        {
            Notes.Add(note);
        }

        /// <summary>
        /// Removes a note from the collection of notes.
        /// </summary>
        /// <param name="note"> The note to remove. </param>
        public static void RemoveNote(Note note)
        {
            Notes.Remove(note);
        }

        /// <summary>
        /// Edits a note.
        /// </summary>
        /// <param name="oldNote"> The old note to edit. </param>
        /// <param name="newNote"> The new note to replace the old. </param>
        public static void EditNote(Note oldNote, Note newNote)
        {
            int i = Notes.IndexOf(oldNote);
            Notes[i] = newNote;
        }

        /// <summary>
        /// Finds the index of a note by the title.
        /// </summary>
        /// <param name="title"> The title of the note. </param>
        /// <returns> The index of the note in the list. </returns>
        public static int NoteIndex(string title)
        {
            // Get the note by the title
            Note note = Notes.Where(n => n.Title == title).ToArray()[0];
            return Notes.IndexOf(note);
        }
    }
}
