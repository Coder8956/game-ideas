
using UnityEngine;

namespace HutongGames
{
    public static class AnimationFunctions
    {
        public static float Pulse(float t) => Mathf.Abs(Mathf.Sin(t * Mathf.PI));
        
        public static float HeartBeat(float t) => Mathf.Max(0, Mathf.Sin(t * Mathf.PI * 2));
        
        public static float TickTock(float t) => Mathf.Max(0, Mathf.Ceil(Mathf.Sin(t * Mathf.PI)));
        
        public static float SineWave(float t) => (Mathf.Sin(t * Mathf.PI * 2) + 1) * 0.5f; // Normalized 0-1
        
        public static float CosineWave(float t) => (Mathf.Cos(t * Mathf.PI * 2) + 1) * 0.5f; // Normalized 0-1

        // Bouncing and elastic effects
        public static float Bounce(float t)
        {
            const float n1 = 7.5625f;
            const float d1 = 2.75f;
            
            if (t < 1 / d1)
                return n1 * t * t;
            if (t < 2 / d1)
                return n1 * (t -= 1.5f / d1) * t + 0.75f;
            if (t < 2.5f / d1)
                return n1 * (t -= 2.25f / d1) * t + 0.9375f;
            return n1 * (t -= 2.625f / d1) * t + 0.984375f;
        }
        
        public static float Elastic(float t)
        {
            const float c4 = (2 * Mathf.PI) / 3;
            return t == 0 ? 0 : t == 1 ? 1 : Mathf.Pow(2, -10 * t) * Mathf.Sin((t * 10 - 0.75f) * c4) + 1;
        }
        
        // Wave variations
        public static float TriangleWave(float t) => 1 - Mathf.Abs((t * 2) % 2 - 1);

        public static float Linear(float t) => t;
        
        public static float SquareWave(float t) => Mathf.Sign(Mathf.Sin(t * Mathf.PI * 2)) * 0.5f + 0.5f;
        
        // Special effects
        public static float Wobble(float t) => Mathf.Sin(t * Mathf.PI * 8) * (1 - t) * 0.5f + 0.5f;
        
        public static float Spring(float t) => 1 - Mathf.Exp(-t * 6) * Mathf.Cos(t * Mathf.PI * 12);
        
        public static float Flash(float t) => Mathf.Pow(Mathf.Sin(t * Mathf.PI), 10);
        
        public static float Breathe(float t) => (Mathf.Sin(t * Mathf.PI * 2 - Mathf.PI * 0.5f) + 1) * 0.5f;
        
        // Exponential functions
        public static float ExponentialIn(float t) => t == 0 ? 0 : Mathf.Pow(2, 10 * (t - 1));
        
        public static float ExponentialOut(float t) => t == 1 ? 1 : 1 - Mathf.Pow(2, -10 * t);

    }
}