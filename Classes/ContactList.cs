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
        List<Contact> contactList;
        public ContactList()
        {
            contactList = ReadWrite.Read<List<Contact>>("contacts");
            if (contactList == null)
            {
                contactList = new List<Contact>();
            }
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
            ReadWrite.Write("contacts", contactList);
            Console.WriteLine($"\n{newContact} saved.");
            MenuManager.PressAnyKey();
        }

        public void DeleteContacts()
        {
            Console.WriteLine("Enter name or email of contact to delete:");
            string search = Console.ReadLine();
            List<Contact> deleteThese = new List<Contact>(); //New list to keep track of all matching results
            for (int i = 0; i < contactList.Count; i++)
            {
                if (contactList[i].Name == search || contactList[i].Email == search)
                {
                    deleteThese.Add(contactList[i]);
                }
            }
            if (!deleteThese.Any())
            {
                Console.WriteLine($"\nContact {search} not found.");
            }
            else 
            {
                foreach (var contact in deleteThese)
                {
                    Console.WriteLine($"{contact} deleted.");
                    contactList.Remove(contact);
                }
                ReadWrite.Write("contacts", contactList);
            }
            MenuManager.PressAnyKey();
        }

        public void SearchContacts()
        {
            Console.WriteLine("Enter name or email of contact:");
            string search = Console.ReadLine();
            //LINQ query
            var query = from Contact in contactList where search == Contact.Name || search == Contact.Email select Contact;
            foreach (var Contact in query)
            {
                Console.WriteLine(Contact);
            }
            MenuManager.PressAnyKey();
        }
    }
}