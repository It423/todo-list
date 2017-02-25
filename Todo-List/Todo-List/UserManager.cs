// UserManager.cs
// <copyright file="UserManager.cs"> This code is protected under the MIT License. </copyright>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Todo_List
{
    /// <summary>
    /// A static class containing a list of users and their data in the program.
    /// </summary>
    public static class UserManager
    {
        /// <summary>
        /// Initializes static members of the <see cref="UserManager" /> class.
        /// </summary>
        static UserManager()
        {
            Users = new List<User>();
            LoginIndex = -1; // No logged in user
        }

        /// <summary>
        /// Gets or sets the list of users.
        /// </summary>
        public static List<User> Users { get; set; }

        /// <summary>
        /// The index of the user currently logged in.
        /// </summary>
        /// <remarks> Value of -1 means no logged in user. </remarks>
        public static int LoginIndex { get; set; }

        /// <summary>
        /// Attempts a login.
        /// </summary>
        /// <param name="name"> The username to login with. </param>
        /// <param name="password"> The password to login with. </param>
        /// <returns> True if the login was successful. </returns>
        public static bool TryLogin(string name, string password)
        {
            for (int i = 0; i < Users.Count; i++)
            {
                if (Users[i].Name == name && Users[i].Password == password)
                {
                    LoginIndex = i;
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Adds a new user to the user list and logs them in.
        /// </summary>
        /// <param name="name"> The username of the new user. </param>
        /// <param name="password"> The password of the new user. </param>
        public static void CreateUser(string name, string password)
        {
            User u = new User();
            u.Name = name;
            u.Password = password;
            Users.Add(u);
            LoginIndex = Users.Count - 1;
        }

        /// <summary>
        /// Tries to delete a user.
        /// </summary>
        /// <param name="name"> The name of the user. </param>
        /// <param name="password"> The password of the user. </param>
        /// <returns> True if the deletion was successful. </returns>
        public static bool TryDeleteUser(string name, string password)
        {
            for (int i = 0; i < Users.Count; i++)
            {
                if (Users[i].Name == name && Users[i].Password == password)
                {
                    if (LoginIndex == i)
                    {
                        LoginIndex = -1;
                    }

                    Users.RemoveAt(i);

                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Tries to change the password of a user.
        /// </summary>
        /// <param name="name"> The name of the user. </param>
        /// <param name="password"> The password of the user. </param>
        /// <param name="newPassword"> The new password of the user. </param>
        /// <returns> True if the password change was successful. </returns>
        public static bool TryChangePassword(string name, string password, string newPassword)
        {
            for (int i = 0; i < Users.Count; i++)
            {
                if (Users[i].Name == name && Users[i].Password == password)
                {
                    Users[i].Password = newPassword;

                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Gets a list of the users currently registered in the system.
        /// </summary>
        /// <returns> The list of usernames. </returns>
        public static List<string> GetUsers()
        {
            List<string> ret = new List<string>();

            foreach (User u in Users)
            {
                ret.Add(u.Name);
            }

            return ret;
        }
    }
}
