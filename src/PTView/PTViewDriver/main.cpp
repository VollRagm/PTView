#include "util.h"
#include "undocumented.h"
#include "com.h"

NTSTATUS DriverDispatch(PDEVICE_OBJECT device, PIRP irp)
{
	PIO_STACK_LOCATION irpStack = IoGetCurrentIrpStackLocation(irp);

	switch (irpStack->Parameters.DeviceIoControl.IoControlCode)
	{

	}

	irp->IoStatus.Information = 0;
	irp->IoStatus.Status = STATUS_SUCCESS;
	IoCompleteRequest(irp, IO_NO_INCREMENT);
	return STATUS_SUCCESS;
}

NTSTATUS ManualDriverEntry(_In_ PDRIVER_OBJECT DriverObject, _In_ PUNICODE_STRING RegistryPath)
{
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