using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace z1
{
    public delegate void ErrorNull(int val);
    public interface IType
        {
            void Type();
        }
    abstract class Transport : IComparable<Transport>
    {
         private float weight;
         private float speed;
         public float WeightStruct
         { 
             get
            { return weight; }
            set
            {
                if (value > 0) weight = value;
                else
                {
                    weight = 0;
                    ThisNull?.Invoke((int)value);
                }
            }
         }  
         public float SpeedStruct
         {
             get
             { return speed; }
             set
             {
                 if (value > 0) speed = value;
                 else
                 {
                     speed = 0;
                     ThisNull?.Invoke((int)value);
                 }
             }
            }
        public event ErrorNull ThisNull;
        
        public float Weight
        {
            get
            { return WeightStruct; }
            set
            {
                WeightStruct = value;
            }
        }       
        public float Speed
        {
            get
            { return SpeedStruct; }
            set
            {
                SpeedStruct = value;
            }
        }
        public Transport(float Sp = 60, float W = 3)
        {
            speed = Sp;
            weight = W;
        }
        public int Time(int Distance)
        {
            try
            {
                return Distance / (int)SpeedStruct;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Скорость равна 0, а на 0 нельзя делить!");
                return 0;
            }
        }
        public float Time(double Distance)
        {
            try
            {
                return (float)Distance / SpeedStruct;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Скорость равна 0, а на 0 нельзя делить!");
                return 0;
            }
        }
        public float SetWeight()
        {
            return Weight;
        }

        public int CompareTo(Transport other)
        {
            if (other.Weight > this.Weight) return 1;
            if (other.Weight < this.Weight) return -1;
            if (other.Weight==this.Weight)
            {
                if (other.Speed > this.Speed) return 1;
                if (other.Speed < this.Speed) return -1;
                if (other.Speed == this.Speed) return 0;
            }
            return 0;
        }
    };
    class Auto : Transport,IType, IComparable<Auto>
    {
        private int[] wheel;
        public int this[int index]
        {
            get
            { return wheel[index]; }
            set
            {
                if (value >= 0) wheel[index]=value;
                else
                {
                    wheel = new int [0];
                    Console.Write("Недопустимое кол-во колес\n");
                }
            }
        }
        public int CompareTo(Auto other)
        {
            
            if (other.Weight > this.Weight) return 1;
            if (other.Weight < this.Weight) return -1;
            if (other.Weight == this.Weight)
            {
                if (other.Speed > this.Speed) return 1;
                if (other.Speed < this.Speed) return -1;
                if (other.Speed == this.Speed)
                {
                    if (other.Wheel > this.Wheel) return 1;
                    if (other.Wheel < this.Wheel) return -1;
                    if (other.Wheel == this.Wheel) return 0;
                }
            }
            return 0;
        }
        public virtual void Type()
        {
            Console.WriteLine("Это атомобиль");
        }
        public int Wheel
        {
            get
            {
                return wheel.Length;
            }
            set
            {
                if (value > 0) wheel = new int [value];
                else
                {
                    wheel = new int[0];
                    Console.Write("Недопустимое кол-во колес\n");
                }
            }
        }
        public Auto(int Wh = 4, float Sp = 60, float W = 3) : base(Sp , W )
        {
            wheel = new int[Wh];
        }
        public float WeightOnWheel()
        {
            try
            {
                return SetWeight() / wheel.Length;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Длинна равна 0, а на 0 нельзя делить!");
                return 0;
            }
            
        }
    };
    class Carbrand : Auto, IEquatable<Carbrand>, IComparable<Carbrand>
    {

        private static int index = 0;
        
        public delegate void ThisRussia();
        public event ThisRussia Event1;
        public event ThisRussia Event2;
        public static int Index()
        {
            return index;
        }
        public enum EModel { Volkswagen,LADA, BMW, Ferrari, Mercedes,Citroen,MTZ}
        private String land_producer;
        private String model;
        public String LandProducer
        {
            get
            { return land_producer; }
            set
            {
                
                land_producer = value;
            }
        }
        public override void Type()
        {
            Console.WriteLine("Это автомобиль марки " + model);
        }
        public bool Equals(Carbrand car)
        {
            if (car == null)
                return false;

            if (car.LandProducer == "Russia")
                Event1?.Invoke();
            else Event2?.Invoke();
            return (car.LandProducer == "Russia" );

        }
        public String Model
        {
            get
            { return model; }
            set
            { model = value; }
        }
        public Carbrand(int Wh = 4, float Sp = 60, float W = 3, String L = "Germany", String M = "Volkswagen") : base(Wh , Sp, W )
        {
            LandProducer = L;
            Model = M;
            index++;
        }
        public int CompareTo(Carbrand other)
        {
            int result;

            result = other.Weight.CompareTo(this.Weight);
            if (result != 0) return result;
            result = other.Speed.CompareTo(this.Speed);
            if (result != 0) return result;
            result = other.LandProducer.CompareTo(this.LandProducer);
            return result;
        }
    };

    class Program
    {
        public delegate int Transformer(int x);
        public static int Transform(Transformer f, int x)
        {
            return f(x);
        }
        public static void Reaktion(int k)
        {
            Console.WriteLine("Неверный ввод, Negative value {0}",k);
        }
        static void Sort<T>( T[] objects) where T : IComparable<T>
        {

            for (int i = 0; i < objects.Length; i++)
                for (int j = i; j < objects.Length; j++)
                {
                    if (objects[i].CompareTo(objects[j]) == 1)
                    {
                        T time = objects[i];
                        objects[i] = objects[j];
                        objects[j] = time;
                    }

                }
        }
        static void Main(string[] args)
        {
            Transformer g = x => x * x;
            int y = 10;
            y = Transform(g, y);
            Console.WriteLine("{0}", y);
            Carbrand[] cars= new Carbrand[5];
            cars[0] = new Carbrand(4, 60, 4, "Russia", "LADA");
            cars[1] = new Carbrand(5, 70, 3, "Japan", "Citroen");
            cars[2] = new Carbrand(4, 100,2, "Germany", "Mercedes");
            cars[3] = new Carbrand(6, 30, 10, "Belarus", "MTZ");
            cars[4] = new Carbrand(8, 90, 10, "Germany", "Volkswagen");
            Sort<Carbrand>(cars);
            for (int i=0; i<cars.Length;i++)
            {
                Console.WriteLine("{1} {0} {2} " + cars[i].LandProducer + " " + cars[i].Model, cars[i].Speed, cars[i].Weight, cars[i].Wheel);
            }
            int n,l;
            Auto transport;
            
            transport = new Auto();
            transport.ThisNull += x => { Console.WriteLine("Неверный ввод, Negative or NULL value {0}", x); } ;
            Carbrand car;
            car = new Carbrand();
            car.ThisNull += delegate (int x) { Console.WriteLine("Неверный ввод, Negative or NULL value {0}", x); };
            car.Event1 += () => { Console.WriteLine("В России!\n"); };
            car.Event2 +=  () => { Console.WriteLine("Не в России!\n"); };
            int k = 1;
            while (k == 1)
            {
                k = 0;
                Console.WriteLine("Выберите с чем работать \n 1.Автомобиль.\n 2.Автомобильный бренд.");
                l = Convert.ToInt32(Console.ReadLine());
                if (l == 1)
                {
                    k = 1;
                    transport.Type();
                    while (k == 1)
                    {
                        k = 0;
                        
                        Console.Write("Введите \n 1 для повтора ввода(изменения) \n 2 для показа данных\n 3 для расчета времени пути\n");
                        n = Convert.ToInt32(Console.ReadLine());
                        switch (n)
                        {
                            case 1:
                                Console.Write("Поля транспорта \n 1.Скорость(по умолчанию 60) \n 2.Вес(по умолчанию 3 т) \n 3.Количсетво колес(по умолчанию 4) \n");
                                Console.Write("Выберите параметр, который хотите изменить или ввести\n");
                                n = Convert.ToInt32(Console.ReadLine());
                                switch (n)
                                {
                                    case 1:
                                        Console.Write("Скорость = ");
                                        transport.Speed = Convert.ToInt32(Console.ReadLine());
                                        
                                        break;
                                    case 2:
                                        Console.Write("Вес = ");
                                        transport.Weight = Convert.ToInt32(Console.ReadLine());
                                        break;
                                    case 3:
                                        Console.Write("Кол-во колес = ");
                                        transport.Wheel = Convert.ToInt32(Console.ReadLine());
                                        break;
                                    default:
                                        Console.Write("Неверный ввод\n");
                                        break;
                                }
                                break;
                            case 2:
                                Console.Write(" Скорость = {0}" + "\n Вес = {1}\n Кол-во колес = {2}\n", transport.Speed, transport.Weight,transport.Wheel);
                                break;
                            case 3:
                                Console.Write("Введите 1, если расстояние будет вещественным и 2 если целым.\n");
                                int m = Convert.ToInt32(Console.ReadLine());
                                switch (m)
                                {
                                    case 1:
                                        Console.WriteLine("Введите расстояние езды");
                                        double f = Convert.ToDouble(Console.ReadLine());
                                        Console.WriteLine("Для текущей скорости время равно = {0} ч", transport.Time(f));
                                        break;
                                    case 2:
                                        Console.WriteLine("Введите расстояние езды");
                                        int r = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine("Для текущей скорости время равно = {0} ч", transport.Time(r));
                                        break;
                                    default:
                                        Console.Write("Неверный ввод\n");
                                        break;
                                }
                                break;
                            default:
                                Console.Write("Неверный ввод\n");
                                break;
                        }
                        if (k != 1)
                        {
                            Console.Write("Для повтора работы c транспортом введите 1\n");
                            int p;
                            p = Convert.ToInt32(Console.ReadLine());
                            if (p == 1) k = 1;
                            else k = 0;
                        }
                    }

                }
                if (l == 2)
                {
                    k = 1;
                    Carbrand.EModel eModel=Carbrand.EModel.Volkswagen;
                    while (k == 1)
                    {
                        k = 0;
                        car.Type();
                        Console.Write("Введите \n 1 для повтора ввода(изменения) \n 2 для показа данных\n 3 для расчета времени пути\n 4. Проверить, в Russia произведено или нет\n");
                        n = Convert.ToInt32(Console.ReadLine());
                        switch (n)
                        {
                            case 1:
                                Console.Write("Поля автомобиля \n 1.Скорость(по умолчанию 60) \n 2.Вес(по умолчанию 3 т) \n 3.Количсетво колес(по умолчанию 4) \n 4. Марка(по умолчании Volkswagen) \n 5.Страна производитель(по умолчанию Germany)\n ");
                                Console.Write("Выберите параметр, который хотите изменить или ввести\n");
                                n = Convert.ToInt32(Console.ReadLine());
                                switch (n)
                                {
                                    case 1:
                                        Console.Write("Скорость = ");
                                        car.Speed = Convert.ToInt32(Console.ReadLine());
                                        break;
                                    case 2:
                                        Console.Write("Вес = ");
                                        car.Weight = Convert.ToInt32(Console.ReadLine());
                                        break;
                                    case 3:
                                        Console.Write("Кол-во колес = ");
                                        car.Wheel = Convert.ToInt32(Console.ReadLine());
                                        break;
                                    case 4:
                                        Console.Write("Марка = ");
                                        car.Model = Console.ReadLine();
                                        break;
                                    case 5:
                                        Console.Write("Страна производитель = ");
                                        car.LandProducer = Console.ReadLine();
                                        break;
                                    default:
                                        Console.Write("Неверный ввод\n");
                                        break;
                                }
                                break;
                            case 2:
                                if (Enum.TryParse<Carbrand.EModel>(car.Model, out eModel)) 
                                {
                                    Console.Write("{3}. Скорость = {0}" + "\n Вес = {1}" + "\n Кол-во колес = {2}" + "\n Марка = " + eModel + "\n Страна производитель = " + car.LandProducer + "\n", car.Speed, car.Weight, car.Wheel, Carbrand.Index());
                                }
                                else
                                {
                                    Console.Write("{3}. Скорость = {0}" + "\n Вес = {1}" + "\n Кол-во колес = {2}" + "\n Марка = " + "Неизвестная марка" + "\n Страна производитель = " + car.LandProducer + "\n", car.Speed, car.Weight, car.Wheel, Carbrand.Index());
                                }
                                    break;
                            case 3:
                                Console.Write("Введите 1, если расстояние будет вещественным и 2 если целым.\n");
                                int m = Convert.ToInt32(Console.ReadLine());
                                switch (m)
                                {
                                    case 1:
                                        Console.WriteLine("Введите расстояние езды");
                                        double f = Convert.ToDouble(Console.ReadLine());
                                        Console.WriteLine("Для текущей скорости время равно = {0} ч", car.Time(f));
                                        break;
                                    case 2:
                                        Console.WriteLine("Введите расстояние езды");
                                        int r = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine("Для текущей скорости время равно = {0} ч", car.Time(r));
                                        break;
                                    default:
                                        Console.Write("Неверный ввод\n");
                                        break;
                                }
                                break;
                            case 4:
                                car.Equals(car);    
                                break;
                            default:
                                Console.Write("Неверный ввод\n");
                                break;
                        }
                        if (k != 1)
                        {
                            Console.Write("Для повтора работы c брендом введите 1\n");
                            int p;
                            p = Convert.ToInt32(Console.ReadLine());
                            if (p == 1) k = 1;
                            else k = 0;
                        }
                    }
                }
                if (k != 1)
                {
                    Console.Write("Для повтора работы c программой введите 1\n");
                    int p;
                    p = Convert.ToInt32(Console.ReadLine());
                    if (p == 1) k = 1;
                    else k = 0;
                }
            }
            Console.Write("Спасибо за работу");
            Console.Read();
        }

        private static void Transport_ThisNull(int val)
        {
            throw new NotImplementedException();
        }
    }
}

