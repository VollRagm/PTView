#pragma once
#include <wdm.h>
#include <ntddk.h>
#include <intrin.h>

#define ReturnOnFail(status) if (!NT_SUCCESS(status)) return status;