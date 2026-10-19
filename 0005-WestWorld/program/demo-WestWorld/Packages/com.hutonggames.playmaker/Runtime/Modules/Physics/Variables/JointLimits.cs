
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.JointLimits))]
	public sealed partial class JointLimitsVariable : Variable<UnityEngine.JointLimits>
	{
		
		public JointLimitsVariable()
		{
		}
		
		public JointLimitsVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.JointLimits))]
	public sealed partial class JointLimitsListVariable : ListVariable<UnityEngine.JointLimits>
	{
		
		public JointLimitsListVariable()
		{
		}
		
		public JointLimitsListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.JointLimits))]
	public sealed partial class JointLimitsRef : VariableRef<UnityEngine.JointLimits>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.JointLimits))]
	public sealed partial class JointLimitsVar : VariableVar<UnityEngine.JointLimits>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.JointLimits))]
	public sealed partial class JointLimitsListRef : ListVariableRef<UnityEngine.JointLimits>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.JointLimits))]
	public sealed partial class JointLimitsListVar : ListVariableVar<UnityEngine.JointLimits>
	{
	}
}
