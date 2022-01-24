#pragma once
#include "util.h"

extern "C" NTKERNELAPI
NTSTATUS IoCreateDriver(
	IN PUNICODE_STRING DriverName, OPTIONAL
	IN PDRIVER_INITIALIZE InitializationFunction
);

extern "C" 
VOID DeleteDriverGadget(
	IN  PDRIVER_OBJECT DriverObject
);
