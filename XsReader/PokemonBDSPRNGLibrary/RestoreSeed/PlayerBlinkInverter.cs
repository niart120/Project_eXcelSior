using System;
using System.Collections.Generic;
using System.Linq;
using PokemonPRNG.XorShift128;
using PokemonBDSPRNGLibrary.RestoreSeedModules;

namespace PokemonBDSPRNGLibrary.RestoreSeed
{
    public class PlayerBlinkInverter
    {
        /// <summary>
        /// 保持しているビット数。
        /// 128以上あれば逆算できる可能性がある。
        /// </summary>
        public int Entropy { get; private set; }

        /// <summary>
        /// 現在観測した瞬きの回数。
        /// </summary>
        public int BlinkCount { get; private set; }

        private readonly BitPacker bitPacker = new BitPacker();
        private readonly List<uint[]> matrix = new List<uint[]>();
        private readonly (uint, uint, uint, uint)[] vectors = Enumerable.Range(0, 128).Select(_ => Matrix128.GetBase(_ / 32, _ % 32)).ToArray();

        private uint[][] inv = null;

        /// <summary>
        /// 観測したゴンベの瞬き間隔を入力する。
        /// </summary>
        /// <param name="interval">観測された瞬き間隔(秒)。</param>
        public void AddBlink(PlayerBlink blinkType)
        {
            BlinkCount++;

            if (blinkType == PlayerBlink.None)
            {
                for (int i = 0; i < vectors.Length; i++) vectors[i].GetRand();
                return;
            }

            var temp = Enumerable.Range(0, 4).Select(_ => new uint[4]).ToArray();
            for (int i = 0; i < vectors.Length; i++)
            {
                var rand = vectors[i].GetRand() & 0xF;
                var (col, bit) = (i / 32, i % 32);
                foreach (var row in temp)
                {
                    row[col] |= (rand & 1) << bit;
                    rand >>= 1;
                }
            }

            var u4 = blinkType == PlayerBlink.Single ? 0u : 1u;
            bitPacker.Pack(u4, 4);
            matrix.AddRange(temp);
            Entropy += 4;
        }

        /// <summary>
        /// 逆算に十分な情報量が溜まっていれば逆算する。
        /// stateは観測開始時の内部状態。
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool TryRestoreState(out (uint s0, uint s1, uint s2, uint s3) state)
        {
            if (Entropy < 128)
            {
                state = default;
                return false;
            }

            if (inv == null)
            {
                var _inv = matrix.GetInv();
                if (_inv == null)
                {
                    state = default;
                    return false;
                }

                inv = _inv;
            }

            state = bitPacker.Build().Products(inv, 4).ToTuple();
            return true;
        }
    }

}
