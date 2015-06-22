// Note.cs
// <copyright file="Note.cs"> This code is protected under the MIT License. </copyright>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo_List
{
    /// <summary>
    /// A data reprisentation of a note.
    /// </summary>
    public class Note
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Note" /> class.
        /// </summary>
        public Note()
        {
            this.Title = string.Empty;
            this.Catagories = new List<string>();
            this.Content = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Note" /> class.
        /// </summary>
        /// <param name="title"> The title of the note. </param>
        /// <param name="catagories"> The catagories the not is in. </param>
        /// <param name="content"> The content of the note. </param>
        public Note(string title, List<string> catagories, string content)
        {
            this.Title = title;
            this.Catagories = catagories;
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
        /// Gets or sets the catagories the note is in.
        /// </summary>
        public List<string> Catagories { get; set; }
    }
}
