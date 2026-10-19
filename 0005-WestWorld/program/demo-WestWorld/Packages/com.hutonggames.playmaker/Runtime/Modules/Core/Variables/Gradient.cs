
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Gradient))]
	public sealed partial class GradientVariable : Variable<UnityEngine.Gradient>
	{
		
		public GradientVariable()
		{
		}
		
		public GradientVariable(string name) : 
				base(name)
		{
		}

		public override IVariable Copy()
		{
			var copy = (GradientVariable)MemberwiseClone();
			copy._value = CopyGradient(_value);
			return copy;
		}

#if UNITY_EDITOR
		public override void CopyFrom(IVariable other)
		{
			base.CopyFrom(other);
			_value = CopyGradient(other?.GetValue() as UnityEngine.Gradient);
		}
#endif

		private static UnityEngine.Gradient CopyGradient(UnityEngine.Gradient gradient)
		{
			if (gradient == null)
			{
				return null;
			}

			var copy = new UnityEngine.Gradient
			{
				mode = gradient.mode
			};
			copy.SetKeys(gradient.colorKeys, gradient.alphaKeys);
			return copy;
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Gradient))]
	public sealed partial class GradientListVariable : ListVariable<UnityEngine.Gradient>
	{
		
		public GradientListVariable()
		{
		}
		
		public GradientListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Gradient))]
	public sealed partial class GradientRef : VariableRef<UnityEngine.Gradient>
	{
		public override bool HasValue(bool valueCanBeNullOrEmpty = false)
		{
			if (!base.HasValue(valueCanBeNullOrEmpty)) return false;
			return Value != null && Value.colorKeys.Length > 0;
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Gradient))]
	public sealed partial class GradientVar : VariableVar<UnityEngine.Gradient>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Gradient))]
	public sealed partial class GradientListRef : ListVariableRef<UnityEngine.Gradient>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Gradient))]
	public sealed partial class GradientListVar : ListVariableVar<UnityEngine.Gradient>
	{
	}

	[Serializable]
	[DataType(typeof(UnityEngine.Gradient))]
	public sealed partial class GradientOverride : VariableOverride<UnityEngine.Gradient, GradientVariable, GradientVar>
	{
		public GradientOverride(IVariable variable) : base(variable)
		{
		}
	}

	[Serializable]
	[DataType(typeof(UnityEngine.Gradient))]
	public sealed partial class GradientOutput : VariableOutput<UnityEngine.Gradient, GradientVariable, GradientRef>
	{
		public GradientOutput(IVariable variable) : base(variable)
		{
		}
	}

	[Serializable]
	[DataType(typeof(UnityEngine.Gradient))]
	public sealed partial class GradientListOverride : VariableOverride<System.Collections.Generic.List<UnityEngine.Gradient>, GradientListVariable, GradientListVar>
	{
		public GradientListOverride(IVariable variable) : base(variable)
		{
		}
	}

	[Serializable]
	[DataType(typeof(UnityEngine.Gradient))]
	public sealed partial class GradientListOutput : VariableOutput<System.Collections.Generic.List<UnityEngine.Gradient>, GradientListVariable, GradientListRef>
	{
		public GradientListOutput(IVariable variable) : base(variable)
		{
		}
	}
}
