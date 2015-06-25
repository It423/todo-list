// Program.cs
// <copyright file="Program.cs"> This code is protected under the MIT License. </copyright>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo_List
{
    /// <summary>
    /// An application entry point for the console note taking program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The main entry point for the program.
        /// </summary>
        /// <param name="args"> Any arguments the program is run with. </param>
        public static void Main(string[] args)
        {
            Help();
            while (true)
            {
                bool exit = false;

                Console.Write(">>> ");
                string cmd = Console.ReadLine();
                try
                {
                    exit = ParseCommand(cmd);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                
                if (exit)
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Parses a command that was inputted.
        /// </summary>
        /// <param name="cmd"> The command inputted. </param>
        /// <returns> Whether the user entered the quit command. </returns>
        public static bool ParseCommand(string cmd)
        {
            bool exit = false;

            switch (cmd.Split(' ')[0].ToLower())
            {
                case "a":
                    Add(cmd);
                    break;
                case "v":
                    View(cmd);
                    break;
                case "r":
                    Remove(cmd);
                    break;
                case "e":
                    Edit(cmd);
                    break;
                case "c":
                    EditCategory(cmd);
                    break;
                case "h":
                    Help();
                    break;
                case "q":
                    exit = true;
                    break;
                case "add":
                    goto case "a";
                case "view":
                    goto case "v";
                case "remove":
                    goto case "r";
                case "edit":
                    goto case "e";
                case "editc":
                    goto case "c";
                case "help":
                    goto case "h";
                case "quit":
                    goto case "q";
                default:
                    Console.WriteLine("Invalid command! Use h(elp) to get help.");
                    break;
            }

            return exit;
        }

        /// <summary>
        /// Displays help information about the program.
        /// </summary>
        public static void Help()
        {
            Console.WriteLine("Welcome to George Wright's todo list program!");
            Console.WriteLine("To add a note use:\n\ta(dd) \"Note\" Category1;Catergory2...\n");
            Console.WriteLine("To view notes use:\n\tv(iew) Category1;Catergory2...\n");
            Console.WriteLine("To remove a note use:\n\tr(emove) \"Note\"\n");
            Console.WriteLine("To edit a note use:\n\te(dit) \"Note\" \"New Note\"\n");
            Console.WriteLine("To edit a note's categories:\n\t(edit)c \"Note\" Category1;Catergory2...\n");
            Console.WriteLine("Categories are not allways needed in the command. When adding a note or editing it's categories, it will add to the uncategorised list if nothing is entered.");
            Console.WriteLine("When viewing a note it will display all categories.\n");
            Console.WriteLine("To exit the program, you can close it via the cross or enter:\n\tq(uit)\n");
            Console.WriteLine("Everything in brackets is not needed for the command!");
            Console.WriteLine("To display this help again use:\th(elp)");
        } 

        /// <summary>
        /// Adds a note.
        /// </summary>
        /// <param name="cmd"> The command inputted. </param>
        public static void Add(string cmd)
        {
            string name = GetName(cmd);

            if (NoteSorter.NoteIndex(name) != -1)
            {
                // Throw error if name already exists
                throw new Exception("The note already exists!");
            }

            string[] categories = GetCategories(cmd, cmd.IndexOf('"') + name.Length + 3);
            NoteSorter.AddNote(new Note(name, categories));
        }

        /// <summary>
        /// Views notes.
        /// </summary>
        /// <param name="cmd"> The command inputted. </param>
        public static void View(string cmd)
        {
        }

        /// <summary>
        /// Removes a note.
        /// </summary>
        /// <param name="cmd"> The command inputted. </param>
        public static void Remove(string cmd)
        {
            string name = GetName(cmd);

            if (NoteSorter.NoteIndex(name) == -1 || name.Length == 0)
            {
                // Throw error if name doesn't exists
                throw new Exception("No note found under the provided name!");
            }

            NoteSorter.RemoveNote(NoteSorter.Notes[NoteSorter.NoteIndex(name)]);
        }

        /// <summary>
        /// Edits a note.
        /// </summary>
        /// <param name="cmd"> The command inputted. </param>
        public static void Edit(string cmd)
        {
            // Get names inputted
            string[] names = new string[2];
            try
            {
                names[0] = cmd.Split(new char[] { '"' }, StringSplitOptions.RemoveEmptyEntries)[1];
                names[1] = cmd.Split(new char[] { '"' }, StringSplitOptions.RemoveEmptyEntries)[3];
            }
            catch (IndexOutOfRangeException e)
            {
                throw new Exception("The command is incomplete!", e);
            }

            // Get note index
            int noteIndex = NoteSorter.NoteIndex(names[0]);
            if (noteIndex == -1)
            {
                // Throw error if the note doesn't exist
                throw new Exception("No note found under the provided name!");
            }

            // Edit the notes name
            NoteSorter.Notes[noteIndex].Title = names[1];
        }

        /// <summary>
        /// Changes a notes categories.
        /// </summary>
        /// <param name="cmd"> The command inputted. </param>
        public static void EditCategory(string cmd)
        {
            string name = GetName(cmd);

            int noteIndex = NoteSorter.NoteIndex(name);
            if (noteIndex == -1)
            {
                // Throw error if note doesn't exists
                throw new Exception("No note found under the provided name!");
            }

            // Edit the categories of the note
            string[] categories = GetCategories(cmd, cmd.IndexOf('"') + name.Length + 3);
            NoteSorter.Notes[noteIndex].Categories = categories;
        }

        /// <summary>
        /// Gets the name provided from a command.
        /// </summary>
        /// <param name="cmd"> The command inputted. </param>
        /// <returns> The name of the note entered. </returns>
        private static string GetName(string cmd)
        {
            string name;
            try
            {
                name = cmd.Split(new char[] { '"' }, StringSplitOptions.RemoveEmptyEntries)[1];
            }
            catch (IndexOutOfRangeException e)
            {
                throw new Exception("No name provided!", e);
            }

            return name;
        }

        /// <summary>
        /// Gets a list of categories from a command.
        /// </summary>
        /// <param name="cmd"> The command inputted. </param>
        /// <param name="startIndex"> The starting index of the category list. </param>
        /// <returns> The array of categories inputted. </returns>
        private static string[] GetCategories(string cmd, int startIndex)
        {
            // Get the string of categories
            string catString = string.Empty;
            try
            {
                catString = cmd.Substring(startIndex).ToUpper();
            }
            catch (ArgumentOutOfRangeException)
            {
            }

            // Return the categories which are split by a semi-colon
            return catString.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
