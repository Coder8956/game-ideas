using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.BufferedInput)]
    [ConvertibleGroup("CheckBufferedInput")]
    [ActionDescription("Check if two BufferedInputs form a chord (pressed within a short time of each other).")]
    [HelpURL("actions/input-actions/buffered-input/")]
    public sealed class CheckBufferedChord : BaseTrueFalseAction
    {
        [Tooltip("First buffered input in the chord.")]
        public BufferedInputRef InputA;

        [Tooltip("Second buffered input in the chord.")]
        public BufferedInputRef InputB;

        [Tooltip("Maximum time difference (in seconds) between the two presses to count as a chord.")]
        [DefaultValue(0.05f)]
        public FloatVar MaxChordWindow;

        [Tooltip("Require both inputs to still be fresh (unconsumed and within their own buffer windows).")]
        [DefaultValue(true)]
        public BoolVar RequireFreshInputs;

        [Tooltip("If true, consume buffered presses when the chord succeeds.")]
        [DefaultValue(true)]
        public BoolVar ConsumeBufferedPresses;
        
        protected override string TrueSummary  => "{InputA} + {InputB} pressed together";
        protected override string FalseSummary => "{InputA} + {InputB} not pressed together";

        public override bool CanExecute() => CheckParameters(InputA, InputB, MaxChordWindow);

        protected override bool Test()
        {
            if (InputA.IsNone || InputB.IsNone || MaxChordWindow.IsNone)
                return false;

            var a = InputA.Value;
            var b = InputB.Value;
            
            // Must have been pressed at least once
            if (a.NeverPressed || b.NeverPressed)
                return false;

            if (!RequireFreshInputs.IsNone && RequireFreshInputs.Value)
            {
                if (!a.IsFresh || !b.IsFresh)
                    return false;
            }

            var diff = Mathf.Abs(a.LastPressedTime - b.LastPressedTime);
            var chordMatched = diff <= MaxChordWindow.Value;
            
            if (chordMatched)
            {
                var consume = !ConsumeBufferedPresses.IsNone && ConsumeBufferedPresses.Value;
                if (consume)
                {
                    // Only consumes if actually available; no harm if already consumed.
                    if (a.IsFresh)
                    {
                        a.ConsumeIfFresh();
                        InputA.Value = a;
                    }

                    if (b.IsFresh)
                    {
                        b.ConsumeIfFresh();
                        InputB.Value = b;
                    }
                }

                return true;
            }

            return false;
        }
    }
}