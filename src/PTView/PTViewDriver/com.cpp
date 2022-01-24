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
	IoDeleteSymbolicLink(&SymlinkName);
	IoDeleteDevice(DeviceObject);

	// call the gadget if we manually mapped, 
	// because the driver will be freed from memory after the call to IoDeleteDriver.
	if (ManuallyMapped)
		DeleteDriverGadget(driverObject);
}

NTSTATUS SetupDevice(PDRIVER_OBJECT driverObject)
{
	DriverObject = driverObject;

	auto status = IoCreateDevice(driverObject, 0, &DeviceName, FILE_DEVICE_UNKNOWN, FILE_DEVICE_SECURE_OPEN, FALSE, &DeviceObject);
	ReturnOnFail(status);

	status = IoCreateSymbolicLink(&SymlinkName, &DeviceName);
	ReturnOnFail(status);

	DriverObject->MajorFunction[IRP_MJ_CREATE] = CompleteRequest;
	DriverObject->MajorFunction[IRP_MJ_CLOSE] = CompleteRequest;
	DriverObject->DriverUnload = Unload;

	DeviceObject->Flags |= DO_DIRECT_IO;
	DeviceObject->Flags &= ~DO_DEVICE_INITIALIZING;

	return status;
}