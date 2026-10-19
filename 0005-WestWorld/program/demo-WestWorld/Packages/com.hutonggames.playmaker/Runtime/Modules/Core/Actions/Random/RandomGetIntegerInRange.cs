using System;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.Random)]
    [ConvertibleGroup(ConvertibleGroup.RandomFloat)]
    [ActionDescription("Get a random integer between Min Value and Max Value. " +
                       "\n\nBy default, the range is exclusive, so for example Random.Range(0, 10) returns a random value between 0 and 9. " +
                       "Check <b>Inclusive</b> to make the range inclusive, so it returns a random value between 0 and 10.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Random.Range.html")]
    public class RandomGetIntegerInRange : BaseAction
    {
        [Tooltip("The minimum value.")]
        public IntegerVar MinValue;

        [DefaultValue(100)]
        [Tooltip("The maximum value (exclusive).")]
        public IntegerVar MaxValue;

        [Tooltip("Make the maximum value inclusive.")]
        public BoolVar Inclusive;
        
        [WriteOnly]
        [Tooltip("Store the random value in a float variable.")]
        public IntegerRef StoreResult;
        
        public override bool CanExecute() => CheckParameters(MinValue, MaxValue, StoreResult);

        public override void Execute()
        {
            var max = Inclusive.Value ? MaxValue.Value + 1 : MaxValue.Value;
            StoreResult.Value = Random.Range(MinValue.Value, max);
        }

        public override string GetSummary()
        {
            return "Get integer between {MinValue} and {MaxValue} (Inclusive:option) -> {StoreResult}";
        }
    }
}