namespace HutongGames.PlayMaker.Actions
{
    /// <summary>
    /// Helpers for runtime behavior of FsmVariableLink-based actions.
    /// </summary>
    internal static class FsmVariableLinkRuntimeHelpers
    {
        /// <summary>
        /// Logs a warning if the last resolution of this link used an ambiguous short-name.
        /// 
        /// Conditions:
        /// - No valid GUID on the link (name-based resolution).
        /// - FsmVariableLink.ResolveInternal() marked the last resolve as ambiguous.
        /// </summary>
        public static void LogAmbiguousShortNameWarning<T, TVariable>(
            this FsmVariableLink<T, TVariable> link,
            BaseAction ownerAction,
            IVariable resolved)
            where TVariable : Variable<T>
        {
            if (ownerAction == null) return;
            if (resolved == null) return;

            // Only interesting if:
            // - We resolved by name (no GUID), and
            // - Variables.FindVariableByName(...) reported an ambiguous short-name match.
            if (link.VariableGuid.IsValid || !link.LastResolveWasAmbiguousShortName)
                return;

            var name         = link.VariableName.Value;
            var resolvedName = string.IsNullOrEmpty(resolved.Name) ? "<unnamed>" : resolved.Name;

            ownerAction.LogWarning(
                $"Ambiguous variable reference \"{name}\". " +
                $"Resolved to \"{resolvedName}\", but multiple variables share this short name.");
        }
    }
}