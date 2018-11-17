using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndividualProject_PetrosSarantakos.Models;


namespace IndividualProject_PetrosSarantakos
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Menu menu = new Menu();
                UserManager um = new UserManager();
                MessageManager mm = new MessageManager();
                menu.InitialMenu();
                User user = um.UserLogin();
                switch (user.UserState)
                {
                    case (State)1:
                        string choice = menu.AdminMenu();
                        while (choice != "0")
                        {
                            if (choice == "1")
                            {
                                string option = menu.ManageUsers();
                                while (option != "0")
                                {
                                    if (option == "1")
                                    {
                                        um.CreateUser();
                                    }
                                    else if (option == "2")
                                    {
                                        um.ViewAllUsers();
                                        Console.WriteLine("Which user you want to update");
                                        string input = Console.ReadLine();
                                        um.UpdateUser(input);
                                    }
                                    else if (option == "3")
                                    {
                                        um.DeleteUser();
                                    }
                                    option = menu.ManageUsers();
                                }
                                if (option == "0")
                                {
                                    choice = menu.AdminMenu();
                                }
                            }
                            else if (choice == "2")
                            {
                                string option = menu.Messenger();
                                while (option != "0")
                                {
                                    if (option == "1")
                                    {
                                        mm.SendMessage(user.Id);
                                    }
                                    else if (option == "2")
                                    {
                                        um.ViewAllUsers();
                                        Console.WriteLine("View messages with who?");
                                        string input = Console.ReadLine();
                                        User receiver = um.FindUserById(input);
                                        mm.ViewMessageFromUser(user.Id, receiver.Id);
                                    }
                                    option = menu.Messenger();
                                }
                                if (option == "0")
                                {
                                    choice = menu.AdminMenu();
                                }
                            }
                            else if (choice == "0")
                            {
                                break;
                            }
                        }
                        break;
                    case (State)0:
                        choice = menu.UserMenu();
                        while (choice != "0")
                        {
                            if (choice == "1")
                            {
                                string option = menu.Messenger();
                                while (option != "0")
                                {
                                    if (option == "1")
                                    {
                                        mm.SendMessage(user.Id);
                                    }
                                    else if (option == "2")
                                    {
                                        um.ViewAllUsers();
                                        Console.WriteLine("View messages with who?");
                                        string input = Console.ReadLine();
                                        User receiver = um.FindUserById(input);
                                        mm.ViewMessageFromUser(user.Id, receiver.Id);
                                    }
                                    option = menu.Messenger();
                                }
                                if (option == "0")
                                {
                                    choice = menu.UserMenu();
                                }
                            }
                            else if (choice == "0")
                            {
                                break;
                            }
                        }
                        break;
                    case (State)2:
                        Console.Clear();
                        Console.WriteLine("Access denied, you have been deleted. Press any key to exit.");
                        Console.ReadKey();
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}

