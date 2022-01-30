#include "ptutil.h"

ULONG64 PsGetDirbase(PEPROCESS proc)
{
	return ((*(_cr3*)((BYTE*)proc + 0x28)).dirbase);
}

NTSTATUS MmReadPhysical(PVOID targetAddress, ULONG64 sourceAddress, size_t size, size_t* bytesRead)
{
	PHYSICAL_ADDRESS address = { 0 };
	MM_COPY_ADDRESS copyInfo = { 0 };
	address.QuadPart = (LONGLONG)sourceAddress;
	copyInfo.PhysicalAddress = address;
	return MmCopyMemory(targetAddress, copyInfo, size, MM_COPY_MEMORY_PHYSICAL, bytesRead);
}

NTSTATUS DumpPageTable(ULONG64 pfn, PVOID outputBuffer)
{
	ULONG64 sourceAddress = pfn << 12;

	size_t dummy;
	// 512 possible PTE's, because 9 bits in the virtual address are used to index them
	// 2^9 = 512
	return MmReadPhysical(outputBuffer, sourceAddress, sizeof(pte) * 512, &dummy);
}

NTSTATUS DumpPage(ULONG64 pfn, PVOID outputBuffer)
{
	ULONG64 sourceAddress = pfn << 12;
	size_t dummy;
	return MmReadPhysical(outputBuffer, sourceAddress, PAGE_SIZE, &dummy);
}