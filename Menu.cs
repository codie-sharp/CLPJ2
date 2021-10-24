using System;

namespace CLPJ2
{
    class Menu
    {
        static string[] menuOption = {"Templates", "Contacts", "Send Emails"};
        static string[] templateOption = {"View Templates", "Edit Templates", "New Templates"};
        static string[] contactOption = {"View Contacts", "Edit Contacts", "New Contacts"};
        static ConsoleKeyInfo menuSelection;
        static ConsoleKeyInfo subMenuSelection;
        static int optionNumber;
        static public ConsoleKey MainMenu()
        {
            Console.Clear();
            Console.WriteLine("\nMain Menu\nType the number of a menu option below or hit the \"ESC\" key to quit.\n");
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
                            TemplateMenu();
                            break;
                        case 2:
                            ContactMenu();
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
        
        static public void TemplateMenu()
        {
            do
            {
                Console.Clear();
                Console.WriteLine($"{menuOption[optionNumber - 1]} Menu\nType the number of a menu option below or hit the \"ESC\" key to go back to the Main Menu.\n");
                for (int i = 0; i < templateOption.Length; i++) 
                {
                    Console.WriteLine($"{i + 1}.  {templateOption[i]}");
                }
                subMenuSelection = Console.ReadKey();
                if (char.IsDigit(subMenuSelection.KeyChar))
                {
                    optionNumber = (int)char.GetNumericValue(subMenuSelection.KeyChar);
                    if (optionNumber <= templateOption.Length && optionNumber > 0)
                    {
                        Console.WriteLine($"\nYou chose {templateOption[optionNumber - 1]}");
                    }
                }
            }
            while (subMenuSelection.Key != ConsoleKey.Escape);
        }

        static public void ContactMenu()
        {
            for (int i = 0; i < contactOption.Length; i++) 
            {
                Console.WriteLine($"{i + 1}.  {contactOption[i]}");
            }
            subMenuSelection = Console.ReadKey();
            if (subMenuSelection.Key == ConsoleKey.Escape)
            {
                MainMenu();
            }
            else if (char.IsDigit(subMenuSelection.KeyChar))
            {
                optionNumber = (int)char.GetNumericValue(subMenuSelection.KeyChar);
                if (optionNumber <= contactOption.Length && optionNumber > 0)
                {
                    Console.WriteLine($"\nYou chose {contactOption[optionNumber - 1]}");
                }
            }
        }

        static public void EmailMenu()
        {
            Console.WriteLine("Emails sent");
        }
    }
}