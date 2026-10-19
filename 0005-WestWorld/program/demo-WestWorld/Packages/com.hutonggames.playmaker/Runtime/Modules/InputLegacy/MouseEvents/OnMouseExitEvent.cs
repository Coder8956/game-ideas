using UnityEngine;

namespace HutongGames.PlayMaker
{
    [System.Serializable]
    [SystemEvent("Mouse")]
    [Tooltip("Sent when the mouse is not any longer over the Collider.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnMouseExit.html")]
    public class OnMouseExitEvent : BaseSystemProxyEvent<OnMouseExitEvent, OnMouseProxyComponent>
    {
        public override bool HasData => false;
    }
}