
using System;
using HutongGames.PlayMaker.Actions;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [EventData(typeof(OnControllerColliderHitEvent))] 
    public class ControllerColliderHitDataGetter : BaseEventDataGetter
    {
        [OptionalField, WriteOnly]
        [Tooltip("Hit data.")]
        public ControllerColliderHitRef ControllerColliderHit = new();

        public override void GetDataFromEvent(BaseEvent baseEvent)
        {
            if (baseEvent is not OnControllerColliderHitEvent controllerColliderHitEvent)
            {
                Debug.LogWarning($"{baseEvent.Name} Event is not OnControllerColliderHitEvent!");
                return;
            }
            
            base.GetDataFromEvent(baseEvent);

            if (ControllerColliderHit.IsAssigned)
            {
                ControllerColliderHit.Value = controllerColliderHitEvent.ControllerColliderHit;
            }
        }
    }

    [System.Serializable]
    [SystemEvent(SystemEvents.PhysicsRoot)]
    [Tooltip("OnControllerColliderHit is called when the controller hits a collider while performing a Move." +
             "\n\nThis can be used to push objects when they collide with the character.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnControllerColliderHit.html")]
    public class OnControllerColliderHitEvent : BaseSystemProxyEvent<OnControllerColliderHitEvent, OnControllerColliderHitProxyComponent>
    {
        public ControllerColliderHit ControllerColliderHit { get; private set; }
        
        public static OnControllerColliderHitEvent Init(ControllerColliderHit controllerColliderHit)
        {
            Instance.ControllerColliderHit = controllerColliderHit;
            return Instance;
        }
        
        public override BaseEventDataGetter GetEventDataGetter() => new ControllerColliderHitDataGetter();
    }
    
    public class OnControllerColliderHitProxyComponent : BaseProxyEventComponent
    {
        public void OnControllerColliderHit(ControllerColliderHit controllerColliderHit)
        {
            var evt = OnControllerColliderHitEvent.Init(controllerColliderHit);
            SendEvent(evt);
        }
    }
}
