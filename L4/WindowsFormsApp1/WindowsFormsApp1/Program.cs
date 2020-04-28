using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Runtime.InteropServices;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Forms.PropertyGridInternal;

namespace RetailTradeClient.Printers
{
    class SystemInform
    {
        [DllImport("kernel32.dll")]
        static extern void GetSystemInfo(ref _SYSTEM_INFO lpSystemInfo);
        delegate bool SystemInformDef(int hWnd, int IParam);
        [StructLayout(LayoutKind.Sequential)]
        struct _SYSTEM_INFO
        {
            public ushort wProcessorArchitecture;
            public ushort wReserved;
            public uint dwPageSize;
            public IntPtr lpMinimumApplicationAddress;
            public IntPtr lpMaximumApplicationAddress;
            public UIntPtr dwActiveProcessorMask;
            public uint dwNumberOfProcessors;
            public uint dwProcessorType;
            public uint dwAllocationGranularity;
            public ushort wProcessorLevel;
            public ushort wProcessorRevision;
        };
        [DllImport("user32.dll")]
        static extern int EnumWindows(SystemInformDef callback, int IParam);
        static bool PrintWindow(int hWnd, int IParam)
        {
            _SYSTEM_INFO lpSystemInfo = new _SYSTEM_INFO();
            GetSystemInfo(ref lpSystemInfo);

            Console.WriteLine("{0} {1} {2} {3} {4}", lpSystemInfo.dwActiveProcessorMask,lpSystemInfo.dwAllocationGranularity,lpSystemInfo.dwNumberOfProcessors,lpSystemInfo.dwPageSize,lpSystemInfo.dwProcessorType,lpSystemInfo.lpMaximumApplicationAddress,lpSystemInfo.lpMinimumApplicationAddress,lpSystemInfo.wReserved,lpSystemInfo.wProcessorRevision);
            return true;
        }
        static void Main()
        {

            SystemInformDef callback = new SystemInformDef(PrintWindow);

            EnumWindows(callback, 0);
        }

}
}
