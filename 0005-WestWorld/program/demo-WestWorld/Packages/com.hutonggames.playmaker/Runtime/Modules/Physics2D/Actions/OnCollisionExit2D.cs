using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.Collision2DEvents)]
    [ConvertibleGroup("Physics2DEvents")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnCollisionExit2D.html")]
    public class OnCollisionExit2D : BaseCollision2DEventAction<OnCollisionExit2DEvent>
    {
    }
}