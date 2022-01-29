using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTViewClient.PTView
{
    public static class Misc
    {
        public static ulong SetBits(ulong word, ulong value, int pos, int size)
        {
            ulong mask = ((((ulong)1) << size) - 1) << pos;
            word &= ~mask;
            word |= (value << pos) & mask;
            return word;
        }

        public static ulong ReadBits(ulong word, int pos, int size)
        {
            ulong mask = ((((ulong)1) << size) - 1) << pos;
            return (word & mask) >> pos;
        }
    }
}
