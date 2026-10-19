using System.Collections.Generic;
using HutongGames.PlayMaker.Actions;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    /// <summary>
    /// Samples distances using an AnimationCurve as a radial falloff (x:0=center, x:1=outer/magnitude).
    /// y is treated as a non-negative relative PDF; we normalize internally.
    /// </summary>
#if UNITY_6000_5_OR_NEWER
    [Unity.Scripting.LifecycleManagement.NoAutoStaticsCleanup]
#endif
    public static class CurveDistributionSampler
    {
        private const int DefaultSampleCount = 128;

        private sealed class CacheEntry
        {
            public int Hash;
            public int SampleCount;
            public float[] Cdf; // monotonic [0,1]
        }

        // Cache by curve reference; rebuild if its hash/sample count changes.
        private static readonly Dictionary<AnimationCurve, CacheEntry> Cache = new();

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void ResetStatics() => Cache.Clear();
        
        /// <summary>
        /// Returns t in [0,1] sampled from the curve. If curve is null → uniform Random.value.
        /// </summary>
        public static float Sample01(AnimationCurve curve, int sampleCount = DefaultSampleCount)
        {
            if (curve == null) return Random.value;

            var cdf = GetOrBuildCdf(curve, sampleCount);
            var u = Random.value;
            return InvertCdf(cdf, u);
        }

        /// <summary>
        /// Overload using AnimationCurveVar (unset/null → uniform).
        /// </summary>
        public static float Sample01(AnimationCurveVar curveVar, int sampleCount = DefaultSampleCount)
        {
            if (curveVar == null || curveVar.IsNone || curveVar.Value == null) return Random.value;
            return Sample01(curveVar.Value, sampleCount);
        }

        /// <summary>
        /// Samples a value around center with symmetric ±magnitude using the curve as distance falloff.
        /// If curve is null/unset → uniform in [-magnitude, +magnitude].
        /// </summary>
        public static float SampleSymmetric(float center, float magnitude, AnimationCurve curve, int sampleCount = DefaultSampleCount)
        {
            magnitude = Mathf.Max(0f, magnitude);
            if (magnitude <= 0f) return center;

            var t = Sample01(curve, sampleCount); // distance fraction [0,1]
            var distance = t * magnitude;
            var sign = (Random.value < 0.5f) ? -1f : 1f;
            return center + sign * distance;
        }

        /// <summary>
        /// Overload using AnimationCurveVar (unset/null → uniform).
        /// </summary>
        public static float SampleSymmetric(float center, float magnitude, AnimationCurveVar curveVar, int sampleCount = DefaultSampleCount)
        {
            var curve = (curveVar == null || curveVar.IsNone) ? null : curveVar.Value;
            return SampleSymmetric(center, magnitude, curve, sampleCount);
        }
        
        /// <summary>
        /// Samples a 2D point within a circle of radius 'magnitude' around 'center'.
        /// Distance falloff is driven by curve (x:0=center, x:1=radius). Unset/null curve → uniform in distance.
        /// Note: "uniform in distance" biases area outward; for uniform area, use a linearly increasing curve (y=x).
        /// </summary>
        public static Vector2 SampleRadial2D(Vector2 center, float magnitude, AnimationCurveVar curveVar, int sampleCount = 128)
        {
            magnitude = Mathf.Max(0f, magnitude);
            if (magnitude <= 0f) return center;

            var t = Sample01(curveVar, sampleCount);  // distance fraction [0,1]
            var r = t * magnitude;

            var angle = Random.value * Mathf.PI * 2f;
            var sin = Mathf.Sin(angle);
            var cos = Mathf.Cos(angle);

            return new Vector2(center.x + r * cos, center.y + r * sin);
        }

        /// <summary>
        /// Manually clears the internal cache (e.g., for debugging or memory pressure).
        /// </summary>
        public static void ClearCache()
        {
            Cache.Clear();
        }

        /// <summary>
        /// Invalidates a specific curve entry (next use rebuilds).
        /// </summary>
        public static void Invalidate(AnimationCurve curve)
        {
            if (curve != null) Cache.Remove(curve);
        }

        // ----------------- Internals -----------------

        private static float[] GetOrBuildCdf(AnimationCurve curve, int sampleCount)
        {
            var hash = HashCurve(curve);
            if (!Cache.TryGetValue(curve, out var entry) || entry.Cdf == null ||
                entry.Hash != hash || entry.SampleCount != sampleCount)
            {
                entry = new CacheEntry { Hash = hash, SampleCount = sampleCount, Cdf = BuildCdf(curve, sampleCount) };
                Cache[curve] = entry;
            }
            return entry.Cdf;
        }

        private static float[] BuildCdf(AnimationCurve curve, int sampleCount)
        {
            var cdf = new float[sampleCount];

            // Discrete PDF from y(t>=0) at bin centers, then prefix-sum and normalize.
            var sum = 0f;
            for (var i = 0; i < sampleCount; i++)
            {
                var t = (i + 0.5f) / sampleCount;
                var y = Mathf.Max(0f, curve.Evaluate(t));
                cdf[i] = y;
                sum += y;
            }

            if (sum <= Mathf.Epsilon)
            {
                // All zeros → uniform distance
                for (var i = 0; i < sampleCount; i++)
                    cdf[i] = (i + 1) / (float)sampleCount;
                return cdf;
            }

            var run = 0f;
            for (var i = 0; i < sampleCount; i++)
            {
                run += cdf[i];
                cdf[i] = run / sum;
            }
            return cdf;
        }

        private static float InvertCdf(float[] cdf, float u)
        {
            int lo = 0, hi = cdf.Length - 1;
            while (lo < hi)
            {
                var mid = (lo + hi) >> 1;
                if (cdf[mid] >= u) hi = mid;
                else lo = mid + 1;
            }

            var i = lo;
            var cPrev = (i == 0) ? 0f : cdf[i - 1];
            var cHere = cdf[i];
            var binStart = i / (float)cdf.Length;
            var binEnd   = (i + 1) / (float)cdf.Length;

            if (cHere <= cPrev + 1e-6f) return (binStart + binEnd) * 0.5f;

            var f = Mathf.InverseLerp(cPrev, cHere, u);
            return Mathf.Lerp(binStart, binEnd, f);
        }

        private static int HashCurve(AnimationCurve curve)
        {
            if (curve == null || curve.keys == null) return 0;
            unchecked
            {
                var h = 17;
                var keys = curve.keys;
                for (var i = 0; i < keys.Length; i++)
                {
                    var k = keys[i];
                    h = h * 31 + k.time.GetHashCode();
                    h = h * 31 + k.value.GetHashCode();
                    h = h * 31 + k.inTangent.GetHashCode();
                    h = h * 31 + k.outTangent.GetHashCode();
                    h = h * 31 + k.weightedMode.GetHashCode();
                    h = h * 31 + k.inWeight.GetHashCode();
                    h = h * 31 + k.outWeight.GetHashCode();
                }
                h = h * 31 + curve.preWrapMode.GetHashCode();
                h = h * 31 + curve.postWrapMode.GetHashCode();
                return h;
            }
        }
    }
}
