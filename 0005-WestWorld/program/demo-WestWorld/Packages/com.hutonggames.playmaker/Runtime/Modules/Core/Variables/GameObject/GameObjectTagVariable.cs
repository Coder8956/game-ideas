using System;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(GameObjectVariable), typeof(string), "tag")]
    public class GameObjectTagVariable : BaseGameObjectProperty<string>
    {
        public override string PropertyName => "tag";
        
#if UNITY_EDITOR
        public override string Description => "The GameObject Tag.";
#endif
        
        public override string Value
        {
            get => GameObject ? GameObject.tag : string.Empty;
            set
            {
                if (GameObject) GameObject.tag = value;
            }
        }
    }
}