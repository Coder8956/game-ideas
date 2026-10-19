using UnityEngine;

namespace HutongGames.PlayMaker
{
    [System.Serializable]
    [SystemEvent("Mouse")]
    [Tooltip("Sent when the user has pressed the mouse button while over the Collider.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnMouseDown.html")]
    public class OnMouseDownEvent : BaseSystemProxyEvent<OnMouseDownEvent, OnMouseProxyComponent>
    {
        public override bool HasData => false;
    }
}