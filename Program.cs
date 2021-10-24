using System;

namespace CLPJ2
{
    class Program
    {
       static ConsoleKey menuSelection;
        static void Main(string[] args)
        {
         
          do
          {
            menuSelection = Menu.MainMenu();
          }
          while(menuSelection != ConsoleKey.Escape);
        }
    }
}
