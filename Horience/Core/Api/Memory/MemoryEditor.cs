using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Horience.Core.Api.Memory
{
    class MemoryEditor
    {
        //IMPORTS
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress,
            uint dwSize, uint flAllocationType, uint flProtect);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out UIntPtr lpNumberOfBytesWritten);

        [DllImport("kernel32.dll")]
        static extern IntPtr CreateRemoteThread(IntPtr hProcess,
            IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

        //CONSTANTE DE PRIVILEGE
        const int PROCESS_CREATE_THREAD = 0x0002;
        const int PROCESS_QUERY_INFORMATION = 0x0400;
        const int PROCESS_VM_OPERATION = 0x0008;
        const int PROCESS_VM_WRITE = 0x0020;
        const int PROCESS_VM_READ = 0x0010;

        // CONSTANTE DE MODE DE MEMOIRE
        const uint MEM_COMMIT = 0x00001000;
        const uint MEM_RESERVE = 0x00002000;
        const uint PAGE_READWRITE = 4;

        public static Process GetProcessFromName(string name)
        {
            Process[] names = Process.GetProcessesByName(name);
            if (names.Length <= 0)return new Process();
            return names[0];
        }

        public static IntPtr GetProcessPointer()
        {
            return OpenProcess(PROCESS_VM_OPERATION | PROCESS_VM_READ | PROCESS_VM_WRITE, false, GetProcessFromName().Id);
        }
    }
}
