using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(GameObjectVariable), typeof(bool), "isNotNull", false)]
    public class GameObjectIsNotNullVariable : BaseGameObjectProperty<bool>
    {
        public override string PropertyName => "isNotNull";
        
#if UNITY_EDITOR
        public override string Description => "Is the GameObject not null?";
#endif

        public override bool Value
        {
            get => GameObject != null;
            set {}
        }
    }
}