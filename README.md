# PTView
This utility allows you to inspect a Windows processes Page Tables live.
You can browse through them in a GUI and dump the physical pages they point to, as well as translate virtual to physical addresses and get the virtual address to a PTE.

## Usage
You will have to load the driver before running the client.
I recommend loading the Driver normally in test mode, but it can be mapped as well, just make sure the first argument is the driver base and the second argument is NULL.
After opening the client, select a process and start browsing its page tables!

## Key features

 - Browse Page Tables of Processes, including system processes
 - Highlight different types of Pages
 - Dump a physical page
 - Get the virtual address that leads to the current selection
 - Translate a physical address to virtual address with visualization
 - Get information on a Page table entry
 - Support for Large Pages

## Things worth trying out

 1. **Dump the PML4 itself over its auto-entry (self-reference):**  

Every PML4 keeps an entry that has the PML4's address as PFN itself. This entry is at a fixed index, that Windows nowadays sets randomly during boot.
If this entry is selected the PDPT actually is the PML4 itself again. If you select it in the PDPT again, the PD also is the PML4 again. If you continue that until the end, the PT will be the PML4, and you will be able to use the PML4 auto-entry to dump the PML4 itself or get its virtual address.
Note that this address only is valid in the selected processes context.

![PML4 auto-entry selected](https://i.imgur.com/qUI7WDO.png) 

 2. **Watch Windows Memory manager map pages, that have been paged out to disk:**  

Get the virtual address of an unused loaded module in the process. Enter it in the Virtual Address textbox and translate it.
Chances are that the PTE of that VA or the subsequent PTE's PFNs is 0x0. 
Now access the virtual address using a Debugger or Memory viewer, like Cheat Engine, and you will see how it raises a page fault, causing Windows Memory Manager to map the pages live.


A prebuilt release can be downloaded [here.](https://github.com/VollRagm/PTView/releases/latest)
