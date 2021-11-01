using System;

namespace CLPJ2
{
  class Program
  {
    static ConsoleKey menuSelection;
    static void Main(string[] args)
    {
      var menuManager = new MenuManager();
      do
      {
        menuSelection = menuManager.DisplayMainMenu();
      }
      while(menuSelection != ConsoleKey.Escape);
    }
  }
}
