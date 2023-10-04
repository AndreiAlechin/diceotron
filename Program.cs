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
            // Plan B!: int array return type instead?
            // Note to self for later: input checking method to catch bad/incorrect input.
            int[] rolleroutput = Roller(arg1, arg2, arg3, arg4);

            //Send the roller result to the output method.
            Outputter(rolleroutput);
        }

        // Do the dice rolling here.
        // Note to self for later: tuple types for getting more detail out of the roller for fancier output?.
        // Plan B!: int array return type instead?
        // private static (string, string, char) Roller(int numdice, int dicefaces, int modifier, char advordis)
        private static int[] Roller(int numdice, int dicefaces, int modifier, char advordis)
        {
            int[] rollresult = new int[3];
            
            switch(advordis)
            {
                case 'a':
                {
                    // Roll twice.
                    int diceresult_a = InternalRoller(numdice, dicefaces, modifier);
                    int diceresult_b = InternalRoller(numdice, dicefaces, modifier);
                    // Put each roll into the first two elements of the array.
                    rollresult[0] = diceresult_a;
                    rollresult[1] = diceresult_b;

                    // Find the higher roll, set third array element to denote desired roll; default to first roll if equal.
                    if (diceresult_a > diceresult_b)
                    {
                        rollresult[2] = 0;
                        return rollresult;
                    }
                    else if (diceresult_b > diceresult_a)
                    {
                        rollresult[2] = 1;
                        return rollresult;
                    }
                    else
                    {
                        rollresult[2] = 0;
                        return rollresult;
                    }
                }
                case 'd':
                {
                    // Roll twice.
                    int diceresult_a = InternalRoller(numdice, dicefaces, modifier);
                    int diceresult_b = InternalRoller(numdice, dicefaces, modifier);
                    // Put each roll into the first two elements of the array.
                    rollresult[0] = diceresult_a;
                    rollresult[1] = diceresult_b;

                    // Find the lower roll, set third array element to denote desired roll; default to first roll if equal.
                    if (diceresult_a < diceresult_b)
                    {
                        rollresult[2] = 0;
                        return rollresult;
                    }
                    else if (diceresult_b < diceresult_a)
                    {
                        rollresult[2] = 1;
                        return rollresult;
                    }
                    else
                    {
                        rollresult[2] = 0;
                        return rollresult;
                    }
                }
                default:
                {
                    // Default to a single roll. 
                    int diceresult = InternalRoller(numdice, dicefaces, modifier);
                    // Set first array element to the roll, leave second element as null, set third element to denote the first roll.
                    rollresult[0] = diceresult;
                    return rollresult;
                }
            }
                                    
            int InternalRoller(int numdice, int dicefaces, int modifier)
            {
                Random random = new Random();
                int internaldiceresult = 0;
                // To account for exclusive maximum of 2nd argument in random.Next.
                int dicefaceslimit = dicefaces + 1;

                // Roll the dice.
                for (int i = 0; i < numdice; i++)
                {
                    internaldiceresult += random.Next(1, dicefaceslimit);
                }

                //Apply the modifier.
                internaldiceresult += modifier;

                return internaldiceresult;
            }
      }

        // Output the results.
        // Fixed output formatting for now.
        // Note to self for later: add different output formatting based on an additional command-line argument?
        private static void Outputter(int[] results)
        {
            // Code to output results goes here. I'm tired for now.
            return;
        }
    }
}