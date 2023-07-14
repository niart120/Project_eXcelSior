using System;
using System.Collections.Generic;
using System.Text;
using PokemonPRNG.XorShift128;

namespace PokemonBDSPRNGLibrary.RestoreSeed
{
    public enum PlayerBlink
    {
        None,
        Single,
        Double
    }
    public static class BlinkGeneratorExt
    {
        public static PlayerBlink BlinkPlayer(this ref (uint s0, uint s1, uint s2, uint s3) state)
        {
            var r = state.GetRand() & 0xF;
            return r == 0 ? PlayerBlink.Single : r == 1 ? PlayerBlink.Double : PlayerBlink.None;
        }
      
        public static float BlinkPokemon(this ref (uint s0, uint s1, uint s2, uint s3) state, float pokemonBlink = 0.285f)
        {
            return state.GetRand_f(3.0f, 12.0f) + pokemonBlink;
        }
      
        public static uint GetNextPlayerBlink(this ref (uint s0, uint s1, uint s2, uint s3) state)
        {
            for(uint i = 1; ; i++)
            {
                if (state.BlinkPlayer() != PlayerBlink.None) return i;
            }
        }
        public static uint GetNextPlayerBlink(this ref (uint s0, uint s1, uint s2, uint s3) state, out PlayerBlink blink)
        {
            for (uint i = 1; ; i++)
            {
                blink = state.BlinkPlayer();
                if (blink != PlayerBlink.None) return i;
            }
        }

        public static string ToShortString(this PlayerBlink blink)
            => blink == PlayerBlink.None ? "-" : blink == PlayerBlink.Single ? "S" : "D";
      
    }
}
