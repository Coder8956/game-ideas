
using System;
using HutongGames.PlayMaker.Actions;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [EventData(typeof(OnJointBreak2DEvent))] 
    public class JointBreak2DDataGetter : BaseEventDataGetter
    {
        [OptionalField, WriteOnly]
        [Tooltip("The Joint2D that broke.")]
        public Joint2DRef BrokenJoint = new();

        public override void GetDataFromEvent(BaseEvent baseEvent)
        {
            if (baseEvent is not OnJointBreak2DEvent onJointBreak2DEvent)
            {
                Debug.LogWarning($"{baseEvent.Name} Event is not OnJointBreak2DEvent!");
                return;
            }
            
            base.GetDataFromEvent(baseEvent);

            if (BrokenJoint.IsAssigned)
            {
                BrokenJoint.Value = onJointBreak2DEvent.BrokenJoint;
            }
        }
    }

    [System.Serializable]
    [SystemEvent(SystemEvents.Physics2DRoot)]
    [Tooltip("Sent when a Joint2D attached to the same game object broke.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnJointBreak2D.html")]
    public class OnJointBreak2DEvent : BaseSystemProxyEvent<OnJointBreak2DEvent, OnJointBreak2DProxyComponent>
    {
        public Joint2D BrokenJoint { get; private set; }
        
        public static OnJointBreak2DEvent Init(Joint2D brokenJoint)
        {
            Instance.BrokenJoint = brokenJoint;
            return Instance;
        }
        
        public override BaseEventDataGetter GetEventDataGetter() => new JointBreak2DDataGetter();
    }
    
    public class OnJointBreak2DProxyComponent : BaseProxyEventComponent
    {
        public void OnJointBreak2D(Joint2D brokenJoint)
        {
            var evt = OnJointBreak2DEvent.Init(brokenJoint);
            SendEvent(evt);
        }
    }
}
