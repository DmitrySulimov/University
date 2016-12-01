using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static lab_2.Programm;

namespace lab_2
{
    public static class Menu
    {
        static Robot Max = new Robot();
        static int s;
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
        private static bool ShowMenu(string message)
        {
            while (true)
            {
                Console.Clear();
            Console.Write(message);
            Console.WriteLine($"{new string('-', 60)}");

            Console.WriteLine(
                  "\nChoose an action:"
                + "\n1. Enable the robot"
                + "\n2. Disable the robot"
                + "\n3. Set the numers of steps"
                + "\n4. Move Up"
                + "\n5. Move Down"
                + "\n6. Move Left"
                + "\n7. Move Right"
                + "\n8. Show last move"
                + "\n9. Show move is side"
                + "\n10. Exit");

            int inputValue;
            bool isInputSuccess = int.TryParse(Console.ReadLine(), out inputValue);

            if (!isInputSuccess)
                continue;

            switch (inputValue)
            {
                case 1:
                    {
                            Max.TurnOn();
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