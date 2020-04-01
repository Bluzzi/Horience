using System;
using System.Runtime.InteropServices;

namespace Horience.Core.Api.Memory
{
    class MemoryBase
    {
        // Privilge constants :
        protected const int PROCESS_CREATE_THREAD = 0x0002;
        protected const int PROCESS_QUERY_INFORMATION = 0x0400;
        protected const int PROCESS_VM_OPERATION = 0x0008;
        protected const int PROCESS_VM_WRITE = 0x0020;
        protected const int PROCESS_VM_READ = 0x0010;

        // Memory mode constants :
        protected const uint MEM_COMMIT = 0x00001000;
        protected const uint MEM_RESERVE = 0x00002000;
        protected const uint PAGE_READWRITE = 4;

        /**
         * Documentation of kernel32 methods.
         * 
         * OpenProcess ->
         * - Param : privilge constants (example : PROCESS_CREATE_THREAD | PROCESS_VM_READ), false, process ID
         * - Definition : Open the process.
         * 
         * GetModuleHandle ->
         * - Param : name of the dll (example : kernel32.dll)
         * - Definition : Find the pointer of the dll.
         * 
         * GetProcAdress ->
         * - Param : the handle of the module, name of the library to load
         * - Definition : ...
         * 
         * VirtualAllocEx ->
         * - Param : Process handle, Address to allocate(IntPtr.Zero), bytes to allocate, memory mode constants
         * - Definition : ...
         * 
         * CreateRemoteThread ->
         * - Param : Program handler(OpenProcess), IntPtr.Zero, 0, 
         * - Definition : ...
         * 
         * WriteProcessMemory ->
         * - Param : ...
         * - Definition : ...
         * 
         * ReadProcessMemory ->
         * - Param : ...
         * - Definition : ...
         */

        [DllImport("kernel32.dll")]
        protected static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        protected static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        protected static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        protected static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

        [DllImport("kernel32.dll")]
        protected static extern IntPtr CreateRemoteThread(
            IntPtr hProcess, IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress,
            IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId
        );

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out UIntPtr lpNumberOfBytesWritten);

        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(IntPtr hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);
    }
}