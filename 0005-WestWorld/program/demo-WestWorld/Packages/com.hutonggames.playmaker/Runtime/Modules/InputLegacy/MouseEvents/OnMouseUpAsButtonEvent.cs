using UnityEngine;

namespace HutongGames.PlayMaker
{
    [System.Serializable]
    [SystemEvent("Mouse")]
    [Tooltip("Sent when the mouse is released over the same Collider as it was pressed.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnMouseUp.html")]
    public class OnMouseUpAsButtonEvent : BaseSystemProxyEvent<OnMouseUpAsButtonEvent, OnMouseProxyComponent>
    {
        public override bool HasData => false;
    }
}