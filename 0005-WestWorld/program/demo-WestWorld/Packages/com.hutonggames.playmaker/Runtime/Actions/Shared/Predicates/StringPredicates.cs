using System;

namespace HutongGames.PlayMaker
{
    [Serializable, DisplayName("Equal To")]
    public class StringEqualsPredicate : BasePredicate<string>
    {
        public StringVar Parameter;
        
        protected override bool DoEvaluate(string str) => str == Parameter.Value;

        public override string ToString() => $"Equals {Parameter}";
    }
}