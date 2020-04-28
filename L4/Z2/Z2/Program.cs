using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Runtime.InteropServices;

class MiDinLib
{
    [DllImport("Project12.dll",EntryPoint ="sum1",CallingConvention =CallingConvention.StdCall)]
    static extern int sum1(int a, int b);
    [DllImport("Project12.dll", EntryPoint = "_sum2",CallingConvention = CallingConvention.Cdecl)]
    static extern int sum2(int a, int b);
    static void Main()
    {
        int c = sum1(5,6);
        int d = sum2(3,4);
        Console.WriteLine("c = {0} d={1} ", c,d );
        Console.Read();
    }
}
