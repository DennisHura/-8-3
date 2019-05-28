using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace semestr4_praktichna_8_2
{

    public class Person : IComparer
    {
        public string Name;
        public string Familia;
        public string Otchestvo;
        public int year;
        public int ves;

      
        public Person(string Name, string Familia,string Otchestvo,int year, int ves)
        {
            this.Name = Name;
            this.Familia = Familia;
            this.Otchestvo = Otchestvo;
            this.year = year;
            this.ves = ves;
        }

        public void Vivod()
        {
            Console.WriteLine("Фамилия: {0}", Familia);
            Console.WriteLine("Имя: {0}", Name);
            Console.WriteLine("Отчество: {0}", Otchestvo);
            Console.WriteLine("Возраст: {0}", year);
            Console.WriteLine("Вес: {0}", ves);
        }

        int IComparer.Compare(object a, object b)
        {
            Person c1 = (Person)a;
            Person c2 = (Person)b;
            if (c1.year > c2.year)
                return 1;
            if (c1.year < c2.year)
                return -1;
            else
                return 0;
        }

        private class sortYearAscendingHelper : IComparer
        {
            int IComparer.Compare(object a, object b)
            {
                Person c1 = (Person)a;
                Person c2 = (Person)b;

                if (c1.year > c2.year)
                    return 1;

                if (c1.year < c2.year)
                    return -1;

                else
                    return 0;
            }
        }


        public static IComparer sortYearAscending()
        {
            return (IComparer)new sortYearAscendingHelper();
        }
    }

      
    class Program
    {
        static void Main(string[] args)
        {

            StreamReader reader = new StreamReader("input.txt", System.Text.Encoding.Default);

            
            int N = Convert.ToInt32(reader.ReadLine());
            Person[] personData = new Person[N];
           
            for (int i = 0; i < N; i++)
            {
                string[] info = reader.ReadLine().Split(' ');
                personData[i] = new Person(info[0], info[1], info[2], Convert.ToInt32(info[3]), Convert.ToInt32(info[4]));
            }
            


            foreach (Person chelovek in personData)
            {
                    chelovek.Vivod();
                    Console.WriteLine();
            }

            Array.Sort(personData, Person.sortYearAscending());

            Console.WriteLine("\n\nОтсортированый массив по возрасту\n\n\n");
            foreach (Person chelovek in personData)
            {
                chelovek.Vivod();
                Console.WriteLine();
            }
            reader.Close();

        }

    }
}
