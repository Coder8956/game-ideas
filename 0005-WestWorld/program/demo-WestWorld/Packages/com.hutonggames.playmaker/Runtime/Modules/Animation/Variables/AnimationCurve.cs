
using System;
using UnityEngine;

// ReSharper disable PartialTypeWithSinglePart

namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(AnimationCurve))]
	public sealed partial class AnimationCurveVariable : Variable<AnimationCurve>
	{
		
		public AnimationCurveVariable()
		{
		}
		
		public AnimationCurveVariable(string name) : 
				base(name)
		{
		}

		public override IVariable Copy()
		{
			var copy = (AnimationCurveVariable)MemberwiseClone();
			copy._value = CopyCurve(_value);
			return copy;
		}

#if UNITY_EDITOR
		public override void CopyFrom(IVariable other)
		{
			base.CopyFrom(other);
			_value = CopyCurve(other?.GetValue() as AnimationCurve);
		}
#endif

		private static AnimationCurve CopyCurve(AnimationCurve curve)
		{
			if (curve == null)
			{
				return null;
			}

			return new AnimationCurve(curve.keys)
			{
				preWrapMode = curve.preWrapMode,
				postWrapMode = curve.postWrapMode
			};
		}
	}
	
	[Serializable]
	[DataType(typeof(AnimationCurve))]
	public sealed partial class AnimationCurveListVariable : ListVariable<AnimationCurve>
	{
		
		public AnimationCurveListVariable()
		{
		}
		
		public AnimationCurveListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(AnimationCurve))]
	public sealed partial class AnimationCurveRef : VariableRef<AnimationCurve>
	{
	}
	
	[Serializable]
	[DataType(typeof(AnimationCurve))]
	public sealed partial class AnimationCurveVar : VariableVar<AnimationCurve>
	{
		public bool HasCurve()
		{
			return IsVariable || Value is { keys: { Length: > 1 } };
		}
	}
	
	[Serializable]
	[DataType(typeof(AnimationCurve))]
	public sealed partial class AnimationCurveListRef : ListVariableRef<AnimationCurve>
	{
	}
	
	[Serializable]
	[DataType(typeof(AnimationCurve))]
	public sealed partial class AnimationCurveListVar : ListVariableVar<AnimationCurve>
	{
	}
	
	[Serializable]
	[DataType(typeof(AnimationCurve))]
	public sealed partial class AnimationCurveOverride : VariableOverride<AnimationCurve,AnimationCurveVariable,AnimationCurveVar>
	{
		
		public AnimationCurveOverride(IVariable variable) : 
				base(variable)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(AnimationCurve))]
	public sealed partial class AnimationCurveOutput : VariableOutput<AnimationCurve,AnimationCurveVariable,AnimationCurveRef>
	{
		
		public AnimationCurveOutput(IVariable variable) : 
				base(variable)
		{
		}
	}
}
