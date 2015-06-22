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
                notesUnderCategories = notesUnderCategories.Where(n => n.Categories.Contains(catergory.ToUpper()));
            }

            return notesUnderCategories.ToList();
        }
    }
}
