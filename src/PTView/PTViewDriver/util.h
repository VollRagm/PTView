#pragma once
#include <wdm.h>
#include <ntddk.h>

extern bool ManuallyMapped;

#define ReturnOnFail(status) if (!NT_SUCCESS(status)) return status;