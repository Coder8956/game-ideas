using System;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(TransformVariable), typeof(string), "name")]
    public class TransformNameVariable : BaseTransformProperty<string>
    {
        public override string PropertyName => "name";
        
#if UNITY_EDITOR
        public override string Description => "The Transform's Name.";
#endif
        
        public override string Value
        {
            get => Transform ? Transform.name : string.Empty;
            set
            {
                if (Transform) Transform.name = value;
            }
        }
    }
}