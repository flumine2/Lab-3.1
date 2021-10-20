using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1st_Block
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new();
            program.Generator();
            try
            {
                using (StreamWriter no_file = new("no_file.txt"))
                {
                    try
                    {
                        using (StreamWriter bad_data = new("bad_data.txt"))
                        {
                            try
                            {
                                using (StreamWriter overflow = new("overflow.txt"))
                                {
                                    for (int i = 0; i < 20; i++)
                                    {
                                        program.Cheker(i + 10, no_file, bad_data, overflow);
                                    }
                                }
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Can`t create file \"overflow.txt\"");
                                throw;
                            }
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Can`t create file \"bad_data.txt\"");
                        throw;
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Can`t create file \"no_file.txt\"");
                throw;
            }
        }

        void Cheker(int num, StreamWriter no_file, StreamWriter bad_data, StreamWriter overflow) 
        {
            try
            {
                using (StreamReader sr = new($"{num}.txt"))
                {
                    try
                    {
                        int num1 = int.Parse(sr.ReadLine());
                        int num2 = int.Parse(sr.ReadLine());
                        try
                        {
                            int sum = checked(num1 * num2);
                            Console.WriteLine(sum);
                        }
                        catch (Exception)
                        {
                            overflow.WriteLine($"{num}.txt");
                        }
                    }
                    catch (Exception)
                    {
                        bad_data.WriteLine($"{num}.txt");
                    }
                }
            }
            catch (Exception)
            {
                no_file.WriteLine($"{num}.txt");
            }           
        }

        public void Generator()
        {
            Random random = new();
            HashSet<int> hs = new();
            for (int i = 0; i < 5; i++)
            {
                hs.Add(random.Next(10,30));
            }
            for (int i = 0; i < 20; i++)
            {
                if (hs.Contains(i + 10))
                {
                    continue;
                }
                else
                {
                    using (StreamWriter sw = new($"{i + 10}.txt"))
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            sw.WriteLine((long)(random.Next(-2147483648, 2147483647) + random.Next(-2147483648, 2147483647)));
                        }
                    }
                }
            }
        }
    }
}
