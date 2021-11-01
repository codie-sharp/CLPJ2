using System;
using System.Collections.Generic;
using System.Linq;

namespace CLPJ2
{
    public class Contact //Contact object class ***CONTACT LIST OBJECT FURTHER DOWN IN FILE***
    {
        public string Name {get; set;}
        public string Email {get; set;}
        public override string ToString()
        {
            return Name +"\t" +Email +"\n";
        }
        public Contact(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }

    public class ContactList //Contact list object class
    {
        List<Contact> contactList = new List<Contact>();
        public ContactList()
        {

        }

        public void ViewContacts()
        {
            if (!contactList.Any())
            {
                Console.WriteLine("There are no contacts to display.");
            }
            else
            {
                foreach (var contact in contactList)
                {
                    Console.WriteLine(contact);
                }
            }
            MenuManager.PressAnyKey();
        }

        public void CreateContacts()
        {
            string newName;
            string newEmail;
            Console.WriteLine("Enter contact name:");
            newName = Console.ReadLine();
            Console.WriteLine($"Enter {newName}'s email address:");
            newEmail = Console.ReadLine();
            var newContact = new Contact(newName, newEmail);
            contactList.Add(newContact);
            Console.WriteLine($"\n{newContact} added.");
            MenuManager.PressAnyKey();
        }

        public void DeleteContacts()
        {
            Console.WriteLine("Enter name or email of contact to delete:");
            string contact = Console.ReadLine();
            for (int i = 0; i < contactList.Count; i++)
            {
                if (contactList[i].Name == contact || contactList[i].Email == contact)
                {
                    Console.WriteLine($"\n{contactList[i]} deleted.");
                    contactList.RemoveAt(i);
                }
                else
                {
                    Console.WriteLine($"\nContact {contact} not found.");
                }
            }
            MenuManager.PressAnyKey();
        }

    }
}