using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace HutongGames.PlayMaker
{
    [Serializable, ConstantValue, HideDebugValue]
    [DataType(typeof(EventSystem))]
    public sealed class EventSystemCurrentValue : Variable<EventSystem>
    {
        public override string Name => "EventSystem.current";
        public override EventSystem Value => EventSystem.current;
        
        #if UNITY_EDITOR
        public override string Description => "Return the current EventSystem.";
        
        #endif
    }
}