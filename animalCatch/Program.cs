using System;
namespace animalCatch;

    class versionOne
    {
        static void Main(string[] args)
        {
            int animalsCaught = 0, nets = 0, health = 0, direction = 0, round = 1;
            Random r = new Random();
            bool win = false;
            Console.Write("What is the name of your character? ");
            string name = Console.ReadLine();
            initValues(ref animalsCaught, ref nets, ref health, r);
            while (animalsCaught > 0 && nets > 0 && health > 0 && win == false)
            {
                direction = chooseDirection();
                /* the direction impacts the number passed to the actions method
                 * if they choose to leaveleft, they will only receive bad outcomes
                 * if they choose right, they have a better chance of receiving 
                 * good outcomes along with the bad outcomes */
                if (direction == 1)
                {
                    actions(r.Next(10), ref animalsCaught, ref nets, ref health);
                    checkResults(ref round, ref animalsCaught, ref nets, ref health, ref win);
                }
                else
                {
                    actions(r.Next(10), ref animalsCaught, ref nets, ref health);
                    checkResults(ref round, ref animalsCaught, ref nets, ref health, ref win);
                }
            }

            if (win)
            {
                Console.WriteLine("Congratulations on successfully completing your workday!");
                Console.ReadKey();
            }
            else if (health <= 0)
            {
                Console.WriteLine("You lost too much health and did not complete your workday");
                Console.ReadKey();
            }
            else if (nets <= 0)
            {
                    Console.WriteLine("You lost too many nets and cannot complete your workday");
                    Console.ReadKey();
            }
        }

        private static void checkResults(ref int round, ref int animalsCaught, ref int nets, ref int health, ref bool win)
        {
            round += 1;
            Console.WriteLine($"------Round: {round}------");
            Console.WriteLine();
            Console.WriteLine($"Animals Caught: {animalsCaught} Nets: {nets} Health: {health}");
            Console.WriteLine();
            if (round == 20)
            {
                win = true;
            }
            return;
        }

        private static void actions(int num, ref int animalsCaught, ref int nets, ref int health)
        {
            switch (num)
            {
                case 0:
                    Console.WriteLine("You tried to catch an injured raccon but got bit right before it ran away!");
                    Console.WriteLine("You lost 3 unit of health and 1 net");
                    Console.WriteLine();
                    health -= 3;
                    nets -= 1;
                    break;
                case 1:
                    Console.WriteLine("As you make your way back to the truck after catching a litter of kittens you stepped on an underground bee hive!");
                    Console.WriteLine("You lost 2 units of health and caught 4 animal");
                    Console.WriteLine();
                    health -= 2;
                    animalsCaught += 4;
                    break;
                case 2:
                    Console.WriteLine("While you make a quick stop to grab some coffee, you come out to find PETA has stolen 3 nets from the truck!");
                    Console.WriteLine("You lost 3 nets and gain 1 health from coffee");
                    Console.WriteLine();
                    health += 1;
                    nets -= 3;
                    break;
                case 3:
                    Console.WriteLine("You catch a orphaned fawn who's mother got hit by a car.");
                    Console.WriteLine("You caught 1 animal");
                    Console.WriteLine();
                    animalsCaught += 1;
                    break;
                case 4:
                    Console.WriteLine("You show up to see three abandoned dogs that couldn't be happier to see you!");
                    Console.WriteLine("You caught 3 animals");
                    Console.WriteLine();
                    animalsCaught += 3;
                    break;
                case 5:
                    Console.WriteLine("You catch a horse that broke loss from its pasture. You lose 2 nets in the process.");
                    Console.WriteLine("You lost 2 nets and caught 1 animal");
                    Console.WriteLine();
                    nets -= 2;
                    animalsCaught += 1;
                    break;
                case 6:
                    Console.WriteLine("You get bit while catching a lose snake in someones house but also find a nest with 3 eggs in it!");
                    Console.WriteLine("You lost 1 units of health and caught 4 animals");
                    Console.WriteLine();
                    health -= 1;
                    animalsCaught += 4;
                    break;
                case 7:
                    Console.WriteLine("A mouse chewed through your nets!");
                    Console.WriteLine("You lost 3 nets");
                    Console.WriteLine();
                    nets -= 3;
                    break;
                case 8:
                    Console.WriteLine("You pull over to repair 2 of your nets.");
                    Console.WriteLine("You gain 2 nets.");
                    Console.WriteLine();
                    nets += 2;
                    break;
                case 9:
                    Console.WriteLine("You get sprayed while trying to relocate a skunk.");
                    Console.WriteLine("You lost 2 units of health");
                    Console.WriteLine();
                    health -= 2;
                    break;
                default:
                    Console.WriteLine("You and a pinic and fall asleep under the willow tree. You wake up to 2 cats and a dog.");
                    Console.WriteLine("You gain 2 health and caught 3 animals.");
                    Console.WriteLine();
                    health += 2;
                    animalsCaught += 3;
                    break;
            }
        }

        private static int chooseDirection()
        {
            Console.WriteLine("While on patrol you come to a fork in the road, enter 1 to turn left or a 2 to turn right");
            int direction = int.Parse(Console.ReadLine());
            while (direction != 1 && direction != 2)
            {
                Console.WriteLine("You entered an invalid number, please enter a 1 for left or a 2 for right");
                direction = int.Parse(Console.ReadLine());
            }
            return direction;
        }

        private static void initValues(ref int animalsCaught, ref int nets, ref int health, Random r)
        {
            animalsCaught = r.Next(1) + 2;
            nets = r.Next(10) + 5;
            health = r.Next(14) + 5;
            return;
        }
    }

