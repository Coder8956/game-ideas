// Maybe expose as advanced action?
// using System;
// using JetBrains.Annotations;
// using UnityEngine;
// using Random = UnityEngine.Random;
//
// namespace HutongGames.PlayMaker.Actions
// {
//     [Serializable, PublicAPI]
//     [ActionCategory(Category.Random)]
//     [ActionDescription("Gets the full internal state of the random number generator.")]
//     [HelpURL("https://docs.unity3d.com/ScriptReference/Random-state.html")]
//     public class RandomGetState : BaseAction
//     {
//         [WriteOnly]
//         [Tooltip("Store the internal state of the random number generator.")]
//         public RandomStateRef StoreResult;
//         
//         public override bool CanExecute() => CheckParameters(StoreResult);
//
//         public override void Execute() => StoreResult.Value = Random.state;
//     }
// }