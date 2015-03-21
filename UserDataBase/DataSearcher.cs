using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace UserDataBase
{
    class DataSearcher
    {
        private static string path 
        {
            get 
            {
                return "Data.txt";
            }
        }
        public static bool ReadDataBase(string User, string Password)
        {
            bool Valid = false;
            string line;
            using (StreamReader Data = new StreamReader(path))
            {

                line = Data.ReadLine();
                while (line != null)
                {
                    if (line.StartsWith(User))
                    {
                        string[] x = line.Split('|');
                        if (x[1] == Password)
                        {
                            Valid = true;
                        }
                    }
                    line = Data.ReadLine();
                }
            }

            return Valid;
        }

        public static bool CheckValid(string user, string password)
        {
            bool Valid = true;
            string line;
            using (StreamReader Data = new StreamReader(path))
            {
                line = Data.ReadLine();
                while (line != null)
                {
                    if (line.StartsWith(user))
                    {
                        Valid = false;
                    }
                    line = Data.ReadLine();
                }
            }
            return Valid;
        }

        public static void CreateNewUser(string user, string password)
        {
            using (StreamWriter write = new StreamWriter(path, true))
            {
                write.WriteLine();
                
                write.WriteLine(user + "|" + password + "|");
            }
        }
    }
}
