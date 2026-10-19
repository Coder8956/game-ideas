
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.HingeJoint))]
	public sealed partial class HingeJointVariable : Variable<UnityEngine.HingeJoint>
	{
		
		public HingeJointVariable()
		{
		}
		
		public HingeJointVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.HingeJoint))]
	public sealed partial class HingeJointListVariable : ListVariable<UnityEngine.HingeJoint>
	{
		
		public HingeJointListVariable()
		{
		}
		
		public HingeJointListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.HingeJoint))]
	public sealed partial class HingeJointRef : BaseComponentRef<UnityEngine.HingeJoint>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.HingeJoint))]
	public sealed partial class HingeJointVar : BaseComponentVar<UnityEngine.HingeJoint>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.HingeJoint))]
	public sealed partial class HingeJointListRef : ListVariableRef<UnityEngine.HingeJoint>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.HingeJoint))]
	public sealed partial class HingeJointListVar : ListVariableVar<UnityEngine.HingeJoint>
	{
	}
}
