#include "com.h"

PDRIVER_OBJECT DriverObject;
PDEVICE_OBJECT DeviceObject;

UNICODE_STRING SymlinkName = RTL_CONSTANT_STRING(L"\\DosDevices\\PTView");
UNICODE_STRING DeviceName = RTL_CONSTANT_STRING(L"\\Device\\PTView");

NTSTATUS CompleteRequest(PDEVICE_OBJECT deviceObject, PIRP irp)
{
	(deviceObject);
	irp->IoStatus.Status = STATUS_SUCCESS;
	irp->IoStatus.Information = 0;
	IoCompleteRequest(irp, IO_NO_INCREMENT);
	return STATUS_SUCCESS;
}


void Unload(PDRIVER_OBJECT driverObject)
{
	UNREFERENCED_PARAMETER(driverObject);
	IoDeleteSymbolicLink(&SymlinkName);
	IoDeleteDevice(DeviceObject);
}

NTSTATUS SetupDevice(PDRIVER_OBJECT driverObject, PDRIVER_DISPATCH ioHandler)
{
	DriverObject = driverObject;

	auto status = IoCreateDevice(driverObject, 0, &DeviceName, FILE_DEVICE_UNKNOWN, FILE_DEVICE_SECURE_OPEN, FALSE, &DeviceObject);
	DbgPrintEx(0, 0, "IoCreateDevice -> %lx\n", status);
	ReturnOnFail(status);

	status = IoCreateSymbolicLink(&SymlinkName, &DeviceName);
	DbgPrintEx(0, 0, "IoCreateSymbolicLink -> %lx\n", status);
	ReturnOnFail(status);

	DriverObject->MajorFunction[IRP_MJ_CREATE] = CompleteRequest;
	DriverObject->MajorFunction[IRP_MJ_CLOSE] = CompleteRequest;
	DriverObject->MajorFunction[IRP_MJ_DEVICE_CONTROL] = ioHandler;
	DriverObject->DriverUnload = Unload;

	DeviceObject->Flags |= DO_DIRECT_IO;
	DeviceObject->Flags &= ~DO_DEVICE_INITIALIZING;

	return status;
}