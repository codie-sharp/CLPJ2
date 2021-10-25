using System;
using System.Collections.Generic;

namespace CLPJ2
{
    class Contact
    {
        List<Contact> Contacts = new List<Contact>();
        public string Name {get; set;}
        public string Email {get; set;}
        public Contact (string name, string email)
        {
            Name = name;
            Email = email;
        }
        public void CreateContact()
        {
            string newName;
            string newEmail;
            Console.Clear();
            Console.WriteLine("Enter contact name:\n");
            newName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine($"Enter {newName}'s email address:\n");
            newEmail = Console.ReadLine();
            Console.WriteLine($"Contact created:\n{newName} {newEmail}");
            
            //Create new Contact obj from input
        }
    }
}
