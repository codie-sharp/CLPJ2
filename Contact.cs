using System;
using System.Collections.Generic;
using System.Linq;

namespace CLPJ2
{
    class Contact
    {
        static List<Contact> contacts = new List<Contact>();
        public string Name {get; set;}
        public string Email {get; set;}
        static ConsoleKeyInfo contactMenuSelection;
        public Contact (string name, string email)
        {
            Name = name;
            Email = email;
        }

        static public void ViewContacts()
        {
            Console.Clear();
            if (!contacts.Any())
            {
                Console.WriteLine("There are no contacts to display.");
            }
            else
            {
                foreach (var contact in contacts)
                {
                    Console.WriteLine(contact);
                }
            }
            Console.WriteLine("\nPress any key to return to the Contacts Menu.");
            Console.ReadKey();
        }

        static public void CreateContacts()
        {
            string newName;
            string newEmail;
            do
            {
                Console.Clear();
                Console.WriteLine("Enter contact name:");
                newName = Console.ReadLine();
                Console.WriteLine($"\nEnter {newName}'s email address:");
                newEmail = Console.ReadLine();
                var contact = new Contact(newName, newEmail);
                Console.WriteLine($"\nSave contact? Press any key to continue or press \"ESC\" to go back.\n{contact}");
                contactMenuSelection = Console.ReadKey();
                if (contactMenuSelection.Key != ConsoleKey.Escape)
                {
                    contacts.Add(contact);
                }  
                Console.WriteLine("\nWould you like to add another? Press any key to continue or press \"ESC\" to go back.");
                contactMenuSelection = Console.ReadKey();
            }
            while (contactMenuSelection.Key != ConsoleKey.Escape); 
            Console.WriteLine("Contacts added:\n");
            foreach (var contact in contacts)
            {
                Console.WriteLine(contact);
            }
            Console.WriteLine("\nPress any key to return to the Contacts Menu.");
            Console.ReadKey();
        }

        static public void DeleteContacts()
        {

        }

        public override string ToString()
        {
            return Name +"\t" +Email;
        }
    }
}
/*What am I doing*/