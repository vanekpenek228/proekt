using System;

namespace proekt
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Учебная группа");
            Console.WriteLine("Приложение преднозначено для студентов и преподователей, студент имеет возможность просмотра своих сданных работ, преподователь может изменять данные зачетных работ\n");
            bool gg = true;
            while (gg == true)
            {
                Авторизация V = new Авторизация();
                V.Chtenie();
                Console.WriteLine("Введите номер телефона: ");
                string phone = Console.ReadLine();
                Console.WriteLine("Введите пароль: ");
                string password = Console.ReadLine();
                Console.WriteLine("Введите роль: ");
                char role = Convert.ToChar(Console.ReadLine());
                if (V.Check(phone, password, role) == true)
                {
                    if (role == 'T')
                    {
                        Console.WriteLine("Выберете одно из действий:\n1 - Заполнить данные зачетки студента\n2 - Изменить данные зачетки студента\n3 - Посмотреть зачетки всех студентов");
                        int number = Convert.ToInt32(Console.ReadLine());
                        if (number == 1)
                        {


                            Console.WriteLine("Введите номер телефона студента: ");
                            string tel = Console.ReadLine();
                            Console.WriteLine("Введите дисциплину: ");
                            string dis = Console.ReadLine();
                            Console.WriteLine("Введите студенческий билет: ");
                            string bil = Console.ReadLine();
                            Console.WriteLine("Введите дату сдачи: ");
                            string date = Console.ReadLine();
                            Console.WriteLine("Введите своё ФИО: ");
                            string name = Console.ReadLine();
                            Console.WriteLine("Поставьте оценку: ");
                            int oc = Convert.ToInt32(Console.ReadLine());
                            V.Prepodavatel(tel, dis, bil, date, name, oc);
                        }
                        else if (number == 2)
                        {
                            Console.WriteLine("Введите номер студента: ");
                            string ph = Console.ReadLine();
                            Console.WriteLine("Введите дисциплину: ");
                            string ds = Console.ReadLine();
                            Console.WriteLine("Введите дату: ");
                            string dt = Console.ReadLine();
                            V.Student(ph);
                            Console.WriteLine("Введите студенческий билет: ");
                            string fm = Console.ReadLine();
                            Console.WriteLine("Поставте новую дату сдачи: ");
                            string dtr = Console.ReadLine();
                            Console.WriteLine("Поставьте новую оценку: ");
                            int m = Convert.ToInt32(Console.ReadLine());
                            V.Redact(ph, ds, dt, dtr, fm, m);
                        }
                        else if (number == 3)
                        {
                            List<zachetka> users = new List<zachetka>();
                            string Path = "zachetka.csv";
                            getData(Path, users);
                            printData(users);
                        }

                        else
                        {
                            Console.WriteLine("Такого действия нет");
                        }
                    }
                    if (role == 'S')
                    {
                        V.Student(phone);
                    }
                }

                static void getData(string path, List<zachetka> L)
                {

                    using (StreamReader sr = new StreamReader(path))
                    {
                        while (sr.EndOfStream != true)
                        {
                            string[] array = sr.ReadLine().Split(';');
                            L.Add(new zachetka()
                            {
                            phone = array[0],
                            disciplin = array[1],
                            nomerb = array[2],
                            date = array[3],
                            prepod = array[4],
                            ocenka = Convert.ToInt32(array[5]),
                        });
                        }
                    }
                }
                static void printData(List<zachetka> L)
                {
                    foreach (zachetka u in L)
                    {
                        u.show();
                    }
                }

                Console.WriteLine("Хотите продолжить работу? Yes/No");
                string s = Console.ReadLine();
                if (s == "No")
                {
                    gg = false;
                }
            }
        }
    }
}
