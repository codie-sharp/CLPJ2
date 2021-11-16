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
        public string[][] masterMenuArray = {templateMenuOptions, contactMenuOptions};
        private ConsoleKey menuSelection;
        private ConsoleKey subMenuSelection;
        private static List<string> menuPath = new List<string>();
        public TemplateList templateList = new TemplateList();
        public ContactList contactList = new ContactList();

        public ConsoleKey DisplayMainMenu() //Entry point called in main
        {
            MenuHeading(mainMenuOptions[0], true);
            for(int i = 1; i < mainMenuOptions.Length; i++)
            {
                Console.WriteLine($"{i}. {mainMenuOptions[i]}");
            }
            MainMenuSelect(Console.ReadKey());
            return menuSelection;
        }

        private void DisplaySubMenu(string[] subMenuOptions) //Displays the submenu selected. Pressing escape exits back to the Main Menu
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

        private void subMenuSelect(ConsoleKeyInfo key, string[] subMenuOptions) //checks which submenu the user selected
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
                }
            }
        }
        public void MenuHeading(string heading, bool isMainMenu) //takes the first element of the menu array as the heading. If this is the main menu alternate text is displayed
        {
            try
            {
                if (menuPath.Contains(heading)) //If the list already contains the element, remove the element that comes after it (the menu you were just at)
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
                //Out of range?
            }
            Console.Clear();
            Console.WriteLine(String.Join(" > ", menuPath.ToArray()));
            if (isMainMenu) //checking if this is the main menu to display alternate text
            {
                Console.WriteLine("Press the number of a menu option below or press the \"ESC\" key to quit.\n");
            }
            else
            {
                Console.WriteLine("Press the \"ESC\" key to go back to the previous menu.\n");
            }
            
        }

        static public void PressAnyKey() //called throughout the program to pause after task is complete
        {
            Console.WriteLine($"Press any key to return to the {menuPath[menuPath.Count - 2]}");
            Console.ReadKey();
        }

    }
}
