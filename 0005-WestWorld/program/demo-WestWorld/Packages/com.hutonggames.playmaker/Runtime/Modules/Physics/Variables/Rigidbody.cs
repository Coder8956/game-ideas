
using System;


namespace HutongGames.PlayMaker
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rigidbody))]
	public sealed partial class RigidbodyVariable : Variable<UnityEngine.Rigidbody>
	{
		
		public RigidbodyVariable()
		{
		}
		
		public RigidbodyVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rigidbody))]
	public sealed partial class RigidbodyListVariable : ListVariable<UnityEngine.Rigidbody>
	{
		
		public RigidbodyListVariable()
		{
		}
		
		public RigidbodyListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rigidbody))]
	public sealed partial class RigidbodyRef : BaseComponentRef<UnityEngine.Rigidbody>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rigidbody))]
	public sealed partial class RigidbodyVar : BaseComponentVar<UnityEngine.Rigidbody>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rigidbody))]
	public sealed partial class RigidbodyListRef : ListVariableRef<UnityEngine.Rigidbody>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rigidbody))]
	public sealed partial class RigidbodyListVar : ListVariableVar<UnityEngine.Rigidbody>
	{
	}

	[Serializable]
	[DataType(typeof(UnityEngine.Rigidbody))]
	public sealed partial class RigidbodyOverride : VariableOverride<UnityEngine.Rigidbody, RigidbodyVariable, RigidbodyVar>
	{
		public RigidbodyOverride(IVariable variable) : base(variable)
		{
		}
	}

	[Serializable]
	[DataType(typeof(UnityEngine.Rigidbody))]
	public sealed partial class RigidbodyOutput : VariableOutput<UnityEngine.Rigidbody, RigidbodyVariable, RigidbodyRef>
	{
		public RigidbodyOutput(IVariable variable) : base(variable)
		{
		}
	}

	[Serializable]
	[DataType(typeof(UnityEngine.Rigidbody))]
	public sealed partial class RigidbodyListOverride : VariableOverride<System.Collections.Generic.List<UnityEngine.Rigidbody>, RigidbodyListVariable, RigidbodyListVar>
	{
		public RigidbodyListOverride(IVariable variable) : base(variable)
		{
		}
	}

	[Serializable]
	[DataType(typeof(UnityEngine.Rigidbody))]
	public sealed partial class RigidbodyListOutput : VariableOutput<System.Collections.Generic.List<UnityEngine.Rigidbody>, RigidbodyListVariable, RigidbodyListRef>
	{
		public RigidbodyListOutput(IVariable variable) : base(variable)
		{
		}
	}
}
