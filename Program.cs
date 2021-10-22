using System;

namespace CLPJ2
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                int menuSelection = 0;
                do
                {
                    Menu.ShowMenu();
                }
                while (menuSelection != 4);
            }
        }
    }
}
