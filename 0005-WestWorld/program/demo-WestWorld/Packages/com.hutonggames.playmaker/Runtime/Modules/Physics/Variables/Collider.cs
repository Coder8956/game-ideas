
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Collider))]
	public sealed partial class ColliderVariable : Variable<UnityEngine.Collider>
	{
		
		public ColliderVariable()
		{
		}
		
		public ColliderVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Collider))]
	public sealed partial class ColliderListVariable : ListVariable<UnityEngine.Collider>
	{
		
		public ColliderListVariable()
		{
		}
		
		public ColliderListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Collider))]
	public sealed partial class ColliderRef : BaseComponentRef<UnityEngine.Collider>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Collider))]
	public sealed partial class ColliderVar : BaseComponentVar<UnityEngine.Collider>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Collider))]
	public sealed partial class ColliderListRef : ListVariableRef<UnityEngine.Collider>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Collider))]
	public sealed partial class ColliderListVar : ListVariableVar<UnityEngine.Collider>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Collider))]
	public sealed partial class ColliderOverride : VariableOverride<UnityEngine.Collider, ColliderVariable, ColliderVar>
	{
		
		public ColliderOverride(IVariable variable) : 
			base(variable)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Collider))]
	public sealed partial class ColliderOutput : VariableOutput<UnityEngine.Collider, ColliderVariable, ColliderRef>
	{
		
		public ColliderOutput(IVariable variable) : 
			base(variable)
		{
		}
	}

	[Serializable]
	[DataType(typeof(UnityEngine.Collider))]
	public sealed partial class ColliderListOverride : VariableOverride<System.Collections.Generic.List<UnityEngine.Collider>, ColliderListVariable, ColliderListVar>
	{
		public ColliderListOverride(IVariable variable) :
			base(variable)
		{
		}
	}

	[Serializable]
	[DataType(typeof(UnityEngine.Collider))]
	public sealed partial class ColliderListOutput : VariableOutput<System.Collections.Generic.List<UnityEngine.Collider>, ColliderListVariable, ColliderListRef>
	{
		public ColliderListOutput(IVariable variable) :
			base(variable)
		{
		}
	}
	
}
