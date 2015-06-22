// Note.cs
// <copyright file="Note.cs"> This code is protected under the MIT License. </copyright>
using System.Collections.Generic;

namespace Todo_List
{
    /// <summary>
    /// A data representation of a note.
    /// </summary>
    public class Note
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Note" /> class.
        /// </summary>
        public Note()
        {
            this.Title = string.Empty;
            this.Categories = new List<string>();
            this.Content = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Note" /> class.
        /// </summary>
        /// <param name="title"> The title of the note. </param>
        /// <param name="categories"> The categories the note is in. </param>
        /// <param name="content"> The content of the note. </param>
        public Note(string title, List<string> categories, string content)
        {
            this.Title = title;
            this.Categories = categories;
            this.Content = content;
        }

        /// <summary>
        /// Gets or sets the title of the note.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the content of the note.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets the categories the note is in.
        /// </summary>
        public List<string> Categories { get; set; }
    }
}
