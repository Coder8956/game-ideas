using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [EventData(typeof(OnAnimatorIKEvent))] 
    public class AnimatorIKDataGetter : BaseEventDataGetter
    {
        [OptionalField, WriteOnly]
        [Tooltip("The index of the layer on which the IK solver is called.")]
        public IntegerRef Layer = new();

        public override void GetDataFromEvent(BaseEvent baseEvent)
        {
            if (baseEvent is not OnAnimatorIKEvent onAnimatorIKEvent)
            {
                Debug.LogWarning($"{baseEvent.Name} Event is not OnAnimatorIKEvent!");
                return;
            }
            
            base.GetDataFromEvent(baseEvent);

            if (Layer.IsAssigned)
            {
                Layer.Value = onAnimatorIKEvent.Layer;
            }
        }
    }
    
    [System.Serializable]
    [SystemEvent(SystemEvents.PhysicsRoot)]
    [Tooltip("Callback for setting up animation IK (inverse kinematics).")]
    public class OnAnimatorIKEvent : BaseSystemProxyEvent<OnAnimatorIKEvent, OnAnimatorIKProxyComponent>
    {
        public static OnAnimatorIKEvent Init(int layer)
        {
            Instance.Layer = layer;
            return Instance;
        }

        public int Layer { get; private set; }
        
        public override BaseEventDataGetter GetEventDataGetter() => new AnimatorIKDataGetter();
    }
    
    public class OnAnimatorIKProxyComponent : BaseProxyEventComponent
    {
        public void OnAnimatorIK(int layer)
        {
            var onAnimatorIKEvent = OnAnimatorIKEvent.Init(layer);
            SendEvent(onAnimatorIKEvent);
        }
    }
}