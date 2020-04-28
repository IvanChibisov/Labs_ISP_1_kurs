using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lr2
{
    class Program
    {
        static void Main(string[] args)
        {
//            string str="qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopaLsdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNMmnbvcxzlkjhgfdsapoiuytrewqQWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnmZXCVBNMASDFGHJKLQWERTYUIOPpoiuytrewqasdfghjklzxcvbnmFTGDSWERTYUJHGFVBxcvb";
            string str = "gdkjghdfkwlsfijILWRJEEOERKTLDSJITRJOSTKRPKSRGOKDFokfjgddklgjdlkfjgklsdhlsfksofdgjkdfhgjkdhfkgdhghdSDJKHKGdkfildjgldjgdljgGJDHJGFJHDFGKsdjhdfghjdhgdkjssdgjhsjkhdghjksdhjkdjgjdlepwwowiiituretuhjnbncjksdksdkjgjkhjskjJSUIGHGUIHSUUIISJSDLJSDfdjjkfksjkgjkdgjsljl";
            System.Random rand=new Random();
            Console.Write("Символов в строке {0} \n",str.Length);
            int r = rand.Next(256),index=r;
            for (int i=0;i<30;i++)
            {
                if (i==0)
                    Console.Write("{0}", str[index]);
                else
                {
                    index += r;
                    //index = index % 256;
                    if (index>=255)
                    {
                        index = index - 255;
                    }
                    Console.Write(" {0}", str[index]);
                }
            }
            Console.Read();
        }
    }
}
