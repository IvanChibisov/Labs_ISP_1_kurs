using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Z1
{
   
    class Quotient: IComparable<Quotient>,IEquatable<Quotient>
    {
        public int Numerator { get;  set; }
        public int Denominator { get; set; }
        public static int NOD(int a,int b)
        {
            //if (value == 0)
            //{
            //    throw new DivideByZeroException();
            //}

            a = Math.Abs(a);
            b = Math.Abs(b);
            while (a*b!=0)
            {
                if (a >= b)
                    a = a % b;
                else
                    b = b % a;
            }
            return a + b;
        }
        
        public static int NOK(int a,int b)
        {
            int nod = NOD(a, b);
            return (a * b) / nod;
        }
        public int CompareTo(Quotient other)
        {
            return this.Numerator * other.Denominator - other.Numerator * this.Denominator;
        }
        public bool Equals(Quotient other)
        {
             return this.CompareTo(other) == 0;
        }
        public override string ToString()
        {
            int nod = NOD(Numerator, Denominator);
            Numerator = Numerator / nod;
            Denominator = Denominator / nod;
            if (Denominator < 0)
            {
                Numerator = -1 * Numerator;
                Denominator = Math.Abs(Denominator);
            }
            return String.Format("{0}/{1}", Numerator, Denominator);
        }
        public string ToDoubleString()
        {
            double k = (double)Numerator / (double)Denominator;
            return String.Format("{0}", k);
        }
        public static Quotient operator *(Quotient a, Quotient b)
        {
            int NewNumerator = a.Numerator * b.Numerator;
            int NewDenominator = a.Denominator * b.Denominator;
            int nod = NOD(NewNumerator, NewDenominator);
            NewNumerator = NewNumerator / nod;
            NewDenominator = NewDenominator / nod;
            return new Quotient { Numerator=NewNumerator, Denominator=NewDenominator };
        }
        public static Quotient operator /(Quotient a, Quotient b)
        {
            int NewNumerator = a.Numerator * b.Denominator;
            int NewDenominator = a.Denominator * b.Numerator;
            int nod = NOD(NewNumerator, NewDenominator);
            NewNumerator = NewNumerator / nod;
            NewDenominator = NewDenominator / nod;
            return new Quotient { Numerator = NewNumerator, Denominator =  NewDenominator};
        }
        public static Quotient operator +(Quotient a,Quotient b)
        {
            int NewNumeratorA, NewNumeratorB,NewDenominator;
            int nok = NOK(a.Denominator, b.Denominator);
            int k1 = nok / a.Denominator;
            int k2 = nok / b.Denominator;
            NewDenominator = nok;
            NewNumeratorA = a.Numerator * k1;
            NewNumeratorB = b.Numerator * k2;
            int NewNumerator = NewNumeratorA + NewNumeratorB;
            return new Quotient { Numerator = NewNumerator, Denominator = NewDenominator };
        }
        public static Quotient operator -(Quotient a, Quotient b)
        {
            int NewNumeratorA, NewNumeratorB, NewDenominator;
            int nok = NOK(a.Denominator, b.Denominator);
            int k1 = nok / a.Denominator;
            int k2 = nok / b.Denominator;
            NewDenominator = nok;
            NewNumeratorA = a.Numerator * k1;
            NewNumeratorB = b.Numerator * k2;
            int NewNumerator = NewNumeratorA - NewNumeratorB;
            return new Quotient { Numerator = NewNumerator, Denominator = NewDenominator };
        }
        public static bool operator >(Quotient a,Quotient b)
        {
            return a.CompareTo(b)>0;
        }
        public static bool operator <(Quotient a, Quotient b)
        {
            int NewNumeratorA, NewNumeratorB, NewDenominator;
            int nok = NOK(a.Denominator, b.Denominator);
            int k1 = nok / a.Denominator;
            int k2 = nok / b.Denominator;
            NewDenominator = nok;
            NewNumeratorA = a.Numerator * k1;
            NewNumeratorB = b.Numerator * k2;
            if (NewNumeratorA < NewNumeratorB)
                return true;
            else
                return false;
        }
        public static bool operator ==(Quotient a, Quotient b)
        {
            int NewNumeratorA, NewNumeratorB, NewDenominator;
            int nok = NOK(a.Denominator, b.Denominator);
            int k1 = nok / a.Denominator;
            int k2 = nok / b.Denominator;
            NewDenominator = nok;
            NewNumeratorA = a.Numerator * k1;
            NewNumeratorB = b.Numerator * k2;
            if (NewNumeratorA == NewNumeratorB)
                return true;
            else
                return false;
        }
        public static bool operator !=(Quotient a, Quotient b)
        {
            int NewNumeratorA, NewNumeratorB, NewDenominator;
            int nok = NOK(a.Denominator, b.Denominator);
            int k1 = nok / a.Denominator;
            int k2 = nok / b.Denominator;
            NewDenominator = nok;
            NewNumeratorA = a.Numerator * k1;
            NewNumeratorB = b.Numerator * k2;
            if (NewNumeratorA != NewNumeratorB)
                return true;
            else
                return false;
        }
        public static bool operator >=(Quotient a, Quotient b)
        {
            int NewNumeratorA, NewNumeratorB, NewDenominator;
            int nok = NOK(a.Denominator, b.Denominator);
            int k1 = nok / a.Denominator;
            int k2 = nok / b.Denominator;
            NewDenominator = nok;
            NewNumeratorA = a.Numerator * k1;
            NewNumeratorB = b.Numerator * k2;
            if (NewNumeratorA >= NewNumeratorB)
                return true;
            else
                return false;
        }
        public static bool operator <=(Quotient a, Quotient b)
        {
            int NewNumeratorA, NewNumeratorB, NewDenominator;
            int nok = NOK(a.Denominator, b.Denominator);
            int k1 = nok / a.Denominator;
            int k2 = nok / b.Denominator;
            NewDenominator = nok;
            NewNumeratorA = a.Numerator * k1;
            NewNumeratorB = b.Numerator * k2;
            if (NewNumeratorA <= NewNumeratorB)
                return true;
            else
                return false;
        }
        public static explicit operator Quotient(double x)
        {
            int cX = (int)x;
            double dr = 1;
            int osn = 1 ;
            dr = x - cX;
            while (dr!=0)
            {
                x = x * 10;
                cX = (int)x;
                dr = x - cX;
                osn = osn * 10;
            }
            return new Quotient { Numerator = (int)x, Denominator = osn };
        }
        public static explicit operator double(Quotient x)
        {
            return (double)(x.Numerator) / (double)(x.Denominator);
        }
        public static implicit operator int(Quotient x)
        {
            return (int)(x.Numerator / x.Denominator);
        }

    }
    class Program
    {
        static void Sort<T>(T[] objects) where T : IComparable<T>
        {

            for (int i = 0; i < objects.Length; i++)
                for (int j = i; j < objects.Length; j++)
                {
                    if (objects[i].CompareTo(objects[j]) > 0)
                    {
                        T time = objects[i];
                        objects[i] = objects[j];
                        objects[j] = time;
                    }

                }
        }
        static void Main(string[] args)
        {

            //new Quotient(14, 12);
            var p1 = new Quotient { Numerator = 14, Denominator = 12 };

            //p1 = p1 + 4;

            var p2 = new Quotient { Numerator = 11, Denominator = 12 };
            Console.WriteLine("p1 = " + p1);
            Console.WriteLine("p1 = " + p1.ToDoubleString());
            Console.WriteLine("p2 = " + p2);
            Console.WriteLine("p1/p2 = " + p1 / p2);
            Console.WriteLine("p1*p2 = " + p1 * p2);
            Console.WriteLine("p1+p2 = " + (p1 + p2));
            Console.WriteLine("p1-p2 = " + (p1 - p2));
            if (p1 > p2)
                Console.WriteLine("Bigger is " + p1);
            if (p1 < p2)
                Console.WriteLine("Bigger is " + p2);
            if (p1 == p2)
                Console.WriteLine("They Equals");
            if (p1 != p2)
                Console.WriteLine("They dont Equals");
            double d1 = (double)p1;
            double d2;
            d2 = 10.3;
            p2 = (Quotient)d2;
            int i1 = p1;
            Console.WriteLine("{1} = {0}", d1, p1);
            Console.WriteLine("{1} = {0}", i1, p1);
            Console.WriteLine("10.3 = {0}", p2);

            double EnterDouble;
            Console.WriteLine("Enter the number in format a,a1a2a3");
            try
            {
                EnterDouble = Convert.ToDouble(Console.ReadLine());


                Quotient p3 = new Quotient { };
                p3 = (Quotient)EnterDouble;
                Console.WriteLine("p3 = " + p3);
                Console.WriteLine("p3 = " + p3.ToDoubleString());
            }
            catch (FormatException)
            {
                Console.WriteLine("Error format!");
            }
            try
            {
                Console.WriteLine("Enter the number in format a/b");
                string Str = Console.ReadLine();
                int a = 0, b = 1;
                string str = null;
                for (int i = 0; i < Str.Length; i++)
                {
                    if (Str[i] == '/')
                    {
                        a = Convert.ToInt32(str);
                        str = null;
                        continue;
                    }
                    str = str + Str[i];
                }
                b = Convert.ToInt32(str);
                if (b == 0)
                {
                    Console.WriteLine("0 is invalid Denominator");
                }
                else
                {
                    Quotient p4 = new Quotient { Numerator = a, Denominator = b };
                    Console.WriteLine("p4 = " + p4);
                    Console.WriteLine("p4 = " + p4.ToDoubleString());
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error format!");
            }
            Console.WriteLine("Sorted array:");
            Quotient[] Arr = new Quotient[5];
            Arr[0] = new Quotient { Numerator = 10, Denominator = 3 };
            Arr[1] = new Quotient { Numerator = 1, Denominator = 15 };
            Arr[2] = new Quotient { Numerator = 10, Denominator = 32 };
            Arr[3] = new Quotient { Numerator = 9, Denominator = 8 };
            Arr[4] = new Quotient { Numerator = 131, Denominator = 132 };
            Sort<Quotient>(Arr);
            for (int i=0;i<5;i++)
            {
                Console.WriteLine(Arr[i]+" = "+Arr[i].ToDoubleString());
            }
            Console.Read();
        }
    }
}
