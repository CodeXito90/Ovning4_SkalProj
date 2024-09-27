using System;
using System.Globalization;

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
                    + "\n5. Rekursion"
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
                    case '5':
                        Rekursion();
                        break;
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

                //1. När ökar listans kapacitet? (Alltså den underliggande arrayens storlek) 
                //s. Kapacitet ökar när vi lägger till mer element än nuvarande kapacitet vilket är (4).
                //   Om vi lägger till 5e namn så ökar det då

                //2. Med hur mycket ökar kapaciteten? 
                //s. Den dubblas varje gång man går över kapacitetet, ex på den 5e elementet så ökas kapacitet från 4 -> 8
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
                Console.WriteLine("Type '+' to enter queue, '-' to dequeue, or 'exit' to stop.");
                string input = Console.ReadLine();

                if (input.ToLower() == "exit")
                    break;//checks to see if user wants to exit loop

                if (input.StartsWith("+"))//checks to see if sentence starts with + symbol 
                {
                    string name = input.Substring(1);//whatever the user inputs after the + symbol will be added to ica list
                    icaKö.Enqueue(name);
                    Console.WriteLine($"{name} has entered the queue");
                }
                else if (input.StartsWith("-"))// same check statement to determine if - symbol is used
                {
                    if (icaKö.Count > 0)
                    {
                        string dequedName = icaKö.Dequeue();//will delete from queue
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
            //F. Simulera ännu en gång ICA-kön på papper. Denna gång med en stack. Varför är det inte
            //   så smart att använda en stack i det här fallet ?
            //S. Stack klassen fungerear inte bra för köer eftersom det strider mot FIFO principen, (först in först ut)
            //   I en stack den person som kommer först får inte gå först, istället behandlas de som kmr in sist först.(LIFO) Last in First Out
            //   Det därför stacks inte passar för simulering av verkliga köer där ordning är viktigt

        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
            {
            //Reverse string operations assignment
            Console.WriteLine("Enter string to reverse");

            string input1 = Console.ReadLine();
            string reversed = ReverseText(input1);

            Console.WriteLine("Reversed string:" + reversed);

            static string ReverseText(string text)
            {
                // The Stack data structure allows us to easily push each character into the
                // string and then pop them in reverse order (FILO princip) no-jutsu style

                Stack<char> stack = new Stack<char>();

                foreach (char c in text)
                {
                    stack.Push(c);
                }

                string reversedText = "";
                while (stack.Count > 0)
                {
                    reversedText += stack.Pop();
                }

                return reversedText;
            }

            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */

            Stack<string> stack = new Stack<string>();
            while (true)
            {
                Console.WriteLine("Enter +(item) to push, or - to pop. Type exit to return to main menu");
                string input = Console.ReadLine();

                if (input.ToLower() == "exit")
                    break;

                if (string.IsNullOrEmpty(input) || input.Length < 2 && input != "-")
                {
                    //Validation statement to check if input is valid or not
                    Console.WriteLine("Invalid input. Use + symbol to push, or - symbol to pop. or exit to return to main menu ");
                    continue;
                }

                //Determines the operation if user input is ('+' or '-')
                char userSelection = input[0];

                switch (userSelection)
                {
                    case '+':
                        string item = input.Substring(1);
                        stack.Push(item);
                        Console.WriteLine($"{item} was pushed onto the stack.");
                        break;

                    case '-':
                        if (stack.Count > 0)
                        {
                            string poppedItem = stack.Pop();
                            Console.WriteLine($"{poppedItem}");
                        }
                        else
                        {
                            Console.WriteLine("The stack it currently empty, nothing to poop");
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid operation. Use + symbol to push, or - symbol to pop. or exit to return to main menu ");
                        break;
                }
                // We will print out the current state of the stack
                // checks if element is higher than 0. If true then it will write out all elements separated
                // by "," using the string.join() method. If the stack is empty then it will print "Empty"
                Console.WriteLine("Current stack;" + (stack.Count > 0 ? string.Join(",", stack) : "Empty"));
            }

        }

            static void CheckParanthesis()
            {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */
                Console.WriteLine("Write a string that contains paranthesis, to check if its correct");

                //correct = ("(()), {}, [({})]"); ---> our base values to pair

                string userInput = Console.ReadLine();

                if (IsCorrect(userInput))
                {

                    Console.WriteLine("String is correct");
                
                }
                else 
                {
                
                    Console.WriteLine("String is incorrect.");
                    
                }                               
                
            }
            static bool IsCorrect(string input) 
            {
                // The Dictionary method allows us to track any key value pairs, in this case we use each paranthesis
                // as a value to match. It will then check and compare it with the top of the stack
                Dictionary<char, char> bracketsCheck = new Dictionary<char, char>()
                {

                    { '(', ')' },
                    { '{', '}' },
                    { '[', ']' }

                };

                Stack<char> stack = new Stack<char>();

                foreach (char c in input) 
                {
                    // If input is a opening bracket, then it will push it onto the stack
                    if (bracketsCheck.ContainsKey(c))

                    {
                        stack.Push(c);
                    }
                    // If it's a closing bracket, checks to see if it matches the last opening bracket
                    else if (bracketsCheck.ContainsValue(c)) 
                    {
                        // If the stack is empty or none of the string match closing bracket it will retunr false
                        if (stack.Count == 0 || bracketsCheck[stack.Pop()] != c) 
                          {
                            return false;
                          }
                    } 
                }

                return stack.Count == 0;
            }

            // We can also use the stack method instead of dictionary to directly
            // match brackets and compare chars. But i prefer dictionary when using pair values

            //static bool CheckIfCorrect(string input) 
            //{

            //    Stack<char> stack = new Stack<char>();

            //    foreach (char c in input) 
            //    {
            //        //We push the opening brackets onto the stack
            //        if (c == '(' || c == '{' || c == '[')
            //        {
            //            stack.Push(c);
            //        }

            //        else if (c == ')' || c == '}' || c == ']') 
            //        {

            //            if (stack.Count == 0) 
            //            {
            //                return false;
            //            }

            //            char top = stack.Pop();

            //            // Check if the current closing bracket matches the last opening bracket
            //            if ((c == ')' && top != '(') ||
            //                (c == '}' && top != '{') ||
            //                (c == ']' && top != '['))
            //            {
            //                return false; // The brackets dont macth
            //            }
            //        }

            //        return stack.Count == 0;
            //}

            //}
            
        //Vi ska skapa methods som visar hur rekursion fungerar med udda och jämna tal
        static void Rekursion() 
        {
            // först anropar vi recursiveodd 1 som beräknar första udda talet = 1
            Console.WriteLine("RecursiveOdd(1) = " + RecursiveOdd(1));           
            Console.WriteLine("RecursiveOdd(3) = " + RecursiveOdd(3));
            Console.WriteLine("RecursiveOdd(5) = " + RecursiveOdd(5));

            //här ska vi beräkna det n;te udda talet
            static int RecursiveOdd(int n)
            {
                Console.WriteLine(new String('-', 20));// separator så det ser finare och mer läsbart 

                // Visar vilket värde n har och att metoden anropar sig själv med n-1
                Console.WriteLine($"n = {n}, calling RecursiveOdd({n - 1})\n");

                if (n == 1)// Vår basecase: om n är 1, returneras det första udda talet, som är 1
                {
                    Console.WriteLine("The base case has been reached (n = 1), returning 1\n");
                    return 1;
                }

                int result = RecursiveOdd(n - 1) + 2;
                // Vi anropar RecursiveOdd igen med n-1 och lägger till 2 för att få nästa udda tal osv
                // tills vi når RecursiveOdd(5)

                Console.WriteLine($"Returns: {result} for n = {n}");
                return result;

            }

            static int RecursiveEven(int n)
            {
                Console.WriteLine(new String('-', 20));
                Console.WriteLine($"n = {n}, calling RecursiveEven({n - 1})\n");

                if (n == 1)
                {
                    Console.WriteLine("The base case has been reached (n = 1), returning 2\n");
                    return 2;
                }

                int result = RecursiveEven(n - 1) + 2;

                Console.WriteLine($"Returns: {result} for n = {n}");
                return result;
            }

            Console.WriteLine("RecursiveEven(1) = " + RecursiveEven(1));
            Console.WriteLine("RecursiveEven(3) = " + RecursiveEven(3));
            Console.WriteLine("RecursiveEven(5) = " + RecursiveEven(5));

            // Keynote: I Fibonacci-sekvensen är de första två talen alltid definierade som:
            // f(0) = 0
            // f(1) = 1

            // Implementera en rekursiv funktion för att beräkna tal i fibonaccisekvensen: (f(n) = f(n - 1) + f(n - 2))
            // vår sekvens defineras som : f(0) = 0 ----> f(1) = 1 ----> f(n) = f(n-1) + f(n-2) för n > 1

            // Recursive metod
            static int Fibonaci(int n) 
            {
                // CRASH ALERT! OM VI KÖR KODEN UTAN IF-SATSEN SÅ KOMMER DET KRASCHA
                if (n == 0)
                {
                    return 0;
                }
                else if (n == 1)
                {
                    return 1;
                }
                else
                { 
                    return Fibonaci(n - 1) + Fibonaci(n - 2);
                }
            }

            static int FibonaciIteration(int n) 
            {
                if(n == 0)//om n är 0, så får vi tilbaka 0 direkt
                    return 0;

                if(n == 1)// samma här
                    return 1;

                // firstNr och secondNr används för att hålla de två senaste talen i sekvensen, medan currentNr lagrar det aktuella talet
                int firstNr = 0;
                int secondNr = 1;        
                
                int currentNr = 0;

                //Här kör vi en loop för att få fram the n:te fibonacci talet
                for (int i = 2; i < n; i++) 
                {
                    // Det aktuella Fibonacci-talet är summan av de två föregående
                    currentNr = firstNr + secondNr;

                    firstNr = secondNr;
                    secondNr = currentNr;
                }
                return currentNr;
            }

            // Keynote1:
            //          Rekursion och iteration kan verka lika eftersom båda upprepar en operation. Dock har rekursion en extra faktor
            //          att tänka på: STACKMINNE! Varje rekursivt anrop lagras på stacken, och för djupa rekursioner kan detta leda
            //          till stacköverflöd om basfallet inte hanteras ordentligt. 
            // Keynote2:
            //          Iterativa metoder är ofta snabbare än rekursiva metoder, särskilt för större tal, eftersom de undviker upprepade
            //          anrop och potentiella stackproblem.

        }

    }
    }
