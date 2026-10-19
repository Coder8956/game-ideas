using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.Collision2DEvents)]
    [ConvertibleGroup("Physics2DEvents")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnTriggerStay2D.html")]
    public class OnTriggerStay2D : BaseTrigger2DEventAction<OnTriggerStay2DEvent>
    {
    }
}