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
            string rollresult;
            
            switch(advordis)
            {
                case 'a':
                {
                    // Roll twice.
                    int diceresult_a = InternalRoller(numdice, dicefaces, modifier);
                    int diceresult_b = InternalRoller(numdice, dicefaces, modifier);

                    // Select the higher roll and return that. If neither is higher, return _a.
                    if (diceresult_a > diceresult_b)
                    {
                        rollresult = diceresult_a.ToString();
                        return rollresult;
                    }
                    else if (diceresult_b > diceresult_a)
                    {
                        rollresult = diceresult_b.ToString();
                        return rollresult;
                    }
                    else
                    {
                        rollresult = diceresult_a.ToString();
                        return rollresult;
                    }
                }
                case 'd':
                {
                    //Roll twice.
                    int diceresult_a = InternalRoller(numdice, dicefaces, modifier);
                    int diceresult_b = InternalRoller(numdice, dicefaces, modifier);

                    // Select the lower roll and return that. If neither is lower, return _a.
                    if (diceresult_a < diceresult_b)
                    {
                        rollresult = diceresult_a.ToString();
                        return rollresult;
                    }
                    else if (diceresult_b < diceresult_a)
                    {
                        rollresult = diceresult_b.ToString();
                        return rollresult;
                    }
                    else
                    {
                        rollresult = diceresult_a.ToString();
                        return rollresult;
                    }
                }
                default:
                {
                    // Default to a single roll.
                    int diceresult = InternalRoller(numdice, dicefaces, modifier);
                    rollresult = diceresult.ToString();
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
        // Basic output for now; might get fancier later.
        private static void Outputter(string rollermessage)
        {
            Console.WriteLine(rollermessage);       
            return;
        }
    }
}