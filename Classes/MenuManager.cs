using System;
using System.Collections.Generic;

namespace CLPJ2
{
    public class MenuManager
    {
        //First string of menu arrays go to MenuHeading method
        static string[] mainMenuOptions = {"Main Menu", "Templates", "Contacts", "Send Emails"};
        static string[] templateMenuOptions = {"Template Menu", "View Templates", "Create Templates", "Delete Templates", "Search Templates"};
        static string[] contactMenuOptions = {"Contact Menu", "View Contacts", "Create Contacts", "Delete Contacts", "Search Contacts"};
        static string[] emailMenuOptions = {"Email Menu", "Select Email Template", "Select Email Contact", "Send Email"};
        public string[][] masterMenuArray = {templateMenuOptions, contactMenuOptions, emailMenuOptions};
        private ConsoleKey menuSelection;
        private ConsoleKey subMenuSelection;
        private static List<string> menuPath = new List<string>();
        public TemplateList templateList = new TemplateList();
        public ContactList contactList = new ContactList();
        public Emailer emailer = new Emailer();

        public ConsoleKey DisplayMainMenu()
        {
            MenuHeading(mainMenuOptions[0], true);
            for(int i = 1; i < mainMenuOptions.Length; i++)
            {
                Console.WriteLine($"{i}. {mainMenuOptions[i]}");
            }
            MainMenuSelect(Console.ReadKey());
            return menuSelection;
        }

        private void DisplaySubMenu(string[] subMenuOptions)
        {
            do
            {
                MenuHeading(subMenuOptions[0], false);
                for(int i = 1; i < subMenuOptions.Length; i++)
                {
                    Console.WriteLine($"{i}. {subMenuOptions[i]}");
                }
                subMenuSelect(Console.ReadKey(), subMenuOptions);
            }
            while (subMenuSelection != ConsoleKey.Escape);
        }
       
        //ConsoleKeyInfo obj has both .Key and .KeyInfo, no other way to get
        private void MainMenuSelect(ConsoleKeyInfo key)
        {
            int optionNumber;
            menuSelection = key.Key;
            if (char.IsDigit(key.KeyChar))
            {
                optionNumber = (int)char.GetNumericValue(key.KeyChar);
                if (optionNumber <= masterMenuArray.Length && optionNumber > 0)
                {
                    DisplaySubMenu(masterMenuArray[optionNumber - 1]);
                }
            }
        }

        private void subMenuSelect(ConsoleKeyInfo key, string[] subMenuOptions)
        {
            int optionNumber;
            subMenuSelection = key.Key;
            if (char.IsDigit(key.KeyChar))
            {
                optionNumber = (int)char.GetNumericValue(key.KeyChar);
                if (optionNumber <= subMenuOptions.Length && optionNumber > 0)
                {
                    if (subMenuOptions == templateMenuOptions)
                    {
                        MenuHeading(templateMenuOptions[optionNumber], false);
                        switch (optionNumber)
                        {
                            case 1:
                                templateList.ViewTemplates();
                                break;
                            case 2:
                                templateList.CreateTemplates();
                                break;
                            case 3:
                                templateList.DeleteTemplates();
                                break;
                            case 4:
                                templateList.SearchTemplates();
                                break;
                            default:
                                break;
                        }
                    }
                    else if (subMenuOptions == contactMenuOptions)
                    {
                        MenuHeading(contactMenuOptions[optionNumber], false);
                        switch (optionNumber)
                        {
                            case 1:
                                contactList.ViewContacts();
                                break;
                            case 2:
                                contactList.CreateContacts();
                                break;
                            case 3:
                                contactList.DeleteContacts();
                                break;
                            case 4:
                                contactList.SearchContacts();
                                break;
                            default:
                                break;
                        }
                    }
                    else if (subMenuOptions == emailMenuOptions)
                    {
                        MenuHeading(emailMenuOptions[optionNumber], false);
                        switch (optionNumber)
                        {
                            case 1:
                                emailer.EmailTemplate(templateList);
                                break;
                            case 2: 
                                emailer.EmailContact(contactList);
                                break;
                            case 3:
                                emailer.SendEmail();
                                break;
                            default:
                                break;
                        }
                    }
                    
                }
            }
        }
        public void MenuHeading(string heading, bool isMainMenu)
        {
            try
            {
                if (menuPath.Contains(heading))
                {
                    menuPath.RemoveAt(menuPath.IndexOf(heading) + 1);
                }
                else
                {
                    menuPath.Add(heading);
                }
            }
            catch (System.Exception)
            {  
                //Out of range, logic is busted
            }
            Console.Clear();
            Console.WriteLine(String.Join(" > ", menuPath.ToArray()));
            if (isMainMenu)
            {
                Console.WriteLine("Press the number of a menu option below or press the \"ESC\" key to quit.\n");
            }
            else
            {
                Console.WriteLine("Press the \"ESC\" key to go back to the previous menu.\n");
            }
            
        }

        static public void PressAnyKey()
        {
            Console.WriteLine($"Press any key to return to the {menuPath[menuPath.Count - 2]}");
            Console.ReadKey();
        }

    }
}
