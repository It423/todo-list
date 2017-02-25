// Note.cs
// <copyright file="Note.cs"> This code is protected under the MIT License. </copyright>
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
            Title = string.Empty;
            Categories = new string[0];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Note" /> class.
        /// </summary>
        /// <param name="title"> The title of the note. </param>
        /// <param name="categories"> The categories the note is in. </param>
        public Note(string title, string[] categories)
        {
            Title = title;
            Categories = categories;
        }

        /// <summary>
        /// Gets or sets the title of the note.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the categories the note is in.
        /// </summary>
        public string[] Categories { get; set; }
    }
}
