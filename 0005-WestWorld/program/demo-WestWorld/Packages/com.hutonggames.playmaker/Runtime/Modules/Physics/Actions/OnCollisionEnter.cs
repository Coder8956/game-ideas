using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.CollisionEvents)]
    [ConvertibleGroup("PhysicsEvents")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnCollisionEnter.html")]
    public class OnCollisionEnter : BaseCollisionEventAction<OnCollisionEnterEvent>
    {
    }
}