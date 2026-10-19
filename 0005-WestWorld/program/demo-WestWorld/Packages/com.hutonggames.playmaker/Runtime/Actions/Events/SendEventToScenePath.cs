using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Events)]
    [ConvertibleGroup(ConvertibleGroup.SendEvent)]
    [ActionDescription("Send a Global Event to active FSMs on GameObjects that match a scene hierarchy path.\n" +
                       "<br/>Supports segment globs:\n" +
                       "- '*' matches within one path segment.\n" +
                       "- '**' matches across multiple path segments.\n" +
                       "- '?' matches one character in a segment.\n" +
                       "<br/>Examples:\n" +
                       "- 'enemies/*'\n" +
                       "- '**/zombie*'\n" +
                       "<br/>Optional scene filter: 'SceneName:path/pattern'.\n" +
                       "- 'Level02:enemies/**/zombie?'")]
    public class SendEventToScenePath : BaseDelayedEventAction
    {
        [GlobalEvent]
        [Tooltip("The Global Event to send.")]
        public EventRef Event;

        [Tooltip("Hierarchy glob pattern:\nhero/sword\nenemies/*\n**/zombie*.<br/>Optional scene filter: \nSceneName:pattern")]
        public StringVar ScenePath;

        [OptionalField]
        [Tooltip("Optional FSM name filter. If set, only matching FSM names will receive the event.")]
        public StringVar FsmName;

        public override bool CanExecute() =>
            CheckParameters(Event, ScenePath) && Event.IsGlobalEvent;

        public override string ErrorCheck() => !Event.IsGlobalEvent ? "Event must be a Global Event!" : null;

        public override void Execute()
        {
            if (!CheckTimer()) return;
            if (Event.Event is not GlobalEvent globalEvent) return;
            if (!TryParsePattern(ScenePath.Value, out var scenePattern, out var pathPatternSegments)) return;

            var evt = Event.GetRuntimeEvent(new EventSender(this));
            var activeFsms = PlayMakerUpdate.GetAllActiveFsmNodes();
            foreach (var fsm in activeFsms)
            {
                var fsmComponent = fsm?.FsmComponent;
                if (!IsValidTarget(fsmComponent)) continue;
                if (!IsMatchingFsmName(fsmComponent, FsmName.Value)) continue;
                if (!IsMatchingScene(fsmComponent, scenePattern)) continue;

                var fsmPathSegments = GetScenePathSegments(fsmComponent.GameObject.transform);
                if (!IsPathMatch(fsmPathSegments, pathPatternSegments)) continue;

                // Keep GlobalEvent routing semantics (subscriber-checked delivery).
                globalEvent.SendToFsmComponent(evt, fsmComponent);
            }
        }

        private static bool IsValidTarget(BaseFsmComponent fsmComponent) =>
            fsmComponent != null && fsmComponent.GameObject != null;

        private static bool IsMatchingFsmName(BaseFsmComponent fsmComponent, string fsmName) =>
            string.IsNullOrWhiteSpace(fsmName) || fsmComponent.Fsm?.Name == fsmName;

        private static bool IsMatchingScene(BaseFsmComponent fsmComponent, string scenePattern)
        {
            if (string.IsNullOrWhiteSpace(scenePattern)) return true;
            var sceneName = fsmComponent.GameObject.scene.name;
            return IsSegmentMatch(sceneName, scenePattern);
        }

        private static string[] GetScenePathSegments(Transform transform)
        {
            if (transform == null) return System.Array.Empty<string>();

            var path = transform.name;
            while (transform.parent != null)
            {
                transform = transform.parent;
                path = transform.name + "/" + path;
            }

            return SplitPath(path);
        }

        private static string NormalizePath(string path) =>
            string.IsNullOrWhiteSpace(path)
                ? ""
                : path.Trim().Trim('/').Replace('\\', '/');

        private static bool TryParsePattern(string rawPattern, out string scenePattern, out string[] pathPatternSegments)
        {
            scenePattern = "";
            pathPatternSegments = System.Array.Empty<string>();

            var pattern = NormalizePath(rawPattern);
            if (string.IsNullOrEmpty(pattern)) return false;

            var sceneDelimiterIndex = pattern.IndexOf(':');
            if (sceneDelimiterIndex > 0)
            {
                scenePattern = pattern.Substring(0, sceneDelimiterIndex).Trim();
                pattern = NormalizePath(pattern.Substring(sceneDelimiterIndex + 1));
                if (string.IsNullOrEmpty(scenePattern) || string.IsNullOrEmpty(pattern))
                {
                    return false;
                }
            }

            pathPatternSegments = SplitPath(pattern);
            return pathPatternSegments.Length > 0;
        }

        private static string[] SplitPath(string path) =>
            string.IsNullOrEmpty(path)
                ? System.Array.Empty<string>()
                : path.Split('/');

        private static bool IsPathMatch(string[] pathSegments, string[] patternSegments)
        {
            var memo = new Dictionary<long, bool>();
            return IsPathMatch(pathSegments, 0, patternSegments, 0, memo);
        }

        private static bool IsPathMatch(
            string[] pathSegments,
            int pathIndex,
            string[] patternSegments,
            int patternIndex,
            Dictionary<long, bool> memo)
        {
            var memoKey = ((long)pathIndex << 32) | (uint)patternIndex;
            if (memo.TryGetValue(memoKey, out var cachedResult)) return cachedResult;

            bool result;
            if (patternIndex == patternSegments.Length)
            {
                result = pathIndex == pathSegments.Length;
            }
            else
            {
                var patternSegment = patternSegments[patternIndex];
                if (patternSegment == "**")
                {
                    result = IsPathMatch(pathSegments, pathIndex, patternSegments, patternIndex + 1, memo) ||
                             (pathIndex < pathSegments.Length &&
                              IsPathMatch(pathSegments, pathIndex + 1, patternSegments, patternIndex, memo));
                }
                else
                {
                    result = pathIndex < pathSegments.Length &&
                             IsSegmentMatch(pathSegments[pathIndex], patternSegment) &&
                             IsPathMatch(pathSegments, pathIndex + 1, patternSegments, patternIndex + 1, memo);
                }
            }

            memo[memoKey] = result;
            return result;
        }

        private static bool IsSegmentMatch(string text, string pattern)
        {
            text ??= "";
            pattern ??= "";

            var textIndex = 0;
            var patternIndex = 0;
            var starPatternIndex = -1;
            var starTextIndex = 0;

            while (textIndex < text.Length)
            {
                if (patternIndex < pattern.Length &&
                    (pattern[patternIndex] == '?' || pattern[patternIndex] == text[textIndex]))
                {
                    textIndex++;
                    patternIndex++;
                    continue;
                }

                if (patternIndex < pattern.Length && pattern[patternIndex] == '*')
                {
                    starPatternIndex = patternIndex++;
                    starTextIndex = textIndex;
                    continue;
                }

                if (starPatternIndex >= 0)
                {
                    patternIndex = starPatternIndex + 1;
                    textIndex = ++starTextIndex;
                    continue;
                }

                return false;
            }

            while (patternIndex < pattern.Length && pattern[patternIndex] == '*')
            {
                patternIndex++;
            }

            return patternIndex == pattern.Length;
        }

        public override string GetSummary()
        {
            var summary = "Send {Event} to {ScenePath} scene path";
            if (FsmName.IsNotDefault())
            {
                summary += " FSM: {FsmName}";
            }
            summary += base.GetSummary();
            return summary;
        }
    }
}
