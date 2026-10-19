using System;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(GameObjectVariable), typeof(string), "name")]
    public class GameObjectNameVariable : BaseGameObjectProperty<string>
    {
        public override string PropertyName => "name";
        
#if UNITY_EDITOR
        public override string Description => "The GameObject Name.";
#endif

        public override string Value
        {
            get => GameObject ? GameObject.name : string.Empty;
            set
            {
                if (GameObject) GameObject.name = value;
            }
        }
    }
}