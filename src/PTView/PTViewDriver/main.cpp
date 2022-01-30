#include "util.h"
#include "undocumented.h"
#include "com.h"
#include "ptutil.h"

NTSTATUS DriverDispatch(PDEVICE_OBJECT device, PIRP irp)
{
	UNREFERENCED_PARAMETER(device);

	PIO_STACK_LOCATION irpStack = IoGetCurrentIrpStackLocation(irp);

	auto inputBuffer = irpStack->Parameters.DeviceIoControl.Type3InputBuffer;
	NTSTATUS status = STATUS_SUCCESS;

	switch (irpStack->Parameters.DeviceIoControl.IoControlCode)
	{
		case IOCTL_DIRBASE:
			if (inputBuffer)
			{
				HANDLE pid = *(HANDLE*)inputBuffer;
				PEPROCESS proc;
				status = PsLookupProcessByProcessId(pid, &proc);
				if (NT_SUCCESS(status))
				{
					ULONG64 dirbase = PsGetDirbase(proc);
					ObDereferenceObject(proc);
					*(ULONG64*)irp->UserBuffer = dirbase;
				}
			}
			break;
		
		case IOCTL_DUMP_PT:
			if (inputBuffer)
			{
				ULONG64 pfn = *(ULONG64*)inputBuffer;
				status = DumpPageTable(pfn, irp->UserBuffer);
			}
			break;

		case IOCTL_DUMP_PAGE:
			if (inputBuffer)
			{
				ULONG64 pfn = *(ULONG64*)inputBuffer;
				status = DumpPage(pfn, false, irp->UserBuffer);
			}
			break;

		case IOCTL_DUMP_LARGE_PAGE:
			if (inputBuffer)
			{
				ULONG64 pfn = *(ULONG64*)inputBuffer;
				status = DumpPage(pfn, true, irp->UserBuffer);
			}
			break;
	}

	irp->IoStatus.Information = 0;
	irp->IoStatus.Status = status;
	IoCompleteRequest(irp, IO_NO_INCREMENT);
	return status;
}

NTSTATUS ManualDriverEntry(_In_ PDRIVER_OBJECT DriverObject, _In_ PUNICODE_STRING RegistryPath)
{
	UNREFERENCED_PARAMETER(RegistryPath);
	return SetupDevice(DriverObject, DriverDispatch);
}

NTSTATUS DriverEntry(_In_ PDRIVER_OBJECT DriverObject, _In_ PUNICODE_STRING RegistryPath)
{
	if (!DriverObject || DriverObject->DriverInit != DriverEntry)
	{
		// Create driver if manually mapped
		UNICODE_STRING driverName = RTL_CONSTANT_STRING(L"\\Driver\\PTView");
		auto status = IoCreateDriver(&driverName, ManualDriverEntry);
		DbgPrintEx(0, 0, "IoCreateDriver -> %lx", status);
		return status;
	}

	return SetupDevice(DriverObject, DriverDispatch);
}