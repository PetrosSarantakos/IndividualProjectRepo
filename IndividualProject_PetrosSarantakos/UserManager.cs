using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using IndividualProject_PetrosSarantakos.Models;


namespace IndividualProject_PetrosSarantakos
{
    public class UserManager
    {
        
        public User CreateUser()
        {
            bool flag = true;
            Console.Clear();
            User user = new User();
            Console.WriteLine("Enter username:");
            user.Id = Console.ReadLine();
            Console.WriteLine("Enter password:");
            user.Password = Console.ReadLine();
            Console.WriteLine("Enter user's name:");
            user.Name = Console.ReadLine();
            Console.WriteLine("Enter user's surname:");
            user.Surname = Console.ReadLine();
            Console.WriteLine("Enter user's date of birth in YYYY-MM-DD format:");
            while (flag==true){
                try
                {
                    user.BirthDate = Convert.ToDateTime(Console.ReadLine());
                    flag = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Insert a valid date type, in YYYY-MM-DD format:");
                }
            }
            Console.WriteLine("Enter user's e-mail:");
            user.Email = Console.ReadLine();
            Console.WriteLine("Is the user an admin, Y/N?");
            string input = Console.ReadLine();
            while (input != "Y" && input != "y" && input != "N" && input != "n")
            {
                Console.WriteLine("Enter a valid input");
                input = Console.ReadLine();
            }
            if (input == "Y" || input == "y")
            {
                int option = 1;
                user.UserState =(State)option;
            }
            else if (input == "N" || input == "n")
            {
                int option = 0;
                user.UserState = (State)option;
            }
            using (var db = new AppContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
            Console.WriteLine("User created succesfully! Press any key to return");
            Console.ReadKey();
            return user;
        }

        public List<User> GetAllUsers()
        {
            List<User> users;
            using (var db = new AppContext())
            {
                users = db.Users.ToList();
            }
            return users;
        }

        public void ViewAllUsers()
        {
            List<User> users = GetAllUsers();
            foreach (var item in users)
            {
                Console.WriteLine($"Username:{item.Id} Name:{item.Name} Surname:{item.Surname} Date of birth:{item.BirthDate} " +
                    $"E-mail: {item.Email} User Status: {item.UserState}");
            }
        }

        public void DeleteUser()
        {
            Console.Clear();
            ViewAllUsers();
            Console.WriteLine("Write the userID of the user you want to delete.");
            string input = Console.ReadLine();
            using (var db = new AppContext())
            {
                User user = db.Users.Find(input);
                if (user != null)
                {
                    user.UserState = (State)2;
                    db.SaveChanges();
                }
                Console.WriteLine("User deleted succesfully. Press any key to continue.");
                Console.ReadKey();
            }
        }

        public User UserLogin()
        {
            User user = new User();
            int tries = 0;
            while (tries <= 3)
            { 
                Console.WriteLine("Enter Username");
                string username = Console.ReadLine();
                user = FindUserById(username);
                if (user==null)
                {
                    Console.WriteLine("Invalid username");
                    tries = tries + 1;
                    if (tries == 3)
                    {
                        Console.WriteLine("Three invalid attempts, press any key to exit");
                        Console.ReadKey();
                        Environment.Exit(0);
                    }
                }
                if (user != null)
                {
                    Console.WriteLine($"Hello {user.Name} {user.Surname}");
                    tries = 0;
                    break;
                }                
            }
            while (tries<=3)
            {
                Console.WriteLine("Enter Password");
                string password = Console.ReadLine();
                if (password == user.Password)
                {
                    Console.WriteLine("Login Succesfull");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid password");
                    tries = tries + 1;
                    if (tries == 3)
                    {
                        Console.WriteLine("Three invalid attempts, press any key to exit");
                        Console.ReadKey();
                        Environment.Exit(0);
                    }
                }
            }
            return user;
        }

        public void UpdateUser(string userId)
        {
            User check =FindUserById(userId);
            if (check != null)
            {

                Console.WriteLine("What do you want to update?");
                Console.WriteLine("Select: 1.Name, 2.Surname, 3.Birth Date, 4.Email, 5.Administation Privilenges");
                string choice = Console.ReadLine();
                while (choice != "1" && choice != "2" && choice != "3" && choice != "4" && choice != "5")
                {
                    Console.WriteLine("Enter a valid input");
                    choice = Console.ReadLine();
                }
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Enter new name");
                        string name = Console.ReadLine();
                        using (var db = new AppContext())
                        {
                            User updatedUser = db.Users.Single(u => u.Id == userId);
                            updatedUser.Name = name;
                            db.SaveChanges();
                        }
                        break;
                    case "2":
                        Console.WriteLine("Enter new surame");
                        string surname = Console.ReadLine();
                        using (var db = new AppContext())
                        {
                            User updatedUser = db.Users.Single(u => u.Id == userId);
                            updatedUser.Surname = surname;
                            db.SaveChanges();
                        }
                        break;
                    case "3":
                        bool flag = true;
                        Console.WriteLine("Enter new date of birth");
                        using (var db = new AppContext())
                        {
                            User updatedUser = db.Users.Single(u => u.Id == userId);
                            while (flag == true)
                            {
                                try
                                {
                                    DateTime birthDate = Convert.ToDateTime(Console.ReadLine());
                                    updatedUser.BirthDate = birthDate;
                                    flag = false;
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Insert a valid date type, in YYYY-MM-DD format:");
                                }
                            }
                            db.SaveChanges();
                        }
                        break;
                    case "4":
                        Console.WriteLine("Enter new email");
                        string email = Console.ReadLine();
                        using (var db = new AppContext())
                        {
                            User updatedUser = db.Users.Single(u => u.Id == userId);
                            updatedUser.Email = email;
                            db.SaveChanges();
                        }
                        break;
                    case "5":
                        Console.WriteLine("Is the user admin? Y/N?");
                        string input = Console.ReadLine();
                        while (input != "Y" && input != "y" && input != "N" && input != "n")
                        {
                            Console.WriteLine("Enter a valid input");
                            input = Console.ReadLine();
                        }
                        int option = 0;
                        if (input == "Y" || input == "y")
                        {
                            option = 1;
                        }
                        else if (input == "N" || input == "n")
                        {
                            option = 0;
                        }
                        using (var db = new AppContext())
                        {
                            User updatedUser = db.Users.Single(u => u.Id == userId);
                            updatedUser.UserState = (State)option;
                            db.SaveChanges();
                        }
                        break;
                }
                Console.WriteLine("User updated succesfully. Press any key to continue");
            }
            else
            {
                Console.WriteLine($"No user with username {userId} was found. Press any key to continue");
            }
            Console.ReadKey();
        }

        public User FindUserById(string userId)
        {
            User user = new User();
            using (var db = new AppContext())
            {
                user = db.Users.Find(userId);
            }
            return user;
        }
    }
}
