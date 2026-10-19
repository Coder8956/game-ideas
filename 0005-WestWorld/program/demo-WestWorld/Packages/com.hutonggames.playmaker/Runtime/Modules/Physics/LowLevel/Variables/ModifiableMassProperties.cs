
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.ModifiableMassProperties))]
	public sealed partial class ModifiableMassPropertiesVariable : Variable<UnityEngine.ModifiableMassProperties>
	{
		
		public ModifiableMassPropertiesVariable()
		{
		}
		
		public ModifiableMassPropertiesVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ModifiableMassProperties))]
	public sealed partial class ModifiableMassPropertiesListVariable : ListVariable<UnityEngine.ModifiableMassProperties>
	{
		
		public ModifiableMassPropertiesListVariable()
		{
		}
		
		public ModifiableMassPropertiesListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ModifiableMassProperties))]
	public sealed partial class ModifiableMassPropertiesRef : VariableRef<UnityEngine.ModifiableMassProperties>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ModifiableMassProperties))]
	public sealed partial class ModifiableMassPropertiesVar : VariableVar<UnityEngine.ModifiableMassProperties>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ModifiableMassProperties))]
	public sealed partial class ModifiableMassPropertiesListRef : ListVariableRef<UnityEngine.ModifiableMassProperties>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ModifiableMassProperties))]
	public sealed partial class ModifiableMassPropertiesListVar : ListVariableVar<UnityEngine.ModifiableMassProperties>
	{
	}
}
