
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.ConfigurableJointMotion))]
	public sealed partial class ConfigurableJointMotionVariable : Variable<UnityEngine.ConfigurableJointMotion>
	{
		
		public ConfigurableJointMotionVariable()
		{
		}
		
		public ConfigurableJointMotionVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ConfigurableJointMotion))]
	public sealed partial class ConfigurableJointMotionListVariable : ListVariable<UnityEngine.ConfigurableJointMotion>
	{
		
		public ConfigurableJointMotionListVariable()
		{
		}
		
		public ConfigurableJointMotionListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ConfigurableJointMotion))]
	public sealed partial class ConfigurableJointMotionRef : VariableRef<UnityEngine.ConfigurableJointMotion>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ConfigurableJointMotion))]
	public sealed partial class ConfigurableJointMotionVar : VariableVar<UnityEngine.ConfigurableJointMotion>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ConfigurableJointMotion))]
	public sealed partial class ConfigurableJointMotionListRef : ListVariableRef<UnityEngine.ConfigurableJointMotion>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ConfigurableJointMotion))]
	public sealed partial class ConfigurableJointMotionListVar : ListVariableVar<UnityEngine.ConfigurableJointMotion>
	{
	}
}
