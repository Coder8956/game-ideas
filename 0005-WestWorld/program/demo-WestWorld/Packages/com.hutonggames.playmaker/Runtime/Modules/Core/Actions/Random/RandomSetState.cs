// Maybe expose as advanced action?
// using System;
// using System.IO.Pipes;
// using JetBrains.Annotations;
// using UnityEngine;
// using UnityEngine.Serialization;
// using Random = UnityEngine.Random;
//
// namespace HutongGames.PlayMaker.Actions
// {
//     [Serializable, PublicAPI]
//     [ActionCategory(Category.Random)]
//     [ActionDescription("Sets the full internal state of the random number generator.")]
//     [HelpURL("https://docs.unity3d.com/ScriptReference/Random-state.html")]
//     public class RandomSetState : BaseAction
//     {
//         [Tooltip("Set the internal state of the random number generator " +
//                  "using a state previously saved with the GetRandomState action.")]
//         public RandomStateRef RandomState;
//         
//         public override bool CanExecute() => CheckParameters(RandomState);
//
//         public override void Execute() => Random.state = RandomState.Value;
//     }
// }