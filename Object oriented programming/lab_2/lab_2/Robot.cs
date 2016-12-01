using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2
{
    enum Direction
    {
        Up, Down, Left, Right
    }

    class Programm
    {
        //private static Direction direction;
        static void Main(string[] args)
        {
            Menu.StartDialog();
            //bool y;
            //Console.WriteLine("Включен ли робот? True/False");
            //y = Convert.ToBoolean(Console.ReadLine());
            //if (y == true) Max.TurnOn();
            //else Max.TurnOff();
            //Console.WriteLine("Введите число шагов");
            //int s = Convert.ToInt16(Console.ReadLine());
            //Console.WriteLine("Введите сторону");
            //int side = Convert.ToInt32(Console.ReadLine());
            //if (side == 0)
            //{
            //    direction = Direction.Up;
            //}
            //else if (side == 1)
            //{
            //    direction = Direction.Down;
            //}
            //else if (side == 2)
            //{
            //    direction = Direction.Left;
            //}
            //else if (side == 3)
            //{
            //    direction = Direction.Right;
            //}

            //Max.Move(s, direction);
            //Max.lastMove();
            //Max.moveInSide();
            Console.Clear();
            Console.WriteLine("Click any button to exit...");
            Console.ReadKey();
        }

        public class Robot
        {


        private bool isWork;

        private int step_x;

        private int step_y;

        public bool IsWork
        {
            get
            {
                return isWork;
            }
        }
        public void TurnOn()
        {
            if (isWork)
            {
                throw new InvalidOperationException("Робот уже включен");
            }
            isWork = true;
        }

        public void TurnOff()
        {
            if (!isWork)
            {
                throw new InvalidOperationException("Робот уже выключен");
            }
            isWork = false;
        }

        public int Step_x
        {
            get
            {
                return step_x;
            }
            private set
            {
                if(value < 0 || value > 100)
                {
                    throw new ArgumentOutOfRangeException("Робот вышел за гранницы комнаты");
                }
                step_x = value;
            }
        }

        public int Step_y
        {
            get
            {
                return step_y;
            }
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentOutOfRangeException("Робот вышел за гранницы комнаты");
                }
                step_y = value;
            }
        }

        private int stepsInSide;
        private Direction lastDirection;
        private int laststepsCount;

        public void Move(int stepsCount, Direction direction)
        {
            if (direction == Direction.Up)
            {
                if (lastDirection == direction) throw new ArgumentException("Робот не может снова идти в эту сторону");

                Step_y = Step_y + stepsCount;

                lastDirection = direction;
                laststepsCount = stepsCount;
                    stepsInSide = Step_y;
            }

            else if (direction == Direction.Down)
            {
                if (lastDirection == direction) throw new ArgumentException("Робот не может снова идти в эту сторону");

                Step_y = Step_y - stepsCount;

                lastDirection = direction;
                laststepsCount = stepsCount;
                    stepsInSide = Step_y;
            }

            else if (direction == Direction.Left)
            {
                if (lastDirection == direction) throw new ArgumentException("Робот не может снова идти в эту сторону");

                Step_x = Step_x - stepsCount;

                lastDirection = direction;
                laststepsCount = stepsCount;
                    stepsInSide = Step_x;
            }
            else if (direction == Direction.Right)
            {
                if (lastDirection == direction) throw new ArgumentException("Робот не может снова идти в эту сторону");

                Step_x = Step_x + stepsCount;

                lastDirection = direction;
                laststepsCount = stepsCount;
                    stepsInSide = Step_x;
            }
        }

        public void lastMove()
        {
            Console.WriteLine("Последний ход робота: {0}, {1}", laststepsCount, lastDirection);
        }

 public void moveInSide()
        {
            
            Console.WriteLine("Сделал шагов в сторону: {0}", stepsInSide);
        }
        }
    }
}



