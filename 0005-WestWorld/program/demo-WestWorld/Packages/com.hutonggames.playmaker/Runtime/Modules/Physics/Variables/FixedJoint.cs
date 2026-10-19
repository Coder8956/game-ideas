
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.FixedJoint))]
	public sealed partial class FixedJointVariable : Variable<UnityEngine.FixedJoint>
	{
		
		public FixedJointVariable()
		{
		}
		
		public FixedJointVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.FixedJoint))]
	public sealed partial class FixedJointListVariable : ListVariable<UnityEngine.FixedJoint>
	{
		
		public FixedJointListVariable()
		{
		}
		
		public FixedJointListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.FixedJoint))]
	public sealed partial class FixedJointRef : BaseComponentRef<UnityEngine.FixedJoint>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.FixedJoint))]
	public sealed partial class FixedJointVar : BaseComponentVar<UnityEngine.FixedJoint>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.FixedJoint))]
	public sealed partial class FixedJointListRef : ListVariableRef<UnityEngine.FixedJoint>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.FixedJoint))]
	public sealed partial class FixedJointListVar : ListVariableVar<UnityEngine.FixedJoint>
	{
	}
}
