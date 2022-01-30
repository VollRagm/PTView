using System;
using System.IO;
using static PTViewClient.PTView.Native;
using static PTViewClient.PTView.Driver.Internal.Constants;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace PTViewClient.PTView.Driver
{
    public unsafe class DriverInterface
    {
        public IntPtr DriverHandle;

        public bool Initialize(string symlink)
        {
            DriverHandle = CreateFile($"\\\\.\\{symlink}", 0x80000000,
                                                   FileShare.Read, IntPtr.Zero, FileMode.Open,
                                                               FileOptions.None, IntPtr.Zero);

            if (DriverHandle == new IntPtr(-1)) return false;
            return true;
        }

        public ulong GetProcessDirbase(uint processId)
        {
            ulong dirbase = 0;
            ulong procId = (ulong)processId;

            DeviceIoControl(DriverHandle, IOCTL_DIRBASE, 
                            &procId, sizeof(ulong),
                            &dirbase, sizeof(ulong));

            return dirbase;
        }

        public PTE[] DumpPageTables(ulong pfn)
        {
            ulong[] ptBuffer = new ulong[512];

            fixed (void* buf = ptBuffer)
                DeviceIoControl(DriverHandle, IOCTL_DUMP_PT,
                                &pfn, sizeof(ulong),
                                buf, (uint)ptBuffer.Length * sizeof(ulong));

            return ptBuffer.Select(x => (PTE)x).ToArray();
        }

        public byte[] DumpPage(ulong pfn, bool largePage)
        {
            uint bufferLength = largePage ? 0x1000 * 512u : 0x1000;
            byte[] pageBuffer = new byte[bufferLength];

            fixed(void* buf = pageBuffer)
            DeviceIoControl(DriverHandle, largePage ? IOCTL_DUMP_LARGE_PAGE : IOCTL_DUMP_PAGE,
                            &pfn, sizeof(ulong),
                            buf, bufferLength);

            return pageBuffer;
        }

        public void Close()
        {
            CloseHandle(DriverHandle);
        }
    }
}
