#pragma once
#include "util.h"

extern "C" NTKERNELAPI
NTSTATUS IoCreateDriver(
	IN PUNICODE_STRING DriverName, OPTIONAL
	IN PDRIVER_INITIALIZE InitializationFunction
);
