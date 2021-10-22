using System;

namespace CLPJ2
{
    class Menu
    {
        static public int ShowMenu()
        {
            string[] menuOptions = {"Templates", "Contacts", "Send Emails", "Exit"};
            for (int i = 0; i > menuOptions.Length; i++) 
            {
                Console.WriteLine((i + 1) + menuOptions[i]);
            }
            string menuSelection = Console.ReadLine();
            return Convert.ToInt32(menuSelection);
        }
    }
}