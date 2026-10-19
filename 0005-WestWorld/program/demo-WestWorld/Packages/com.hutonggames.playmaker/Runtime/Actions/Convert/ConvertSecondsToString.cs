using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Convert)]
    [ActionDescription("Convert seconds to a formatted time String using a TimeSpan.\n" +
                       "Format placeholders:\n" +
                       "{0}=Days, {1}=Hours, {2}=Minutes, {3}=Seconds, {4}=Milliseconds,\n" +
                       "{5}=TotalDays, {6}=TotalHours, {7}=TotalMinutes, {8}=TotalSeconds, {9}=TotalMilliseconds,\n" +
                       "{10}=Two-digit milliseconds.")]
    public sealed class ConvertSecondsToString : BaseAction
    {
        [ActionTarget]
        [Tooltip("The seconds value to convert.")]
        [SerializeField]
        private FloatRef _seconds;

        [Tooltip("A String to store the formatted time.")]
        [SerializeField, WriteOnly]
        private StringRef _string;

        [Tooltip("Format string using placeholders {0}..{10}.")]
        [SerializeField, DefaultValue("{1:D2}h:{2:D2}m:{3:D2}s:{10}ms")]
        private StringVar _format;

        public override bool CanExecute() => CheckParameters(_seconds, _string, _format);
        
        public override void Execute()
        {
            var t = TimeSpan.FromSeconds(_seconds.Value);

            // Two-digit milliseconds (first two digits of a 3-digit ms string)
            var ms2 = t.Milliseconds.ToString("D3");
            ms2 = ms2[..2];

            _string.Value = string.Format(
                _format.Value,
                t.Days,               // 0
                t.Hours,              // 1
                t.Minutes,            // 2
                t.Seconds,            // 3
                t.Milliseconds,       // 4
                t.TotalDays,          // 5
                t.TotalHours,         // 6
                t.TotalMinutes,       // 7
                t.TotalSeconds,       // 8
                t.TotalMilliseconds,  // 9
                ms2                  // 10
            );
        }

        public override string GetSummary() => "Convert {_seconds} seconds -> {_string}";
    }
}
