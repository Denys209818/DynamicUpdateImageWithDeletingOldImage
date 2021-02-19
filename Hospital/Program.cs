using Hospital.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text;

namespace Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            //DepatmentCRUD();
            int action = 0;
            MyContext context = new MyContext();
            do
            {
                Console.WriteLine("0. Вихід");
                Console.WriteLine("1. Показти всіх");
                
                action = int.Parse(Console.ReadLine());
                switch (action)
                {
                    case 1:
                        {
                            foreach (var item in context.Doctors.Include(x=>x.Department))
                            {
                                Console.WriteLine($"{item.Id} {item.LastName} {item.FirstName} - " +
                                    $"{item.Stage} - {item.Department.Name}");
                            }
                            break;
                        }
                   
                }
            } while (action != 0);

            //Console.WriteLine("Add id = {0}", d.Id);

        }

        static void DepatmentCRUD()
        {
            int action = 0;
            MyContext context = new MyContext();
            do
            {
                Console.WriteLine("0. Вихід");
                Console.WriteLine("1. Показти всіх");
                Console.WriteLine("2. Додати");
                Console.WriteLine("3. Видалити");
                Console.WriteLine("4. Редагувати");
                Console.WriteLine("5. Пошук");
                action = int.Parse(Console.ReadLine());
                switch (action)
                {
                    case 1:
                        {
                            foreach (var item in context.Departments)
                            {
                                Console.WriteLine($"{item.Id} {item.Name} - {item.NumberCabinet}");
                            }
                            break;
                        }
                    case 2:
                        {
                            Department d = new Department();
                            Console.WriteLine("Назва віділа:");
                            d.Name = Console.ReadLine();
                            context.Departments.Add(d);
                            Console.WriteLine("Введіть номер будівлі:");
                            d.NumberCabinet = int.Parse(Console.ReadLine());
                            context.SaveChanges();
                            break;
                        }
                    case 3:
                        {

                            Console.WriteLine("Введіть id:");
                            int id = int.Parse(Console.ReadLine());
                            Department d = context.Departments
                                .SingleOrDefault(x => x.Id == id);
                            context.Departments.Remove(d);
                            context.SaveChanges();
                            Console.WriteLine("-------Успішно видалено------");
                            break;
                        }
                    case 4:
                        {

                            Console.WriteLine("Введіть id:");
                            int id = int.Parse(Console.ReadLine());
                            Department d = context.Departments
                                .SingleOrDefault(x => x.Id == id);
                            Console.WriteLine("Введіть нову назву:");
                            d.Name = Console.ReadLine();
                            context.SaveChanges();
                            Console.WriteLine("-------Успішно видалено------");
                            break;
                        }
                    case 5:
                        {
                            string temp = string.Empty;
                            var query = context.Departments.AsQueryable();
                            Console.WriteLine("Назва віділа:");
                            temp = Console.ReadLine();
                            if (!string.IsNullOrEmpty(temp))
                                query = query.Where(x => x.Name.Contains(temp));

                            Console.WriteLine("Введіть номер будівлі:");
                            string numbertemp = Console.ReadLine();
                            if (!string.IsNullOrEmpty(numbertemp))
                            {
                                int number = int.Parse(numbertemp);
                                query = query.Where(x => x.NumberCabinet == number);
                            }
                            foreach (var item in query.ToList())
                            {
                                Console.WriteLine($"{item.Id} {item.Name} - {item.NumberCabinet}");
                            }
                            break;
                        }
                }
            } while (action != 0);
        }
    }
}
