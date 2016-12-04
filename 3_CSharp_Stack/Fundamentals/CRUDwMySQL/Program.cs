using System;
using DbConnection;

namespace ConsoleApplication
{
    public class database
    {
        public static void Read() 
        {
            var users = DbConnector.ExecuteQuery("SELECT * FROM users");
            foreach (var user in users) 
            {
                Console.WriteLine("ID: {0}, First Name: {1}, Last Name: {2}, Favorite Number: {3}", user["id"], user["first_name"], user["last_name"], user["favorite_number"]);
            }
        }

        public static void Create()
        {
            while (true)
            {
                Console.WriteLine("Welcome to favorite number db! Please type 'q' when you would like to exit.");

                Console.WriteLine("Please enter your first name: ");
                string FirstName = Console.ReadLine();
                if (FirstName == "q")
                {
                    Console.WriteLine("Okay. Goodbye!");
                    break;
                }

                Console.WriteLine("Please enter your last name: ");
                string LastName = Console.ReadLine();
                if (LastName == "q")
                {
                    Console.WriteLine("Okay. Goodbye!");                
                    break;
                }

                Console.WriteLine("Please enter your favorite number: ");
                string FavNum = Console.ReadLine();
                if (FavNum == "q")
                {
                    Console.WriteLine("Okay. Goodbye!");
                    break;
                }

                Console.WriteLine("Here is what you have entered: \n First name: {0} \n Last name: {1} \n Favorite number: {2}", FirstName, LastName, FavNum);

                Console.WriteLine("Would you like to save your result? y/n");
                string SaveQ = Console.ReadLine();
                if (SaveQ == "y")
                {
                    DbConnector.ExecuteQuery($"INSERT INTO users(first_name, last_name, favorite_number, created_at, updated_at) VALUES ('{FirstName}', '{LastName}', '{FavNum}', NOW(), NOW());");
                    // INSERT INTO users(first_name, last_name, favorite_number, created_at, updated_at) VALUES (FirstName, LastName, NOW(), NOW())
                }
                if (SaveQ == "n")
                {
                    Console.WriteLine("Okay. Goodbye!");
                    break;
                }
                database.Read();
                break;
            }
        }

        public static void Update() 
        {
            while (true)
            {
                Console.WriteLine("Please enter id of the user you would like to update");
                string UpdateId = Console.ReadLine();
                if (UpdateId == "q")
                {
                    Console.WriteLine("Okay. Goodbye!");                
                    break;
                }
                Console.WriteLine("Please enter first name");
                string UpdatedFirstName = Console.ReadLine();
                if (UpdatedFirstName == "q")
                {
                    Console.WriteLine("Okay. Goodbye!");                
                    break;
                }
                Console.WriteLine("Please enter last name");
                string UpdatedLastName = Console.ReadLine();
                if (UpdatedLastName == "q")
                {
                    Console.WriteLine("Okay. Goodbye!");                
                    break;
                }
                Console.WriteLine("Please enter new favorite number");
                string UpdatedFavNum = Console.ReadLine();
                if (UpdatedFavNum == "q")
                {
                    Console.WriteLine("Okay. Goodbye!");                
                    break;
                }                
                Console.WriteLine("Here is what you have entered: \n First name: {0} \n Last name: {1} \n Favorite number: {2}", UpdatedFirstName, UpdatedLastName, UpdatedFavNum);

                Console.WriteLine("Would you like to save your result? y/n");
                string SaveQ = Console.ReadLine();
                if (SaveQ == "y")
                {
                    DbConnector.ExecuteQuery($"Update users SET first_name = '{UpdatedFirstName}', last_name = '{UpdatedLastName}', favorite_number = '{UpdatedFavNum}', updated_at = NOW() WHERE id = {UpdateId}");
                }
                if (SaveQ == "n")
                {
                    Console.WriteLine("Okay. Goodbye!");
                    break;
                }
                database.Read();
                break;
            }
        }
        
        public static void Delete() 
        {
            while (true)
            {
                Console.WriteLine("Please enter the ID of the user you would like to delete from database: ");
                string DeleteId = Console.ReadLine();

                if (DeleteId == "q") 
                {
                    break;
                }

                var users = DbConnector.ExecuteQuery($"SELECT * FROM users WHERE id = '{DeleteId}'");

                // if (users.HasRows)
                // {
                    Console.WriteLine("Are you sure you want to delete ");

                    foreach (var user in users) 
                    {
                        Console.WriteLine("ID: {0}, First Name: {1}, Last Name: {2}, Favorite Number: {3}", user["id"], user["first_name"], user["last_name"], user["favorite_number"]);
                    }

                    Console.WriteLine("*************************************************");
                    Console.WriteLine("y/n");
                    
                    string DeleteConfirm = Console.ReadLine();

                    if (DeleteConfirm == "y") 
                    {
                        DbConnector.ExecuteQuery($"DELETE FROM users WHERE id='{DeleteId}'");
                        break;
                    } 
                    else if (DeleteConfirm == "n")
                    {
                        break;
                    }
                    else 
                    {
                        Console.WriteLine("Invalid input. Please try again.");
                        break;
                    }
                // } else
                // {
                //     Console.WriteLine("Invalid entry. Please try again");
                // }
                // break;
            }
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            bool condition = true;
            while (condition) 
            {
                Console.WriteLine ("Please choose what you would like to do(1-5): \n 1. Create a new user \n 2. Print out all users \n 3. Update a saved user \n 4. Delete a user \n 5. exit");
                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        database.Create();
                        break;
                    case "2":
                        database.Read();
                        break;
                    case "3":
                        database.Update();
                        break;
                    case "4":
                        database.Delete();
                        break;
                    case "5":
                        condition = false;
                        break;
                    default:
                        Console.WriteLine("Invalid selection. Please select 1,2,3,4, or 5.");
                        break;
                }
            }
            // database.Read();
            // database.Create();
        }
    }
}
