using System;
using System.Collections;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(IListVariable), typeof(int), "count", false)]
    public class ListCountVariable : BaseVariableProperty<IList, int>
    {
        public override string PropertyName => "count";
        
#if UNITY_EDITOR
        public override string Description => "The number of items in a list.";
#endif

        public override int Value
        {
            get => TargetAs<IListVariable>()?.Count ?? 0;
            set { }
        }
    }
}
