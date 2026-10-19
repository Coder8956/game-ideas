/* Moved to dll
using System;
using System.Runtime.CompilerServices;

namespace HutongGames.PlayMaker.Actions
{
    public enum StringComparisonOperation
    {
        Equals,
        Contains,
        StartsWith,
        EndsWith
    }

    public static class StringComparisonExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Evaluate(this StringComparisonOperation op, string a, string b)
        {
            if (a == null || b == null)
                return false;

            return op switch
            {
                StringComparisonOperation.Equals =>
                    string.Equals(a, b, StringComparison.OrdinalIgnoreCase),

                StringComparisonOperation.Contains =>
                    a.IndexOf(b, StringComparison.OrdinalIgnoreCase) >= 0,

                StringComparisonOperation.StartsWith =>
                    a.StartsWith(b, StringComparison.OrdinalIgnoreCase),

                StringComparisonOperation.EndsWith =>
                    a.EndsWith(b, StringComparison.OrdinalIgnoreCase),

                _ => throw new ArgumentOutOfRangeException(nameof(op), op, null)
            };
        }
    } 
}*/