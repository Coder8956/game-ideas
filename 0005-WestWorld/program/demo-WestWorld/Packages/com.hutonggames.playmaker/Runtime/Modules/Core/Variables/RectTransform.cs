
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.RectTransform))]
	public sealed partial class RectTransformVariable : Variable<UnityEngine.RectTransform>
	{
		
		public RectTransformVariable()
		{
		}
		
		public RectTransformVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RectTransform))]
	public sealed partial class RectTransformListVariable : ListVariable<UnityEngine.RectTransform>
	{
		
		public RectTransformListVariable()
		{
		}
		
		public RectTransformListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RectTransform))]
	public sealed partial class RectTransformRef : BaseComponentRef<UnityEngine.RectTransform>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RectTransform))]
	public sealed partial class RectTransformVar : BaseComponentVar<UnityEngine.RectTransform>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RectTransform))]
	public sealed partial class RectTransformListRef : ListVariableRef<UnityEngine.RectTransform>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RectTransform))]
	public sealed partial class RectTransformListVar : ListVariableVar<UnityEngine.RectTransform>
	{
	}

	[Serializable]
	[DataType(typeof(UnityEngine.RectTransform))]
	public sealed partial class RectTransformOverride : VariableOverride<UnityEngine.RectTransform, RectTransformVariable, RectTransformVar>
	{
		public RectTransformOverride(IVariable variable) : base(variable)
		{
		}
	}

	[Serializable]
	[DataType(typeof(UnityEngine.RectTransform))]
	public sealed partial class RectTransformOutput : VariableOutput<UnityEngine.RectTransform, RectTransformVariable, RectTransformRef>
	{
		public RectTransformOutput(IVariable variable) : base(variable)
		{
		}
	}

	[Serializable]
	[DataType(typeof(UnityEngine.RectTransform))]
	public sealed partial class RectTransformListOverride : VariableOverride<System.Collections.Generic.List<UnityEngine.RectTransform>, RectTransformListVariable, RectTransformListVar>
	{
		public RectTransformListOverride(IVariable variable) : base(variable)
		{
		}
	}

	[Serializable]
	[DataType(typeof(UnityEngine.RectTransform))]
	public sealed partial class RectTransformListOutput : VariableOutput<System.Collections.Generic.List<UnityEngine.RectTransform>, RectTransformListVariable, RectTransformListRef>
	{
		public RectTransformListOutput(IVariable variable) : base(variable)
		{
		}
	}
}
