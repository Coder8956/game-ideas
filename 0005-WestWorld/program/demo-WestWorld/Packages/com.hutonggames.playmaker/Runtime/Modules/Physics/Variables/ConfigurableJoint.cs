
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.ConfigurableJoint))]
	public sealed partial class ConfigurableJointVariable : Variable<UnityEngine.ConfigurableJoint>
	{
		
		public ConfigurableJointVariable()
		{
		}
		
		public ConfigurableJointVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ConfigurableJoint))]
	public sealed partial class ConfigurableJointListVariable : ListVariable<UnityEngine.ConfigurableJoint>
	{
		
		public ConfigurableJointListVariable()
		{
		}
		
		public ConfigurableJointListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ConfigurableJoint))]
	public sealed partial class ConfigurableJointRef : BaseComponentRef<UnityEngine.ConfigurableJoint>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ConfigurableJoint))]
	public sealed partial class ConfigurableJointVar : BaseComponentVar<UnityEngine.ConfigurableJoint>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ConfigurableJoint))]
	public sealed partial class ConfigurableJointListRef : ListVariableRef<UnityEngine.ConfigurableJoint>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ConfigurableJoint))]
	public sealed partial class ConfigurableJointListVar : ListVariableVar<UnityEngine.ConfigurableJoint>
	{
	}
}
