using System;

namespace CLPJ2
{
    class Program
    {
        static void Main(string[] args)
        {
        /*Add a check at each prompt if the user inputs "Q" or "q" to quit.*/
            bool masterLoop = true;
            while (masterLoop)
            {
            /*Create a Template class and call methods here. The Template class will pull from disk.*/
                Console.WriteLine("Choose a template or type \"Q\" to quit. (Type anything)");
                String userTemplate = Console.ReadLine();
                if (userTemplate.ToUpper() == "Q")
                {
                    masterLoop = false;
                    break;
                }
            /*Create a SendEmail class and call methods here*/
                Console.WriteLine("Enter recipients or type \"Q\" to quit. (Type anything)");
                String userRecipients = Console.ReadLine();
                if (userRecipients.ToUpper() == "Q")
                {
                    masterLoop = false;
                    break;
                }
                Console.WriteLine($"Sending {userTemplate} to {userRecipients}.");
            }
        }
    }
}
