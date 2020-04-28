using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3
{
    class Program
    {
        static void Main(string[] args)
        {
            String s,s2="QWERTYUIOPASDFGHJKLZXCVBNM";
            s=Console.ReadLine();
            StringBuilder sb=new StringBuilder();
            sb.Insert(0,s);
            int l=0;
            for (int i=0;i<s.Length;i++)
            {
                char c = sb[i];
                if (Char.IsUpper(c) == true)
                {
                    bool b=s2.Contains(c);
  /*                  for (int j = 0; j < s2.Length; j++)
                    {
                        if (c != s2[j])
                        {
                            l = 0;
                        }
                        else
                        {
                            l = 1;
                            break;
                        }
                                
                        
                    }*/
                    if (b==false) Console.Write(" " + c);
                }
                
            }
            Console.Read();
        }
    }
}
