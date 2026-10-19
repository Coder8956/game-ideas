using UnityEngine;

namespace HutongGames.PlayMaker
{
    [System.Serializable]
    [SystemEvent("Mouse")]
    [Tooltip("Sent when the mouse enters the Collider.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnMouseEnter.html")]
    public class OnMouseEnterEvent : BaseSystemProxyEvent<OnMouseEnterEvent, OnMouseProxyComponent>
    {
        public override bool HasData => false;
    }
}