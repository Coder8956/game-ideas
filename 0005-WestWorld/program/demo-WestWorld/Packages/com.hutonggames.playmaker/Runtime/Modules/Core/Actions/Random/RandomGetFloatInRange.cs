using System;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.Random)]
    [ConvertibleGroup(ConvertibleGroup.RandomFloat)]
    [ActionDescription("Get a random float between Min Value and Max Value (range is inclusive).")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Random.Range.html")]
    public class RandomGetFloatInRange : BaseAction
    {
        [Tooltip("The minimum value.")]
        public FloatVar MinValue;

        [DefaultValue(1f)]
        [Tooltip("The maximum value.")]
        public FloatVar MaxValue;

        [WriteOnly]
        [Tooltip("Store the random value in a float variable.")]
        public FloatRef StoreResult;
        
        public override bool CanExecute() => CheckParameters(MinValue, MaxValue, StoreResult);

        public override void Execute() => StoreResult.Value = Random.Range(MinValue.Value, MaxValue.Value);

        public override string GetSummary()
        {
            return "Get float between {MinValue} and {MaxValue} -> {StoreResult}";
            // return "{StoreResult} = Random.Range({MinValue}, {MaxValue})";
        }
    }
}