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
        public static List<Note> GetNotesByCategory(List<string> categoryNames)
        {
            IEnumerable<Note> notesUnderCategories = Notes;
            foreach (string catergory in categoryNames)
            {
                notesUnderCategories = notesUnderCategories.Where(n => n.Categories.Select(c => c = c.ToUpper()).Contains(catergory.ToUpper()));
            }

            return notesUnderCategories.ToList();
        }

        /// <summary>
        /// Gets all notes under all categories.
        /// </summary>
        /// <returns> A dictionary of category to a list of notes. </returns>
        public static Dictionary<string, List<Note>> GetAllCategories()
        {
            // Get all category names
            List<string> categories = new List<string>();
            foreach (Note n in Notes)
            {
                foreach (string category in n.Categories)
                {
                    if (!categories.Contains(category))
                    {
                        categories.Add(category);
                    }
                }
            }

            // Add uncategorised if there are some uncategorised notes
            if (Notes.Where(n => n.Categories.Count == 0).Count() >= 1)
            {
                categories.Add("UNCATEGORISED");
            }

            // Get each note for each category
            Dictionary<string, List<Note>> categoryDictionary = new Dictionary<string, List<Note>>();
            foreach (string category in categories)
            {
                List<Note> notes = Notes.Where(n => n.Categories.Contains(category)).ToList();

                // Add uncategorised notes
                if (category == "UNCATEGORISED")
                {
                    notes.AddRange(Notes.Where(n => n.Categories.Count == 0));
                }

                categoryDictionary.Add(category, notes);
            }

            return categoryDictionary;
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
