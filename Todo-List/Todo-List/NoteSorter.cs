// NoteSorter.cs
// <copyright file="NoteSorter.cs"> This code is protected under the MIT License. </copyright>
using System.Collections.Generic;

namespace Todo_List
{
    /// <summary>
    /// A static class containing a list of notes and categories and methods for sorting them.
    /// </summary>
    public static class NoteSorter
    {
        /// <summary>
        /// Initializes static members of the <see cref="NoteSorter" /> class.
        /// </summary>
        public static NoteSorter()
        {
            Notes = new List<Note>();
            Categories = new List<string>();
        }

        /// <summary>
        /// Gets or sets the list of notes currently stored in the program.
        /// </summary>
        public static List<Note> Notes { get; set; }

        /// <summary>
        /// Gets or sets the list of categories.
        /// </summary>
        public static List<string> Categories { get; set; }
    }
}
