using System;
using System.Collections;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(IListVariable), typeof(bool), "isEmpty", false)]
    public class ListIsEmptyVariable : BaseVariableProperty<IList,  bool>
    {
        public override string PropertyName => "isEmpty";
        
#if UNITY_EDITOR
        public override string Description => "Is the list empty?";
#endif

        public override bool Value
        {
            get => (TargetAs<IListVariable>()?.Count ?? 0) == 0;
            set { }
        }
    }
}
