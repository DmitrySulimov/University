using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyStructure
{
    public class Menu
    {
        

        public static void StartDialog()

        {
            


            var message = "\n";
            while (true)
            {
                try
                {
                    bool result = ShowMenu(message);
                    if (result)
                    {
                        return;
                    }
                }
                catch (Exception ex)
                {
                    message = ex.Message + "\n";
                }
            }
        }
        public static bool ShowMenu(string message)
        {
            while (true)
            {
                Console.Clear();
                Console.Write(message);
                Console.WriteLine($"{new string('-', 60)}");

                Console.WriteLine(
                      "\nChoose an action:"
                    + "\n1. Add employee"
                    + "\n2. Create Employee"
                    + "\n3. Get Employee"
                    + "\n4. Add supervisor"
                    + "\n5. Get employee with salary"
                    + "\n6. Get employee with supervizor"
                    + "\n70. Exit");

                int inputValue;
                bool isInputSuccess = int.TryParse(Console.ReadLine(), out inputValue);

                if (!isInputSuccess)
                    continue;

                switch (inputValue)
                {
                    case 1:
                        {
                            
                            break;
                        }
                    case 2:
                        {
                            Max.TurnOff();
                            break;
                        }
                    case 3:
                        {
                            Console.Write("\n Set the numers of steps: ");
                            s = Convert.ToInt16(Console.ReadLine());
                            break;
                        }
                    case 4:
                        {
                            Max.Move(s, Direction.Up);
                            break;
                        }
                    case 5:
                        {
                            Max.Move(s, Direction.Down);
                            break;
                        }
                    case 6:
                        {
                            Max.Move(s, Direction.Left);
                            break;
                        }
                    case 7:
                        {
                            Max.Move(s, Direction.Right);
                            break;
                        }
                    case 8:
                        {
                            Max.lastMove();
                            Console.ReadLine();
                            break;
                        }
                    case 9:
                        {
                            Max.moveInSide();
                            Console.ReadLine();
                            break;
                        }
                    case 10:
                        {
                            return true;
                        }
                    default:
                        {
                            continue;
                        }
                }
            }
        }
    }
}
