
using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [EventData(typeof(OnJointBreakEvent))] 
    public class JointBreakDataGetter : BaseEventDataGetter
    {
        [OptionalField, WriteOnly]
        [Tooltip("The force that broke the joint.")]
        public FloatRef BreakForce = new();

        public override void GetDataFromEvent(BaseEvent baseEvent)
        {
            if (baseEvent is not OnJointBreakEvent onJointBreakEvent)
            {
                Debug.LogWarning($"{baseEvent.Name} Event is not OnJointBreakEvent!");
                return;
            }
            
            base.GetDataFromEvent(baseEvent);

            if (BreakForce.IsAssigned)
            {
                BreakForce.Value = onJointBreakEvent.BreakForce;
            }
        }
    }

    [System.Serializable]
    [SystemEvent(SystemEvents.PhysicsRoot)]
    [Tooltip("Sent when a joint attached to the same game object broke.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnJointBreak.html")]
    public class OnJointBreakEvent : BaseSystemProxyEvent<OnJointBreakEvent, OnJointBreakProxyComponent>
    {
        public float BreakForce { get; private set; }
        
        public static OnJointBreakEvent Init(float breakForce)
        {
            Instance.BreakForce = breakForce;
            return Instance;
        }
        
        public override BaseEventDataGetter GetEventDataGetter() => new JointBreakDataGetter();
    }
    
    public class OnJointBreakProxyComponent : BaseProxyEventComponent
    {
        public void OnJointBreak(float breakForce)
        {
            var evt = OnJointBreakEvent.Init(breakForce);
            SendEvent(evt);
        }
    }
}
