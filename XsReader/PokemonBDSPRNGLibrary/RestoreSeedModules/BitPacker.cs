using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonBDSPRNGLibrary.RestoreSeedModules
{
    // ビットを32bit配列に詰めていくためのクラス.
    class BitPacker
    {
        private int cursor;
        private readonly List<uint> state = new List<uint>() { 0u };

        public void Pack(uint input, int n)
        {
            if (n == 0) return;

            input &= (1u << n) - 1;

            var (a, b) = (cursor / 32, cursor % 32);
            if (state.Count <= a) state.Add(0);
            state[a] |= (input << b);
            cursor += n;
            if (b + n > 32)
            {
                var rest = 32 - b;
                state.Add((input >> rest));
            }
        }

        public uint[] Build()
            => state.ToArray();
    }

}
