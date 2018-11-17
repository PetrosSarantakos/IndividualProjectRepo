using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject_PetrosSarantakos
{
    public class Menu
    {
        public void InitialMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Regnessem!");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Choose an option:!");
            Console.WriteLine("1.Login");
            Console.WriteLine("0.Exit");
            string input = "";
            while (input != "1" && input != "0")
            {
                input = Console.ReadLine();
                if (input != "1" && input != "0")
                {
                    Console.WriteLine("Choose a valid option");
                }
            }
            if (input == "0")
            {
                Environment.Exit(0);
            }
            if (input == "1")
            {
                Console.WriteLine("User Login:");
                Console.WriteLine("--------------------------------------");

            }
        }
        public string AdminMenu()
        {
            Console.Clear();
            Console.WriteLine("Admin Panel");
            Console.WriteLine("---------------------");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. User manager");
            Console.WriteLine("2. Messenger");
            Console.WriteLine("0. Logout");
            string input = "";
            while (input != "0" && input != "1" && input != "2")
            {
                input = Console.ReadLine();
                if (input != "0" && input != "1" && input != "2")
                {
                    Console.WriteLine("Enter a valid input");
                }
            }
            return input;                     
        }
        public string ManageUsers()
        {
            Console.Clear();
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Create user");
            Console.WriteLine("2. Update user");
            Console.WriteLine("3. Delete user");
            Console.WriteLine("0. Go Back");
            string input = "";
            while (input != "0" && input != "1" && input != "2" && input != "3")
            {
                input = Console.ReadLine();
                if (input != "0" && input != "1" && input != "2"&& input != "3")
                {
                    Console.WriteLine("Enter a valid input");
                }
            }
            return input;            
        }
        public string Messenger()
        {
            Console.Clear();
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Send Message");
            Console.WriteLine("2. View Messages");
            Console.WriteLine("0. Go Back");
            string input = "";
            while (input != "0" && input != "1" && input != "2")
            {
                input = Console.ReadLine();
                if (input != "0" && input != "1" && input != "2")
                {
                    Console.WriteLine("Enter a valid input");
                }
            }
            return input;
        }
        public string UserMenu()
        {
            Console.Clear();
            Console.WriteLine("User Panel");
            Console.WriteLine("---------------------");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Messenger");
            Console.WriteLine("0. Logout");
            string input = "";
            while (input != "0" && input != "1")
            {
                input = Console.ReadLine();
                if (input != "0" && input != "1")
                {
                    Console.WriteLine("Enter a valid input");
                }
            }
            return input;
        }
    }
}
