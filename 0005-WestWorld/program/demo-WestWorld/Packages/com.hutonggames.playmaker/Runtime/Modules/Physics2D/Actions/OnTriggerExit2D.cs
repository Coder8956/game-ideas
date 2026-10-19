using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.Collision2DEvents)]
    [ConvertibleGroup("Physics2DEvents")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnTriggerExit2D.html")]
    public class OnTriggerExit2D : BaseTrigger2DEventAction<OnTriggerExit2DEvent>
    {
    }
}