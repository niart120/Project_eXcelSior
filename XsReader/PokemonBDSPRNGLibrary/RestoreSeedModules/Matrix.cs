using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonBDSPRNGLibrary.RestoreSeedModules
{
    internal static class Matrix128
    {
        public static (uint, uint, uint, uint) GetBase(int i, int k)
        {
            if (i == 0) return (1u << k, 0u, 0u, 0u);
            if (i == 1) return (0u, 1u << k, 0u, 0u);
            if (i == 2) return (0u, 0u, 1u << k, 0u);
            return (0u, 0u, 0u, 1u << k);
        }

        public static uint[][] GetInv(this List<uint[]> _mat)
        {
            var mat = new uint[_mat.Count][];
            for (int i = 0; i < _mat.Count; i++)
                mat[i] = _mat[i].ToArray();

            // 初期状態として単位行列を作る。
            var matColumns = (mat.Length + 31) / 32;
            var inv = CreateIdMat(mat.Length, matColumns);

            for (int i = 0; i < mat[0].Length * 32; i++)
            {
                // i行目が1である列を探す。
                var r = mat.GetPoppedRow(i);
                if (r == -1) return null;

                // 見つけた列をi列目と交換。
                if (r != i)
                {
                    mat.SwapRows(i, r);
                    inv.SwapRows(i, r);
                }

                // i列目以外のi行目が全て0になるように引いて(足して)いく。
                var col = i / 32;
                var mask = (1u << (i % 32));
                for (int j = 0; j < mat.Length; j++)
                {
                    if (i != j && (mat[j][col] & mask) != 0)
                    {
                        for (int c = 0; c < mat[j].Length; c++)
                            mat[j][c] ^= mat[i][c];

                        for (int c = 0; c < inv[j].Length; c++)
                            inv[j][c] ^= inv[i][c];
                    }
                }
            }

            return inv;
        }

        private static uint[][] CreateIdMat(int row, int col)
        {
            var mat = new uint[row][];
            for (int i = 0; i < mat.Length; i++)
                mat[i] = new uint[col];

            for (int i = 0; i < 32; i++)
                for (int k = 0; k < mat[i].Length && (i + k * 32) < mat.Length; k++)
                    mat[i + k * 32][k] = (1u << i);

            return mat;
        }

        private static int GetPoppedRow(this uint[][] mat, int i)
        {
            var col = i / 32;
            var mask = 1u << (i % 32);

            if (col >= mat[i].Length)
                return -1;

            for (int k = i; k < mat.Length; k++)
                if ((mat[k][col] & mask) != 0) return k;

            return -1;
        }

        private static void SwapRows<T>(this T[] mat, int r1, int r2)
            => (mat[r2], mat[r1]) = (mat[r1], mat[r2]);

        public static uint[] Products(this uint[] state, uint[][] matrix, int resultVectorDim)
        {
            var result = new uint[resultVectorDim];

            for (int i = 0; i < result.Length; i++)
            {
                for (int k = 0; k < 32; k++)
                {
                    var row = i * 32 + k;
                    if (row >= matrix.Length) break;

                    var matRow = matrix[row];

                    // 畳み込み
                    var conv = 0u;
                    for (int t = 0; t < state.Length; t++)
                        conv += (uint)(state[t] & matRow[t]).PopCount();
                    conv &= 1;

                    result[i] |= (conv << k);
                }
            }

            return result;
        }

        public static int PopCount(this uint x)
        {
            x = (x & 0x55555555u) + ((x & 0xAAAAAAAAu) >> 1);
            x = (x & 0x33333333u) + ((x & 0xCCCCCCCCu) >> 2);
            x = (x & 0x0F0F0F0Fu) + ((x & 0xF0F0F0F0u) >> 4);

            x += x >> 8;
            x += x >> 16;
            return (int)(x & 0x7F);
        }

        public static (uint s0, uint s1, uint s2, uint s3) ToTuple(this uint[] state)
            => (state[0], state[1], state[2], state[3]);
    }

}
