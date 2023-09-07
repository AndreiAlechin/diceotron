using System;

namespace DiceOTron
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get command-line arguments
            int arg1 = int.Parse(args[0]);
            int arg2 = int.Parse(args[1]);
            int arg3 = int.Parse(args[2]);
            char arg4 = char.Parse(args[3]);

            // Run the roller with the arguments and get the result.
            // Note to self for later: tuple types for getting more detail out of the roller for fancier output?.
            // Note to self for later: input checking method to catch bad/incorrect input.
            string rolleroutput = Roller(arg1, arg2, arg3, arg4);

            //Send the roller result to the output method.
            Outputter(rolleroutput);
        }

        // Do the dice rolling here.
        // Note to self for later: tuple types for getting more detail out of the roller for fancier output?.
        private static string Roller(int numdice, int dicefaces, int modifier, char advordis)
        {
            // For testing only. Actual code for the roller goes here.
            Random random = new Random();
            string rollresult;
            int diceresult = 0;
            // To account for exclusive maximum of 2nd argument in random.Next.
            int dicefaceslimit = dicefaces + 1;
            
            //Roll the dice. Advantage/disadvantage to add later. Local function?
            for (int i = 0; i < numdice; i++)
            {
                diceresult += random.Next(1, dicefaceslimit);
            }

            //Apply the modifier.
            diceresult += modifier;

            rollresult = diceresult + " " + advordis;
            return rollresult;
        }

        // Output the results.
        // Basic output for now; might get fancier later.
        private static void Outputter(string rollermessage)
        {
            Console.WriteLine(rollermessage);       
            return;
        }
    }
}