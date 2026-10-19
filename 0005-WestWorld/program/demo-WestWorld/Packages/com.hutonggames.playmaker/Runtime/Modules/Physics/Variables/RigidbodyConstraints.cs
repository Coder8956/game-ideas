
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.RigidbodyConstraints))]
	public sealed partial class RigidbodyConstraintsVariable : Variable<UnityEngine.RigidbodyConstraints>
	{
		
		public RigidbodyConstraintsVariable()
		{
		}
		
		public RigidbodyConstraintsVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RigidbodyConstraints))]
	public sealed partial class RigidbodyConstraintsListVariable : ListVariable<UnityEngine.RigidbodyConstraints>
	{
		
		public RigidbodyConstraintsListVariable()
		{
		}
		
		public RigidbodyConstraintsListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RigidbodyConstraints))]
	public sealed partial class RigidbodyConstraintsRef : VariableRef<UnityEngine.RigidbodyConstraints>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RigidbodyConstraints))]
	public sealed partial class RigidbodyConstraintsVar : VariableVar<UnityEngine.RigidbodyConstraints>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RigidbodyConstraints))]
	public sealed partial class RigidbodyConstraintsListRef : ListVariableRef<UnityEngine.RigidbodyConstraints>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RigidbodyConstraints))]
	public sealed partial class RigidbodyConstraintsListVar : ListVariableVar<UnityEngine.RigidbodyConstraints>
	{
	}
}
