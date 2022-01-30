using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PTViewClient.PTView
{
    public static unsafe class Native
    {
        [DllImport("kernel32.dll")]
        public static extern void CloseHandle(IntPtr hdl);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr CreateFile(string filename, uint fileAccess, FileShare sharing, IntPtr SecurityAttributes, FileMode mode, FileOptions options, IntPtr template);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool DeviceIoControl(IntPtr hDevice, uint dwIoControlCode, void* lpInBuffer, uint lpInBufferSize, void* lpOutBuffer, uint nOutBufferSize, uint lpBytesReturned = 0, long overlapped = 0);

    }
}
