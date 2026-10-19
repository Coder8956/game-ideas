using System;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(EnumVariable), typeof(int), "intValue", false)]
    public class EnumIntValueVariable : BaseVariableProperty<Enum, int>
    {
        public override string PropertyName => "intValue";

#if UNITY_EDITOR
        public override string Description => "The integer value of the selected enum option.";
#endif

        public override int Value
        {
            get
            {
                var value = Target?.GetValue();
                return value is Enum enumValue ? Convert.ToInt32(enumValue) : 0;
            }
            set { }
        }
    }
}
