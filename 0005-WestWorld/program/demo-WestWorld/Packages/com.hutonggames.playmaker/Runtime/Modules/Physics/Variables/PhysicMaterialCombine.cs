
using System;
#if UNITY_6000_0_OR_NEWER
using PhysicsMaterialCombine = UnityEngine.PhysicsMaterialCombine;
#else
using PhysicsMaterialCombine = UnityEngine.PhysicMaterialCombine;
#endif

namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(PhysicsMaterialCombine))]
	public sealed partial class PhysicMaterialCombineVariable : Variable<PhysicsMaterialCombine>
	{
		
		public PhysicMaterialCombineVariable()
		{
		}
		
		public PhysicMaterialCombineVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(PhysicsMaterialCombine))]
	public sealed partial class PhysicMaterialCombineListVariable : ListVariable<PhysicsMaterialCombine>
	{
		
		public PhysicMaterialCombineListVariable()
		{
		}
		
		public PhysicMaterialCombineListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(PhysicsMaterialCombine))]
	public sealed partial class PhysicMaterialCombineRef : VariableRef<PhysicsMaterialCombine>
	{
	}
	
	[Serializable]
	[DataType(typeof(PhysicsMaterialCombine))]
	public sealed partial class PhysicMaterialCombineVar : VariableVar<PhysicsMaterialCombine>
	{
	}
	
	[Serializable]
	[DataType(typeof(PhysicsMaterialCombine))]
	public sealed partial class PhysicMaterialCombineListRef : ListVariableRef<PhysicsMaterialCombine>
	{
	}
	
	[Serializable]
	[DataType(typeof(PhysicsMaterialCombine))]
	public sealed partial class PhysicMaterialCombineListVar : ListVariableVar<PhysicsMaterialCombine>
	{
	}
}
