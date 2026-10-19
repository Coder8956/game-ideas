
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.JointProjectionMode))]
	public sealed partial class JointProjectionModeVariable : Variable<UnityEngine.JointProjectionMode>
	{
		
		public JointProjectionModeVariable()
		{
		}
		
		public JointProjectionModeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.JointProjectionMode))]
	public sealed partial class JointProjectionModeListVariable : ListVariable<UnityEngine.JointProjectionMode>
	{
		
		public JointProjectionModeListVariable()
		{
		}
		
		public JointProjectionModeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.JointProjectionMode))]
	public sealed partial class JointProjectionModeRef : VariableRef<UnityEngine.JointProjectionMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.JointProjectionMode))]
	public sealed partial class JointProjectionModeVar : VariableVar<UnityEngine.JointProjectionMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.JointProjectionMode))]
	public sealed partial class JointProjectionModeListRef : ListVariableRef<UnityEngine.JointProjectionMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.JointProjectionMode))]
	public sealed partial class JointProjectionModeListVar : ListVariableVar<UnityEngine.JointProjectionMode>
	{
	}
}
