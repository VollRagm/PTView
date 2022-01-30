#pragma once
#include "util.h"

ULONG64 PsGetDirbase(PEPROCESS proc);
NTSTATUS DumpPageTable(ULONG64 pfn, PVOID outputBuffer);
NTSTATUS DumpPage(ULONG64 pfn, bool largePage, PVOID outputBuffer);

typedef union _cr3
{
    ULONG64 flags;
    struct
    {
        ULONG64 reserved1 : 3;
        ULONG64 page_level_write_through : 1;
        ULONG64 page_level_cache_disable : 1;
        ULONG64 reserved2 : 7;
        ULONG64 dirbase : 36;
        ULONG64 reserved3 : 16;
    };
} cr3;

typedef union _pml4e
{
    ULONG64 value;
    struct
    {
        ULONG64 present : 1; //0
        ULONG64 ReadWrite : 1; // 1
        ULONG64 user_supervisor : 1; // 2
        ULONG64 PageWriteThrough : 1; // 3
        ULONG64 page_cache : 1; // 4
        ULONG64 accessed : 1; // 5
        ULONG64 Ignored1 : 1; // 6
        ULONG64 page_size : 1; // 7
        ULONG64 Ignored2 : 4; // 8
        ULONG64 pfn : 36; // 12
        ULONG64 Reserved : 4;
        ULONG64 Ignored3 : 11;
        ULONG64 nx : 1;
    };
} pml4e, * ppml4e;

typedef union _pdpte
{
    ULONG64 value;
    struct
    {
        ULONG64 present : 1;
        ULONG64 ReadWrite : 1;
        ULONG64 user_supervisor : 1;
        ULONG64 PageWriteThrough : 1;
        ULONG64 page_cache : 1;
        ULONG64 accessed : 1;
        ULONG64 Ignored1 : 1;
        ULONG64 page_size : 1;
        ULONG64 Ignored2 : 4;
        ULONG64 pfn : 36;
        ULONG64 Reserved : 4;
        ULONG64 Ignored3 : 11;
        ULONG64 nx : 1;
    };
} pdpte, * ppdpte;

typedef union _pde
{
    ULONG64 value;
    struct
    {
        ULONG64 present : 1;
        ULONG64 ReadWrite : 1;
        ULONG64 user_supervisor : 1;
        ULONG64 PageWriteThrough : 1;
        ULONG64 page_cache : 1;
        ULONG64 accessed : 1;
        ULONG64 Ignored1 : 1;
        ULONG64 page_size : 1;
        ULONG64 Ignored2 : 4;
        ULONG64 pfn : 36;
        ULONG64 Reserved : 4;
        ULONG64 Ignored3 : 11;
        ULONG64 nx : 1;
    };
} pde, * ppde;

typedef union _pte
{
    ULONG64 value;
    struct
    {
        ULONG64 present : 1;
        ULONG64 ReadWrite : 1;
        ULONG64 user_supervisor : 1;
        ULONG64 PageWriteThrough : 1;
        ULONG64 page_cache : 1;
        ULONG64 accessed : 1;
        ULONG64 Dirty : 1;
        ULONG64 PageAccessType : 1;
        ULONG64 Global : 1;
        ULONG64 Ignored2 : 3;
        ULONG64 pfn : 36;
        ULONG64 Reserved : 4;
        ULONG64 Ignored3 : 7;
        ULONG64 ProtectionKey : 4;
        ULONG64 nx : 1;
    };
} pte, * ppte;

typedef union _virt_addr_t
{
    PVOID value;
    struct
    {
        ULONG64 offset : 12;
        ULONG64 pt_index : 9;
        ULONG64 pd_index : 9;
        ULONG64 pdpt_index : 9;
        ULONG64 pml4_index : 9;
        ULONG64 reserved : 16;
    };
} virtual_address, * pvirtual_address;
