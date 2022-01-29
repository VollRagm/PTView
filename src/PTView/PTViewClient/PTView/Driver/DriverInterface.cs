using System;
using System.IO;
using static PTViewClient.PTView.Native;
using static PTViewClient.PTView.Driver.Internal.Constants;
using System.Linq;

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

        public PTE[] DumpPageTables(ulong dirbase)
        {
            ulong[] ptBuffer = new ulong[512];

            fixed (void* buf = ptBuffer)
                DeviceIoControl(DriverHandle, IOCTL_DUMP_PT,
                                &dirbase, sizeof(ulong),
                                buf, (uint)ptBuffer.Length * sizeof(ulong));

            return ptBuffer.Select(x => (PTE)x).ToArray();
        }
    }
}
