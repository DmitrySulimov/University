using System;
using System.Linq;

using CompanyStructure.Model;

namespace CompanyStructure
{
    public class Menu
    {
        private readonly CompanyStructureBuilder companyBuilder = new CompanyStructureBuilder();

        public void StartDialog()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Лабораторная работа №3 Сулимов Дмитрий");

                Console.WriteLine("Выберите действие:" +
                                  "\n1. Отобразить структуру компании" +
                                  "\n2. Добавить новую должность" +
                                  "\n3. Добавить нового сотрудника" +
                                  "\n4. Получить сотрудника по идентификатору" +
                                  "\n5. Получить сотрудников с зарплатой больше чем..." +
                                  "\n6. Потучить сотрудников с заданым супервайзером");

                int result;
                int.TryParse(Console.ReadLine(), out result);

                switch (result)
                {
                    case 1:
                        {
                            ShowCompanyStructure();
                            break;
                        }
                    case 2:
                        {
                            Console.Write("Введите название должности: ");
                            companyBuilder.AddPosition(Console.ReadLine());
                            break;
                        }
                    case 3:
                        {
                            Console.Write("Введите имя сотрудника: ");
                            string name = Console.ReadLine();

                            Console.Write("Введите фамилию сотрудника: ");
                            string surname = Console.ReadLine();

                            Console.Write("Введите уникальй идентификатор сотрудника: ");
                            string id = Console.ReadLine();

                            if (companyBuilder.EmployeesList.Exists(p => p.Id == id))
                            {
                                Console.WriteLine("Неправильный идентификатор");
                                break;
                            }

                            Console.Write("Введите оклад сотрудника: ");
                            double salary;
                            bool isSuccess = double.TryParse(Console.ReadLine(), out salary);
                            if (!isSuccess)
                            {
                                Console.WriteLine("Неправильное число");
                                break;
                            }

                            Console.Write("Введите должность сотрудника: ");
                            string position = Console.ReadLine();
                            if (!companyBuilder.Position.Contains(position))
                            {
                                Console.WriteLine("В компании нету такой должности");
                                break;
                            }

                            Employee employee = new Employee(name, surname, id, position, salary);

                            Console.Write("Введите идентификатор супервайзера (оставьте пустым, если не нужно назначать: ");
                            string superviserId = Console.ReadLine();

                            if (!string.IsNullOrWhiteSpace(superviserId))
                            {
                                Employee supervisor = companyBuilder.EmployeesList.FirstOrDefault(p => p.Id == superviserId);
                                if (supervisor == null)
                                {
                                    Console.WriteLine("В компании нету сотрудника с таким идентификатором");
                                }
                                else
                                {
                                    companyBuilder.AddSupervisor(employee, supervisor);
                                }
                            }

                            companyBuilder.AddEmployee(employee);
                            Console.WriteLine("Сотрудник был успешно добавлен");


                            break;
                        }
                    case 4:
                        {
                            Console.Write("Введите идентификатор сотрудника: ");
                            string id = Console.ReadLine();

                            Employee employee = companyBuilder.EmployeesList.FirstOrDefault(p => p.Id == id);

                            if (employee == null)
                            {
                                Console.WriteLine("Сотрудник с таким идентификатором не существует");
                            }
                            else
                            {
                                Console.WriteLine(employee.ToString());
                            }
                            break;
                        }
                    case 5:
                        {
                            Console.Write("Введите оклад сотрудника: ");
                            double salary;
                            bool isSuccess = double.TryParse(Console.ReadLine(), out salary);
                            if (!isSuccess)
                            {
                                Console.WriteLine("Неправильное число");
                                break;
                            }

                            var employees = companyBuilder.GetEmployeeByWithMoreSalary(salary);
                            foreach (var employee in employees)
                            {
                                Console.WriteLine(employee.ToString());
                            }
                            break;
                        }
                    case 6:
                        {
                            Console.Write("Введите идентификатор сотрудника: ");
                            string id = Console.ReadLine();

                            Employee supervisor = companyBuilder.EmployeesList.FirstOrDefault(p => p.Id == id);

                            if (supervisor == null)
                            {
                                Console.WriteLine("Сотрудник с таким идентификатором не существует");
                            }
                            else
                            {
                                var employees = companyBuilder.GetEmployeeBySupervisor(supervisor);
                                foreach (var employee in employees)
                                {
                                    Console.WriteLine(employee.ToString());
                                }
                            }

                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Неправильный ввод");
                            break;
                        }
                }

                Console.WriteLine("\nНажмите любую клавишу чтобы продолжить...");
                Console.ReadKey();
            }
        }

        private void ShowCompanyStructure()
        {
            Console.WriteLine("Выбирете вариант отображения: " +
                              "\n1. По прямому подчинению" +
                              "\n2. По высоте позиции в компании");

            int result;
            int.TryParse(Console.ReadLine(), out result);

            switch (result)
            {
                case 1:
                    {
                        string output = companyBuilder.GetCompanyStructure(StructureFormat.OnDirectSubmission);
                        Console.WriteLine(output);
                        break;
                    }
                case 2:
                    {
                        string output = companyBuilder.GetCompanyStructure(StructureFormat.OnHeightPosition);
                        Console.WriteLine(output);
                        break;
                    }

                default:
                    {
                        Console.WriteLine("Неправильный ввод");
                        break;
                    }
            }
        }
    }
}
