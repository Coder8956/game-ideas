using System;

namespace HutongGames.PlayMaker
{
    [Serializable]
    public abstract class BaseIntPredicate : BasePredicate<int>
    {
        public IntegerVar Parameter;

        public override bool Evaluate(object parameter) => DoEvaluate(Convert.ToInt32(parameter));

        public override string ToString() => $"{GetName()} {Parameter}";
    }

    [Serializable, DisplayName("Equals")]
    public class IntEqualPredicate : BaseIntPredicate
    {
        protected override bool DoEvaluate(int value) => value == Parameter.Value;

        public override string ToString() => "Equals {Parameter}";
    }

    [Serializable, DisplayName("Greater Than Or Equal To")]
    public class IntGreaterThanOrEqualPredicate : BaseIntPredicate
    {
        protected override bool DoEvaluate(int value) => value >= Parameter.Value;
    }

    [Serializable, DisplayName("Greater Than")]
    public class IntGreaterThanPredicate : BaseIntPredicate
    {
        protected override bool DoEvaluate(int value) => value > Parameter.Value;
    }

    [Serializable, DisplayName("Less Than Or Equal To")]
    public class IntLessThanOrEqualPredicate : BaseIntPredicate
    {
        protected override bool DoEvaluate(int value) => value <= Parameter.Value;
    }

    [Serializable, DisplayName("Less Than")]
    public class IntLessThanPredicate : BaseIntPredicate
    {
        protected override bool DoEvaluate(int value) => value < Parameter.Value;
    }
}
