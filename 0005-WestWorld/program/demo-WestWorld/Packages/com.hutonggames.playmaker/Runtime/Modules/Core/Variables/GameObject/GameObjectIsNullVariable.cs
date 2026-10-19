using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(GameObjectVariable), typeof(bool), "isNull", false)]
    public class GameObjectIsNullVariable : BaseGameObjectProperty<bool>
    {
        public override string PropertyName => "isNull";
        
#if UNITY_EDITOR
        public override string Description => "Is the GameObject null?";
#endif

        public override bool Value
        {
            get => GameObject == null;
            set {}
        }
    }
}