using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.Collision2DEvents)]
    [ConvertibleGroup("Physics2DEvents")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnTriggerEnter2D.html")]
    public class OnTriggerEnter2D : BaseTrigger2DEventAction<OnTriggerEnter2DEvent>
    {
    }
}