using System;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.Random)]
    [ActionDescription("Initializes the random number generator state with a seed.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Random.InitState.html")]
    public class RandomInitState : BaseAction
    {
        [DefaultValue(1234)] [Tooltip("Seed for the random number generator.")]
        public IntegerVar Seed;

        public override bool CanExecute() => CheckParameters(Seed);

        public override void Execute() => Random.InitState(Seed.Value);

        public override string GetSummary() => "Set Random Seed {Seed}";
    }
}