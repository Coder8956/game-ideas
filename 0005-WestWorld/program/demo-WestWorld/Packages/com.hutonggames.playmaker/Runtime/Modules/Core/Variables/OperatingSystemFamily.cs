
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.OperatingSystemFamily))]
	public sealed partial class OperatingSystemFamilyVariable : Variable<UnityEngine.OperatingSystemFamily>
	{
		
		public OperatingSystemFamilyVariable()
		{
		}
		
		public OperatingSystemFamilyVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.OperatingSystemFamily))]
	public sealed partial class OperatingSystemFamilyListVariable : ListVariable<UnityEngine.OperatingSystemFamily>
	{
		
		public OperatingSystemFamilyListVariable()
		{
		}
		
		public OperatingSystemFamilyListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.OperatingSystemFamily))]
	public sealed partial class OperatingSystemFamilyRef : VariableRef<UnityEngine.OperatingSystemFamily>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.OperatingSystemFamily))]
	public sealed partial class OperatingSystemFamilyVar : VariableVar<UnityEngine.OperatingSystemFamily>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.OperatingSystemFamily))]
	public sealed partial class OperatingSystemFamilyListRef : ListVariableRef<UnityEngine.OperatingSystemFamily>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.OperatingSystemFamily))]
	public sealed partial class OperatingSystemFamilyListVar : ListVariableVar<UnityEngine.OperatingSystemFamily>
	{
	}
}
