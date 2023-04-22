using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proekt
{
    struct proverka
    {
        public string phone;
        public string password;
        public char role;
        public string disciplin;
    }
    struct zachetka
    {
        public string phone;
        public string disciplin;
        public string nomerb;
        public string date;
        public string prepod;
        public int ocenka;
        public void show()
        {
            Console.WriteLine("{0, -15} {1, -15} {2, -15} {3, -15} {4, -15} {5, -15}", phone,disciplin,nomerb,date,prepod,ocenka);
        }
        public string concat()
        {
            return phone + ";" + disciplin + ";" + nomerb + ";" + date + ";" + prepod + ";" + ocenka;
        }
    }
    internal class Авторизация
    {
        proverka[] V = new proverka[1];
        string path = "dann.csv";
        public void Chtenie()
        {
            using (StreamReader br = new StreamReader(path))
            {
                int i = 0;
                while (br.EndOfStream != true)
                {
                    string[] array = br.ReadLine().Split(';');
                    V[i].phone = array[0];
                    V[i].password = array[1];
                    V[i].role = Convert.ToChar(array[2]);
                    V[i].disciplin = array[3];
                    Array.Resize(ref V, V.Length + 1);
                    Console.WriteLine("Телефон: {0}, Пароль: {1}, Роль: {2}\n", V[i].phone, V[i].password, V[i].role);
                    i++;
                }
            }
        }
        public bool Check(string phone, string password, char role)
        {
            for (int i = 0; i <= V.Length - 1; i++)
            {
                if (V[i].phone == phone && V[i].password == password && V[i].role == role)
                {
                    if (role == 'S')
                    {
                        Console.WriteLine("\nДобро пожаловать! Вы вошли как студент\n");
                        return true;
                        break;
                    }
                    else if (role == 'T')
                    {
                        Console.WriteLine("\nДобро пожаловать! Вы вошли как преподаватель\n");
                        return true;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Аккаунта не найден");
                        return false;
                    }
                }
            }
            return false;
        }
        zachetka[] D = new zachetka[1];
        int c = 0;
        string path1 = "zachetka.csv";
        public void Prepodavatel(string phone, string disciplin, string nomerb, string date, string prepod, int ocenka)
        {
            bool pt = false;
            bool st = false;
            for (int i = 0; i <= V.Length - 1; i++)
            {
                if (phone == V[i].phone)
                {
                    pt = true;
                    break;
                }
                else
                {
                    pt = false;
                }
            }
            for (int i = 0; i <= V.Length - 1; i++)
            {
                if (disciplin == V[i].disciplin)
                {
                    st = true;
                    break;
                }
                else
                {
                    st = false;
                }
            }
            if (pt == true)
            {
                if (st == true)
                {
                    D[c].phone = phone;
                    D[c].disciplin = disciplin;
                    D[c].nomerb = nomerb;
                    D[c].date = date;
                    D[c].prepod = prepod;
                    D[c].ocenka = ocenka;
                    Array.Resize(ref D, D.Length + 1);
                    using (StreamWriter wr = new StreamWriter(File.Open(path1, FileMode.Append)))
                    {
                        wr.WriteLineAsync(D[c].phone + ";" + D[c].disciplin + ";" + D[c].nomerb + ";" + D[c].date + ";" + D[c].prepod + ";" + D[c].ocenka);
                    }
                }
                else
                {
                    Console.WriteLine("Вы не закреплены за такой дисциплиной");
                }
            }
            else
            {
                Console.WriteLine("Данный студент не найдет");

            }
        }
        public void Redact(string phone, string disciplin, string date, string dater, string nomerb, int ocenka)
        {
            bool pt = false;
            for (int i = 0; i <= V.Length - 1; i++)
            {
                if (phone == V[i].phone)
                {
                    pt = true;
                    break;
                }
                else
                {
                    pt = false;
                }
            }
            if (pt == true)
            {
                using (StreamReader br = new StreamReader(File.Open(path1, FileMode.Open)))
                {
                    int i = 0;

                    while (br.EndOfStream != true)
                    {
                        string[] array = br.ReadLine().Split(';');
                        D[i].phone = array[0];
                        D[i].disciplin = array[1];
                        D[i].nomerb = array[2];
                        D[i].date = array[3];
                        D[i].prepod = array[4];
                        D[i].ocenka = Convert.ToInt32(array[5]);
                        Array.Resize(ref D, D.Length + 1);
                        i++;
                    }

                }
                bool ps = false;
                for (int i = 0; i < D.Length - 1; i++)
                {
                    if (disciplin == D[i].disciplin && date == D[i].date)
                    {
                        ps = true;
                        break;
                    }
                    else
                    {
                        ps = false;
                    }
                }
                if (ps == true)
                {
                    if (phone == D[c].phone && disciplin == D[c].disciplin && date == D[c].date)
                    {

                        D[c].nomerb = nomerb;
                        D[c].date = dater;
                        D[c].ocenka = ocenka;
                        Array.Resize(ref D, D.Length + 1);
                        using (StreamWriter wr = new StreamWriter(File.Open(path1, FileMode.Append)))
                        {
                            wr.Write(D[c].phone + ";" + D[c].disciplin + ";" + D[c].nomerb + ";" + D[c].date + ";" + D[c].prepod + ";" + D[c].ocenka + "\n");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Данный студент не найден");

            }
        }

        public void Student(string phone)
        {

            using (StreamReader br = new StreamReader(File.Open(path1, FileMode.Open)))
            {
                int i = 0;

                while (br.EndOfStream != true)
                {
                    string[] array = br.ReadLine().Split(';');
                    D[i].phone = array[0];
                    D[i].disciplin = array[1];
                    D[i].nomerb = array[2];
                    D[i].date = array[3];
                    D[i].prepod = array[4];
                    D[i].ocenka = Convert.ToInt32(array[5]);
                    Array.Resize(ref D, D.Length + 1);
                    if (phone == D[i].phone)
                    {
                        Console.WriteLine("Телефон: {0}, Дисциплина: {1}, Номер студенческого билета: {2}, Дата: {3}, Преподаватель: {4}, Оценка: {5}\n", D[i].phone, D[i].disciplin, D[i].nomerb, D[i].date, D[i].prepod, D[i].ocenka);
                    }
                    i++;
                }

            }
        }
    }
}