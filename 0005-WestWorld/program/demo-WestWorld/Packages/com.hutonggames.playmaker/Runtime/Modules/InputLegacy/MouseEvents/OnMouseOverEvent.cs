using UnityEngine;

namespace HutongGames.PlayMaker
{
    [System.Serializable]
    [SystemEvent("Mouse")]
    [Tooltip("Sent every frame while the mouse is over the Collider.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnMouseOver.html")]
    public class OnMouseOverEvent : BaseSystemProxyEvent<OnMouseOverEvent, OnMouseOverProxyComponent>
    {
        public override bool HasData => false;
    }

    public class OnMouseOverProxyComponent : BaseProxyEventComponent
    {
        private int _lastMouseOverFrame = -1;

        public void OnMouseOver()
        {
            if (!IsDuplicateFrameEvent(ref _lastMouseOverFrame))
            {
                SendEvent(OnMouseOverEvent.Instance);
            }
        }
    }
}
