using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UserDataBase
{
    class Program
    {
        static void Main(string[] args)
        {
            bool LogIn = false, menu = true;

            string choice = "0", UserName, UserPassword, expression;

            Console.WriteLine("Please Enter User Name");
            UserName = Console.ReadLine();
            Console.WriteLine("Please Enter Password");
            UserPassword = Console.ReadLine();
            LogIn = DataSearcher.ReadDataBase(UserName, UserPassword);

            if (LogIn == true)
            {
                while (menu == true)
                {
                    Console.Clear();
                    Console.WriteLine("Welcome " + UserName + " How Can I Help You?");
                    Console.WriteLine("Create: Create A New User");
                    Console.WriteLine("Check: Check Number Of Users On This Network");
                    Console.WriteLine("Edit: Acces My Profile");
                    Console.WriteLine("EXIT");
                    choice = Console.ReadLine();
                    choice.ToLower();
                    switch (choice)
                    {
                        case "create":
                            Console.WriteLine("Are you sure You Want To Create A New User? yes/no");
                            expression = Console.ReadLine();
                            expression.ToLower();
                            if (expression == "yes")
                            {
                                string user, password;
                                Console.WriteLine("Please Enter A User Name");
                                user = Console.ReadLine();
                                Console.WriteLine("Please Enter A Password");
                                password = Console.ReadLine();
                                bool Valid = DataSearcher.CheckValid(user, password);
                                Console.Clear();
                                if (Valid == true)
                                {
                                    DataSearcher.CreateNewUser(user, password);
                                    
                                    Console.WriteLine("UserCreated");
                                    Console.ReadLine();
                                }
                                else if (Valid == false)
                                {
                                    Console.WriteLine("This User Name Already Exists, Please Chose A Different One");
                                    Console.ReadLine();
                                }
                            }
                          
                            break;
                        case "exit":
                            Console.WriteLine("Log Out Succesfull");
                            menu = false;
                            Console.ReadLine();
                            break;
                            default:
                            Console.WriteLine("Invalid Action");
                            break;

                    }
                }
            }

            else
            {
                Console.WriteLine("Invalid User Name Or Password, Program terminated...");
                Console.ReadLine();
            }

        }
    }
}
