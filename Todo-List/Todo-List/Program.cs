// Program.cs
// <copyright file="Program.cs"> This code is protected under the MIT License. </copyright>
using System;
using System.Collections.Generic;

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
            // Add shutdown hook to save the data on exit
            AppDomain.CurrentDomain.ProcessExit += (s, e) => XMLDataSaver.SaveXMLFile();

            // Open the file and read the saved data
            XMLDataSaver.ReadXMLFile();

            // Auto login user if there is only the one user saved
            if (UserManager.Users.Count == 1)
            {
                UserManager.LoginIndex = 0;
            }

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
                    Environment.Exit(0);
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
                case "l":
                    Login(cmd); 
                    break;                
                case "u":
                    AddUser(cmd); 
                    break;
                case "d":
                    DeleteUser(cmd); 
                    break;
                case "p":
                    ChangePassword(cmd); 
                    break;                
                case "s":
                    ShowUsers();
                    break;
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
                case "login":
                    goto case "l";
                case "useradd":
                    goto case "u";
                case "deleteuser":
                    goto case "d";
                case "passwordchange":
                    goto case "p";
                case "showusers":
                    goto case "s";
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
            Console.WriteLine("To login use:\n\tl(ogin) username password\n");
            Console.WriteLine("To add an user use:\n\tu(seraddd) username password\n");
            Console.WriteLine("To delete an user use:\n\td(eleteuser) username password\n");
            Console.WriteLine("To change a passwor use:\n\tp(asswordchange) username password newpassword\n");
            Console.WriteLine("To list users avalibile use:\n\ts(howusers)\n");
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
        /// Logs in a user.
        /// </summary>
        /// <param name="cmd"> The command inputted. </param>
        public static void Login(string cmd)
        {
            string username = cmd.Split(' ')[1];
            string password = cmd.Split(' ')[2];
        }

        /// <summary>
        /// Adds a user to the system.
        /// </summary>
        /// <param name="cmd"> The command inputted. </param>
        public static void AddUser(string cmd)
        {
            string username = cmd.Split(' ')[1];
            string password = cmd.Split(' ')[2];

            UserManager.CreateUser(username, password);
            Console.WriteLine("New user created\n\tusername: {0}\n\tpassword: {1}", username, password);
        }

        /// <summary>
        /// Removes a user from the system.
        /// </summary>
        /// <param name="cmd"> The command inputted. </param>
        public static void DeleteUser(string cmd)
        {
            string username = cmd.Split(' ')[1];
            string password = cmd.Split(' ')[2];

            if (UserManager.TryDeleteUser(username, password))
            {
                Console.WriteLine("User removed");
            }
            else
            {
                Console.WriteLine("Invalid username or password. Cannot delete user");
            }
        }

        /// <summary>
        /// Changes the password of a user.
        /// </summary>
        /// <param name="cmd"> The command inputted. </param>
        public static void ChangePassword(string cmd)
        {
            string username = cmd.Split(' ')[1];
            string password = cmd.Split(' ')[2];
            string newPassword = cmd.Split(' ')[3];

            if (UserManager.TryChangePassword(username, password, newPassword))
            {
                Console.WriteLine("User password change\n\tusername: {0}\n\tpassword: {1}", username, password);
            }
            else
            {
                Console.WriteLine("Invalid username or password. Cannot change password");
            }
        }

        /// <summary>
        /// Lists users recorded on system.
        /// </summary>
        public static void ShowUsers()
        {
            List<string> users = UserManager.GetUsers();

            for (int i = 0; i < users.Count; i++)
            {
                Console.Write(users[i]);
                Console.WriteLine(i == UserManager.LoginIndex ? " - LOGGED IN" : string.Empty);
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Adds a note.
        /// </summary>
        /// <param name="cmd"> The command inputted. </param>
        public static void Add(string cmd)
        {
            if (!CheckLoggedIn())
            {
                return;
            }

            string name = GetName(cmd);

            if (UserManager.Users[UserManager.LoginIndex].NoteIndex(name) != -1)
            {
                // Throw error if name already exists
                throw new Exception("The note already exists!");
            }

            string[] categories = GetCategories(cmd, cmd.IndexOf('"') + name.Length + 3);
            UserManager.Users[UserManager.LoginIndex].AddNote(new Note(name, categories));
        }

        /// <summary>
        /// Views notes.
        /// </summary>
        /// <param name="cmd"> The command inputted. </param>
        public static void View(string cmd)
        {
            if (!CheckLoggedIn())
            {
                return;
            }

            UserManager.Users[UserManager.LoginIndex].CheckCategorys();
            string[] categories = cmd.IndexOf(' ') != -1 ? GetCategories(cmd, cmd.IndexOf(' ') + 1) : new string[0];

            // Create a dictionary of the category and its notes
            Dictionary<string, List<Note>> data = new Dictionary<string, List<Note>>();
            if (categories.Length > 0)
            {
                List<Note> notesInCats = UserManager.Users[UserManager.LoginIndex].GetNotesByCategory(categories);
                string cats = categories.Length == 1 ? categories[0] : InstertAnd(categories);
                data.Add(cats, notesInCats);
            }
            else
            {
                data = UserManager.Users[UserManager.LoginIndex].GetAllCategories();
            }

            // Display the information
            Console.WriteLine();

            foreach (KeyValuePair<string, List<Note>> category in data)
            {
                Console.WriteLine(category.Key);
                foreach (Note n in category.Value)
                {
                    Console.WriteLine("- {0}", n.Title);
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        /// Removes a note.
        /// </summary>
        /// <param name="cmd"> The command inputted. </param>
        public static void Remove(string cmd)
        {
            if (!CheckLoggedIn())
            {
                return;
            }

            string name = GetName(cmd);

            if (UserManager.Users[UserManager.LoginIndex].NoteIndex(name) == -1 || name.Length == 0)
            {
                // Throw error if name doesn't exists
                throw new Exception("No note found under the provided name!");
            }

            UserManager.Users[UserManager.LoginIndex].RemoveNote(UserManager.Users[UserManager.LoginIndex].Notes[UserManager.Users[UserManager.LoginIndex].NoteIndex(name)]);
        }

        /// <summary>
        /// Edits a note.
        /// </summary>
        /// <param name="cmd"> The command inputted. </param>
        public static void Edit(string cmd)
        {
            if (!CheckLoggedIn())
            {
                return;
            }

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
            int noteIndex = UserManager.Users[UserManager.LoginIndex].NoteIndex(names[0]);
            if (noteIndex == -1)
            {
                // Throw error if the note doesn't exist
                throw new Exception("No note found under the provided name!");
            }

            // Edit the notes name
            UserManager.Users[UserManager.LoginIndex].Notes[noteIndex].Title = names[1];
        }

        /// <summary>
        /// Changes a notes categories.
        /// </summary>
        /// <param name="cmd"> The command inputted. </param>
        public static void EditCategory(string cmd)
        {
            if (!CheckLoggedIn())
            {
                return;
            }

            string name = GetName(cmd);

            int noteIndex = UserManager.Users[UserManager.LoginIndex].NoteIndex(name);
            if (noteIndex == -1)
            {
                // Throw error if note doesn't exists
                throw new Exception("No note found under the provided name!");
            }

            // Edit the categories of the note
            string[] categories = GetCategories(cmd, cmd.IndexOf('"') + name.Length + 3);
            UserManager.Users[UserManager.LoginIndex].Notes[noteIndex].Categories = categories;
        }

        /// <summary>
        /// Checks if a user is currently logged into the program.
        /// </summary>
        /// <returns> True if there is a logged in user. </returns>
        private static bool CheckLoggedIn()
        {
            try
            {
                User u = UserManager.Users[UserManager.LoginIndex];
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Currently not logged into a user!");
                return false;
            }
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

        /// <summary>
        /// Joins an array of categories into one string and inserts an and at the end.
        /// </summary>
        /// <param name="categories"> The list of categories to concatenate. </param>
        /// <returns> The concatenated string with an and at the end. </returns>
        private static string InstertAnd(string[] categories)
        {
            string catString = string.Empty;

            // Add elemenets to string with a comma to seperate them
            for (int i = 0; i < categories.Length - 1; i++)
            {
                catString += string.Format("{0}, ", categories[i]);
            }

            // Insert last element with an and
            catString += string.Format("and {0}", categories[categories.Length - 1]);

            return catString;
        }
    }
}
