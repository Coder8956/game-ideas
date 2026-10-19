using System;
using HutongGames.PlayMaker.Actions;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(SpriteVariable), typeof(string), "name")]
    public class SpriteNameVariable : BaseVariableProperty<Sprite, string>
    {
        public override string PropertyName => "name";
        
#if UNITY_EDITOR
        public override string Description => "The Sprite Name.";
#endif
        
        protected Sprite Sprite => TargetAs<Variable<Sprite>>()?.Value;

        public override string Value
        {
            get => Sprite ? Sprite.name : string.Empty;
            set
            {
                if (Sprite) Sprite.name = value;
            }
        }
    }
}
