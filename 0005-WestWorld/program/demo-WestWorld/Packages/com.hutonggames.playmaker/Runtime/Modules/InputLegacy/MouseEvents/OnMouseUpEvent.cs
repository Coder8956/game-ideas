using UnityEngine;

namespace HutongGames.PlayMaker
{
    [System.Serializable]
    [SystemEvent("Mouse")]
    [Tooltip("Sent when the user has released the mouse button.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnMouseUp.html")]
    public class OnMouseUpEvent : BaseSystemProxyEvent<OnMouseUpEvent, OnMouseProxyComponent>
    {
        public override bool HasData => false;
    }
}