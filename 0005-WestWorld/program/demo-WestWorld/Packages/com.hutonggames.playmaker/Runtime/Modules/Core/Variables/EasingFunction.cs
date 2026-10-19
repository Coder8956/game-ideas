
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(EasingFunction.Ease))]
	public sealed partial class EasingFunctionVariable : Variable<EasingFunction.Ease>
	{
		
		public EasingFunctionVariable()
		{
		}
		
		public EasingFunctionVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(EasingFunction.Ease))]
	public sealed partial class EasingFunctionListVariable : ListVariable<EasingFunction.Ease>
	{
		
		public EasingFunctionListVariable()
		{
		}
		
		public EasingFunctionListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(EasingFunction.Ease))]
	public sealed partial class EasingFunctionRef : VariableRef<EasingFunction.Ease>
	{
	}
	
	[Serializable]
	[DataType(typeof(EasingFunction.Ease))]
	public sealed partial class EasingFunctionVar : VariableVar<EasingFunction.Ease>
	{
	}
	
	[Serializable]
	[DataType(typeof(EasingFunction.Ease))]
	public sealed partial class EasingFunctionOverride : VariableOverride<EasingFunction.Ease,EasingFunctionVariable,EasingFunctionVar>
	{
		
		public EasingFunctionOverride(IVariable variable) : 
			base(variable)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(EasingFunction.Ease))]
	public sealed partial class EasingFunctionOutput : VariableOutput<EasingFunction.Ease,EasingFunctionVariable,EasingFunctionRef>
	{
		
		public EasingFunctionOutput(IVariable variable) : 
			base(variable)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(EasingFunction.Ease))]
	public sealed partial class EasingFunctionListRef : ListVariableRef<EasingFunction.Ease>
	{
	}
	
	[Serializable]
	[DataType(typeof(EasingFunction.Ease))]
	public sealed partial class EasingFunctionListVar : ListVariableVar<EasingFunction.Ease>
	{
	}
}
