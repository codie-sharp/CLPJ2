using System;

namespace CLPJ2
{
    class Menu
    {
        static string[] menuOption = {"Templates", "Contacts", "Send Emails"};
        static string[] templateOption = {"View Templates", "Create Templates", "Delete Templates"};
        static string[] contactOption = {"View Contacts", "Create Contacts", "Delete Contacts"};
        static ConsoleKeyInfo menuSelection;
        static ConsoleKeyInfo subMenuSelection;
        static int optionNumber;
        static int subOptionNumber;
        static public ConsoleKey MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Main Menu\nPress the number of a menu option below or press the \"ESC\" key to quit.\n");
            for (int i = 0; i < menuOption.Length; i++) 
            {
                Console.WriteLine($"{i + 1}.  {menuOption[i]}");
            }
            menuSelection = Console.ReadKey();
            if (char.IsDigit(menuSelection.KeyChar))
            {
                optionNumber = (int)char.GetNumericValue(menuSelection.KeyChar);
                if (optionNumber <= menuOption.Length && optionNumber > 0)
                {
                    switch (optionNumber)
                    {
                        case 1:
                            SubMenu(templateOption);
                            break;
                        case 2:
                            SubMenu(contactOption);
                            break;
                        case 3:
                            EmailMenu();
                            break;
                        default: 
                            break;
                    }
                }
            }
            return menuSelection.Key;
        }
        
        static public void SubMenu(string[] subMenuOption)
        {
            do
            {
                Console.Clear();
                Console.WriteLine($"{menuOption[optionNumber - 1]} Menu\nPress the number of a menu option below or press the \"ESC\" key to go back to the Main Menu.\n");
                for (int i = 0; i < subMenuOption.Length; i++) 
                {
                    Console.WriteLine($"{i + 1}.  {subMenuOption[i]}");
                }
                subMenuSelection = Console.ReadKey();
                if (char.IsDigit(subMenuSelection.KeyChar))
                {
                    subOptionNumber = (int)char.GetNumericValue(subMenuSelection.KeyChar);
                    if (subOptionNumber <= subMenuOption.Length && subOptionNumber > 0)
                    {
                        Console.WriteLine($"\nYou chose {subMenuOption[subOptionNumber - 1]}");
                        switch (optionNumber)
                        {
                            case 2:
                                switch (subOptionNumber)
                                {
                                    case 1:
                                        Contact.ViewContacts();
                                        break;
                                    case 2:
                                        Contact.CreateContacts();
                                        break;
                                    default: 
                                        break;
                                }
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            while (subMenuSelection.Key != ConsoleKey.Escape);
        }

        static public void EmailMenu()
        {
            Console.WriteLine("Emails sent");
        }
    }
}
/*Create Menu objects that takes multiple string[] as arguments to create main and submenus?  
Need to create method for Console.ReadKey() authentication*/