/* Moved to dll
using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    public enum NumericComparisonOperation
    {
        EqualTo,
        GreaterThan,
        GreaterThanOrEqual,
        LessThan,
        LessThanOrEqual,
    }

    public static class ComparisonOperatorExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Evaluate(this NumericComparisonOperation op, float x, float y) => op switch
        {
            NumericComparisonOperation.EqualTo              => Mathf.Approximately(x, y), // note: epsilon-based
            NumericComparisonOperation.GreaterThan          => x >  y,
            NumericComparisonOperation.GreaterThanOrEqual   => x >= y,
            NumericComparisonOperation.LessThan             => x <  y,
            NumericComparisonOperation.LessThanOrEqual      => x <= y,
            _ => throw new ArgumentOutOfRangeException(nameof(op), op, null)
        };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Evaluate(this NumericComparisonOperation op, int x, int y) => op switch
        {
            NumericComparisonOperation.EqualTo              => x == y,
            NumericComparisonOperation.GreaterThan          => x >  y,
            NumericComparisonOperation.GreaterThanOrEqual   => x >= y,
            NumericComparisonOperation.LessThan             => x <  y,
            NumericComparisonOperation.LessThanOrEqual      => x <= y,
            _ => throw new ArgumentOutOfRangeException(nameof(op), op, null)
        };
    } 
}*/