
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.CanvasGroup))]
	public sealed partial class CanvasGroupVariable : Variable<UnityEngine.CanvasGroup>
	{
		
		public CanvasGroupVariable()
		{
		}
		
		public CanvasGroupVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CanvasGroup))]
	public sealed partial class CanvasGroupListVariable : ListVariable<UnityEngine.CanvasGroup>
	{
		
		public CanvasGroupListVariable()
		{
		}
		
		public CanvasGroupListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CanvasGroup))]
	public sealed partial class CanvasGroupRef : BaseComponentRef<UnityEngine.CanvasGroup>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CanvasGroup))]
	public sealed partial class CanvasGroupVar : BaseComponentVar<UnityEngine.CanvasGroup>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CanvasGroup))]
	public sealed partial class CanvasGroupListRef : ListVariableRef<UnityEngine.CanvasGroup>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CanvasGroup))]
	public sealed partial class CanvasGroupListVar : ListVariableVar<UnityEngine.CanvasGroup>
	{
	}

	[Serializable]
	[DataType(typeof(UnityEngine.CanvasGroup))]
	public sealed partial class CanvasGroupOverride : VariableOverride<UnityEngine.CanvasGroup, CanvasGroupVariable, CanvasGroupVar>
	{
		public CanvasGroupOverride(IVariable variable) : base(variable)
		{
		}
	}

	[Serializable]
	[DataType(typeof(UnityEngine.CanvasGroup))]
	public sealed partial class CanvasGroupOutput : VariableOutput<UnityEngine.CanvasGroup, CanvasGroupVariable, CanvasGroupRef>
	{
		public CanvasGroupOutput(IVariable variable) : base(variable)
		{
		}
	}

	[Serializable]
	[DataType(typeof(UnityEngine.CanvasGroup))]
	public sealed partial class CanvasGroupListOverride : VariableOverride<System.Collections.Generic.List<UnityEngine.CanvasGroup>, CanvasGroupListVariable, CanvasGroupListVar>
	{
		public CanvasGroupListOverride(IVariable variable) : base(variable)
		{
		}
	}

	[Serializable]
	[DataType(typeof(UnityEngine.CanvasGroup))]
	public sealed partial class CanvasGroupListOutput : VariableOutput<System.Collections.Generic.List<UnityEngine.CanvasGroup>, CanvasGroupListVariable, CanvasGroupListRef>
	{
		public CanvasGroupListOutput(IVariable variable) : base(variable)
		{
		}
	}
}
