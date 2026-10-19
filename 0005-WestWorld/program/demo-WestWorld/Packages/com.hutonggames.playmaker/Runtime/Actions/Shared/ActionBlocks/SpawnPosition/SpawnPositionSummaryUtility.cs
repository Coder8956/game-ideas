using System;
using System.Collections.Generic;
using System.Linq;
using HutongGames.Reflection;

namespace HutongGames.PlayMaker.Actions
{
    internal static class SpawnPositionSummaryUtility
    {
        public static string GetBlockListSummary<TBlock>(IEnumerable<TBlock> blocks)
            where TBlock : BaseActionBlock
        {
            if (blocks == null) return string.Empty;

            var activeBlocks = blocks
                .Where(block => block != null)
                .ToList();

            if (activeBlocks.Count == 0) return string.Empty;

            var firstBlockName = GetBlockDisplayName(activeBlocks[0].GetType());
            var additionalCount = activeBlocks.Count - 1;

            return additionalCount > 0
                ? $" -> {firstBlockName} +{additionalCount}"
                : $" -> {firstBlockName}";
        }

        public static string GetBlockDisplayName(Type blockType)
        {
            var displayName = blockType.GetAttribute<DisplayNameAttribute>()?.Name;
            if (!string.IsNullOrEmpty(displayName)) return displayName;

            const string suffix = "Block";
            var typeName = blockType.Name;
            return typeName.EndsWith(suffix, StringComparison.Ordinal)
                ? typeName[..^suffix.Length]
                : typeName;
        }
    }
}
