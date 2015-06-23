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
    /// An application entry point for a console-based hand of Whist.
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
                switch (cmd.Split(new char[] { ' ' })[0])
                {
                    case "/a":
                        Add(cmd); 
                        break;
                    case "/v":
                        View(cmd);
                        break;
                    case "/r":
                        Remove(cmd);
                        break;
                    case "/e":
                        Edit(cmd);
                        break;
                    case "/c":
                        EditCategory(cmd);
                        break;
                    case "/q":
                        exit = true;
                        break;
                    default: 
                        Console.WriteLine("Invalid command! Use /h to get help.");
                        break;
                }
                
                if (exit)
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Displays help information about the program.
        /// </summary>
        public static void Help()
        {
            Console.WriteLine("Welcome to George Wright's todo list program!");
            Console.WriteLine("To add a note use:\n\t/a [Name] [Category1, Catergory2...]\n");
            Console.WriteLine("To view notes use:\n\t/v [Category1, Catergory2...]\n");
            Console.WriteLine("To remove a note use:\n\t/r [Name]\n");
            Console.WriteLine("To edit a note use:\n\t/e [Name] [New name]\n");
            Console.WriteLine("To edit a note's categories:\n\t/c [Name] [Category1, Catergory2...]\n");
            Console.WriteLine("Categories are not allways needed in the command. When addinga note or editing its categories, it will add to the uncategorised list.");
            Console.WriteLine("When viewing a note it will display all categories.\n");
            Console.WriteLine("To exit the program, you can close it via the cross or enter:\n\t/q\n");
            Console.WriteLine("To display this help again use:\n\t/h\n\n");        
        } 

        /// <summary>
        /// Adds a note.
        /// </summary>
        /// <param name="cmd"> The command inputted. </param>
        public static void Add(string cmd)
        {
            // Get note name
            string name;
            try
            {
                string cmdInfo = cmd.Substring(3);
                name = cmdInfo.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[0];
            }
            catch (ArgumentOutOfRangeException)
            {
                name = string.Empty;
            }

            // Throw error if name already exists or no name was provided
            if (NoteSorter.NoteIndex(name) != -1 || name.Length == 0)
            {
                Console.WriteLine("Error! No name was provided, or the note already exists!");
            }
            else
            {
                // Get the string of categories
                string catString = cmd.Substring(3 + name.Length);

                // Construct the list of categories
                List<string> categories = catString.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).ToList();

                // Create and add the note
                NoteSorter.AddNote(new Note(name, categories));
            }
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

        }

        /// <summary>
        /// Edits a note.
        /// </summary>
        /// <param name="cmd"> The command inputted. </param>
        public static void Edit(string cmd)
        {

        }

        /// <summary>
        /// Changes a notes categories.
        /// </summary>
        /// <param name="cmd"> The command inputted. </param>
        public static void EditCategory(string cmd)
        {

        }
    }
}
