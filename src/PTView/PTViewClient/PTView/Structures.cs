using static PTViewClient.PTView.Misc;

namespace PTViewClient.PTView
{
    public class PML4E
    {
        public ulong Value;

        public PML4E(ulong value)
        {
            Value = value;
        }

        public ulong Present { get => ReadBits(Value, 0, 1); }
        public ulong ReadWrite { get => ReadBits(Value, 1, 1); }
        public ulong UserSupervisor { get => ReadBits(Value, 2, 1); }
        public ulong PageWriteThrough { get => ReadBits(Value, 3, 1); }
        public ulong PageCache { get => ReadBits(Value, 4, 1); }
        public ulong Accessed { get => ReadBits(Value, 5, 1); }
        public ulong PageSize { get => ReadBits(Value, 7, 1); } //this must be 0 for pml4e's (Intel Manual page 2940)
        public ulong PFN { get => ReadBits(Value, 12, 36); }
        public ulong NX { get => ReadBits(Value, 63, 1); }
    }

    public class PDPTE : PML4E
    {
        public PDPTE(ulong value) : base(value) { }
    }

    public class PDE : PDPTE
    {
        public PDE(ulong value) : base(value) { }
    }

    public class PTE : PDE
    {
        public PTE(ulong value) : base(value) { }

        public static implicit operator PTE(ulong value)
        {
            return new PTE(value);
        }

        public ulong Dirty { get => ReadBits(Value, 6, 1); }
        public ulong PageAccessType { get => ReadBits(Value, 7, 1); }
        public ulong Global { get => ReadBits(Value, 8, 1); }
        public ulong ProtectionKey { get => ReadBits(Value, 59, 4); }
    }

    public class VirtualAddress
    {
        public static implicit operator VirtualAddress(ulong value)
        {
            return new VirtualAddress(value);
        }

        public ulong Value;

        public VirtualAddress(ulong value)
        {
            Value = value;
        }

        public ulong Offset 
        { 
            get => ReadBits(Value, 0, 12);
            set => Value = SetBits(Value, value, 0, 12);
        }

        public ulong PTIndex 
        { 
            get => ReadBits(Value, 12, 9);
            set => Value = SetBits(Value, value, 12, 9);
        }

        public ulong PDIndex 
        { 
            get => ReadBits(Value, 21, 9);
            set => Value = SetBits(Value, value, 21, 9);
        }

        public ulong PDPTIndex 
        { 
            get => ReadBits(Value, 30, 9);
            set => Value = SetBits(Value, value, 30, 9);
        }

        public ulong PML4Index 
        {
            get => ReadBits(Value, 39, 9);
            set => Value = SetBits(Value, value, 39, 9);
        }

        public ulong Reserved
        {
            get => ReadBits(Value, 48, 16);
            set => Value = SetBits(Value, value, 48, 16);
        }

    }
}
