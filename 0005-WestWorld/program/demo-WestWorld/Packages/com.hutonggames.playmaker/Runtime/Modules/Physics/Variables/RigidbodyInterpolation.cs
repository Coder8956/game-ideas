
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.RigidbodyInterpolation))]
	public sealed partial class RigidbodyInterpolationVariable : Variable<UnityEngine.RigidbodyInterpolation>
	{
		
		public RigidbodyInterpolationVariable()
		{
		}
		
		public RigidbodyInterpolationVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RigidbodyInterpolation))]
	public sealed partial class RigidbodyInterpolationListVariable : ListVariable<UnityEngine.RigidbodyInterpolation>
	{
		
		public RigidbodyInterpolationListVariable()
		{
		}
		
		public RigidbodyInterpolationListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RigidbodyInterpolation))]
	public sealed partial class RigidbodyInterpolationRef : VariableRef<UnityEngine.RigidbodyInterpolation>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RigidbodyInterpolation))]
	public sealed partial class RigidbodyInterpolationVar : VariableVar<UnityEngine.RigidbodyInterpolation>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RigidbodyInterpolation))]
	public sealed partial class RigidbodyInterpolationListRef : ListVariableRef<UnityEngine.RigidbodyInterpolation>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RigidbodyInterpolation))]
	public sealed partial class RigidbodyInterpolationListVar : ListVariableVar<UnityEngine.RigidbodyInterpolation>
	{
	}
}
