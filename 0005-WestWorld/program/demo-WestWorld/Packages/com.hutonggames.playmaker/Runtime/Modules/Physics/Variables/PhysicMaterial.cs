
using System;
#if UNITY_6000_0_OR_NEWER
using PhysicsMaterial = UnityEngine.PhysicsMaterial;
#else
using PhysicsMaterial = UnityEngine.PhysicMaterial;
#endif

namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(PhysicsMaterial))]
	public sealed partial class PhysicMaterialVariable : Variable<PhysicsMaterial>
	{
		
		public PhysicMaterialVariable()
		{
		}
		
		public PhysicMaterialVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(PhysicsMaterial))]
	public sealed partial class PhysicMaterialListVariable : ListVariable<PhysicsMaterial>
	{
		
		public PhysicMaterialListVariable()
		{
		}
		
		public PhysicMaterialListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(PhysicsMaterial))]
	public sealed partial class PhysicMaterialRef : VariableRef<PhysicsMaterial>
	{
	}
	
	[Serializable]
	[DataType(typeof(PhysicsMaterial))]
	public sealed partial class PhysicMaterialVar : VariableVar<PhysicsMaterial>
	{
	}
	
	[Serializable]
	[DataType(typeof(PhysicsMaterial))]
	public sealed partial class PhysicMaterialListRef : ListVariableRef<PhysicsMaterial>
	{
	}
	
	[Serializable]
	[DataType(typeof(PhysicsMaterial))]
	public sealed partial class PhysicMaterialListVar : ListVariableVar<PhysicsMaterial>
	{
	}
}
