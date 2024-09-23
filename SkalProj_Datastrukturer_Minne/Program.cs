using System;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
             * 
            */

            List<string> theList = new List<string>();

            while (true)
            {
                Console.WriteLine("Enter '+' or '-' to add and remove names from the list. Write 'exit' to go back to main menu.");
                string input = Console.ReadLine();


                if (input.ToLower() == "exit")
                {
                    break;// the user will exit the loop if types "exit"
                }

                if (string.IsNullOrEmpty(input) || input.Length < 2)
                {
                    Console.WriteLine("Invalid input"); // use '+' or '-' infront of name to add or remove from list
                    continue;
                }


                char nav = input[0];
                string value = input.Substring(1);

                switch (nav)
                {
                    case '+':
                        theList.Add(value);// this will add a new name to the list
                        Console.WriteLine($" {value} added to the list");
                        break;
                    case '-':
                        if (theList.Remove(value)) // this will try to remove the person from list
                        {
                            Console.WriteLine($" {value} was removed from the list");
                        }
                        else
                        {
                            Console.WriteLine($" {value} was not found, try again");
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid input, use '+' or '-' infront of name to add or remove from list");
                        break;
                }

                Console.WriteLine($"Count:\t{theList.Count} Capacity:\t{theList.Capacity}");

                //1.När ökar listans kapacitet? (Alltså den underliggande arrayens storlek) 
                //s. Kapacitet ökar när vi lägger till mer element än nuvarande kapacitet vilket är (4).
                //Om vi lägger till 5e namn så ökar det då

                //2. Med hur mycket ökar kapaciteten? 
                //s. Den dubblas varje gång man går över kapacitetet, ex på den 5e element så ökas kapacitet från 4 -> 8
                //   på 9e element ökas det igen från 8 -> 16

                //3. Varför ökar inte listans kapacitet i samma takt som element läggs till? 
                //s. Det minskar minnes förfbrukning och förbättrar prestanda

                //4. Minskar kapaciteten när element tas bort ur listan? 
                //s. Nej, dock det går att minska kapaciteten själva om vi använder TrimEcess() metoden

                //5. När är det fördelaktigt att använda en egendefinierad array istället för en lista?
                //s. När vi vet exakt hur många element kommer att hanteras
            }
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */
            Queue<string> icaKö = new Queue<string>();

            while (true)
            {
                Console.WriteLine("Enter +<name> to enqueue, -<name> to dequeue, or 'exit' to stop.");
                string input = Console.ReadLine();

                if (input.ToLower() == "exit")
                    break;

                if (input.StartsWith("+"))
                {
                    string name = input.Substring(1);
                    icaKö.Enqueue(name);
                    Console.WriteLine($"{name} has entered the queue");
                }
                else if (input == "-")
                {
                    if (icaKö.Count > 0)
                    {
                        string dequedName = icaKö.Dequeue();
                        Console.WriteLine($"{dequedName} has been dealt with and left the queue ");
                    }
                    else
                    {
                        Console.WriteLine("The queue is empty");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Use '+' to add a name or '-' to remove from queue");
                }

                Console.WriteLine("Current queue:" + (icaKö.Count > 0 ? string.Join(",", icaKö) : "Empty"));

            }                    

        }

            /// <summary>
            /// Examines the datastructure Stack
            /// </summary>
            static void ExamineStack()
            {
                /*
                 * Loop this method until the user inputs something to exit to main menue.
                 * Create a switch with cases to push or pop items
                 * Make sure to look at the stack after pushing and and poping to see how it behaves
                */
            }

            static void CheckParanthesis()
            {
                /*
                 * Use this method to check if the paranthesis in a string is Correct or incorrect.
                 * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
                 * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
                 */

            }

        }
    }
