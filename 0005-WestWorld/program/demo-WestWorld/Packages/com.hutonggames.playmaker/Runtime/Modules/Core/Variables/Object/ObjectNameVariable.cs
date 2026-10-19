using System;
using Object = UnityEngine.Object;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(ObjectVariable), typeof(string), "name")]
    public class ObjectNameVariable : BaseVariableProperty<Object, string>
    {
        public override string PropertyName => "name";
        
#if UNITY_EDITOR
        public override string Description => "The Object Name.";
#endif

        protected Object Obj => TargetAs<Variable<Object>>()?.Value;
        
        public override string Value
        {
            get => Obj != null ? Obj.name : string.Empty;
            set
            {
                if (Obj) Obj.name = value;
            }
        }
    }
}
