using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2z
{
    class Program
    {
        static void Main(string[] args)
        {
            String str ;
            Console.Write("Введите число\n");
            str = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            sb.Insert(0,str);
            double a = 0, b = 0 ;
            int k = 0;
            for (int i=0;sb[i]!='.';i++)
            {
                k++;
            }
            int l = 0;
            k--;
            for (int i=k;i>=0;i--)
            {
                a += ((int)sb[i] - '0') * Math.Pow(10, l);
                l++;
            }
            l = k+1;
            k = k + 2;
            for (int i=k;i<sb.Length;i++)
            {
                k++;
            }
            k--;
            int g = 0;
            for (int i=k;i>l;i--)
            {
                b+= ((int)sb[i] - 48) * Math.Pow(10, g);
                g++;
            }
            a += b / Math.Pow(10, k - l);
            Console.Write("Ваше число {0}", a);
            Console.Read();
        }
    }
}
