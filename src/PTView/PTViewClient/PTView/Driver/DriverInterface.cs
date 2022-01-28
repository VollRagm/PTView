using System;
using System.IO;
using static PTViewClient.PTView.Native;
using static PTViewClient.PTView.Driver.Internal.Constants;

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

        public void Unload()
        {
            DeviceIoControl(DriverHandle, IOCTL_UNLOAD, null, 0, null, 0);
            CloseHandle(DriverHandle);
        }
    }
}
