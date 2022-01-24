#include "util.h"
#include "undocumented.h"
#include "com.h"

bool ManuallyMapped = false;

NTSTATUS DriverEntry(_In_ PDRIVER_OBJECT DriverObject, _In_ PUNICODE_STRING RegistryPath)
{
	if (!RegistryPath)
	{
		ManuallyMapped = true;
		
		// Create driver if manually mapped
		UNICODE_STRING driverName = RTL_CONSTANT_STRING(L"\\Driver\\PTView");
		return IoCreateDriver(&driverName, DriverEntry);
	}

	return SetupDevice(DriverObject);
}