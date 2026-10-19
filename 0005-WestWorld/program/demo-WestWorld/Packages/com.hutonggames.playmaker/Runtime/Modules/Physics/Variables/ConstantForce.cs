
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.ConstantForce))]
	public sealed partial class ConstantForceVariable : Variable<UnityEngine.ConstantForce>
	{
		
		public ConstantForceVariable()
		{
		}
		
		public ConstantForceVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ConstantForce))]
	public sealed partial class ConstantForceListVariable : ListVariable<UnityEngine.ConstantForce>
	{
		
		public ConstantForceListVariable()
		{
		}
		
		public ConstantForceListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ConstantForce))]
	public sealed partial class ConstantForceRef : BaseComponentRef<UnityEngine.ConstantForce>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ConstantForce))]
	public sealed partial class ConstantForceVar : BaseComponentVar<UnityEngine.ConstantForce>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ConstantForce))]
	public sealed partial class ConstantForceListRef : ListVariableRef<UnityEngine.ConstantForce>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ConstantForce))]
	public sealed partial class ConstantForceListVar : ListVariableVar<UnityEngine.ConstantForce>
	{
	}
}
