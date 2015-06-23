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
                switch (cmd.Substring(0, 2))
                {
                    case "/a": 
                        // Run add note here 
                        break;
                    case "/v": 
                        // Run view note here 
                        break;
                    case "/r": 
                        // Run remove note here 
                        break;
                    case "/e": 
                        // Run edit note here 
                        break;
                    case "/q":
                        exit = true;
                        break;
                    default: 
                        Console.WriteLine("Invalid command!");
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
            Console.WriteLine("To edit a note use:\n\t/e [Name] [New name] [New Category1, New Catergory2...]\n");
            Console.WriteLine("Categories are not allways needed in the command. When adding/editing a note, it will add to the uncategorised list.");
            Console.WriteLine("When viewing a note it will display all categories.\n");
            Console.WriteLine("To exit the program, you can close it via the cross or enter:\n\t/q\n");
            Console.WriteLine("To display this help again use:\n\t/h\n\n");        
        } 
    }
}
