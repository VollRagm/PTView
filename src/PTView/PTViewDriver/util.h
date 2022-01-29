#pragma once
#include <ntdef.h>
#include <ntifs.h>
#include <ntddk.h>
#include <ntimage.h>
#include <stdlib.h>
#include <wdm.h>
#include <ntstrsafe.h>
#include <windef.h>

#define ReturnOnFail(status) if (!NT_SUCCESS(status)) return status;