// XMLDataSaver.cs
// <copyright file="XMLDataSaver.cs"> This code is protected under the MIT License. </copyright>
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Todo_List
{
    /// <summary>
    /// A static class for reading and writing to XML files.
    /// </summary>
    public static class XMLDataSaver
    {
        /// <summary>
        /// Reads the xml file of information from the save location.
        /// </summary>
        public static void ReadXMLFile()
        {
            try
            {
                using (TextReader tr = new StreamReader("TodoListData.xml"))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(List<Note>));
                    NoteSorter.Notes = (List<Note>)xs.Deserialize(tr);
                }
            }
            catch (FileNotFoundException)
            {
                // File not found so don't read anything	
            }
        }

        /// <summary>
        /// Saves the xml file of information to the save location.
        /// </summary>
        public static void SaveXMLFile()
        {
            using (TextWriter tw = new StreamWriter("TodoListData.xml"))
            {
                XmlSerializer xs = new XmlSerializer(typeof(List<Note>));
                xs.Serialize(tw, NoteSorter.Notes);
            }
        }
    }
}
