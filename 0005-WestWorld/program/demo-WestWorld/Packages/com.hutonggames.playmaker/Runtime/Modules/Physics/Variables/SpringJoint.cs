
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.SpringJoint))]
	public sealed partial class SpringJointVariable : Variable<UnityEngine.SpringJoint>
	{
		
		public SpringJointVariable()
		{
		}
		
		public SpringJointVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SpringJoint))]
	public sealed partial class SpringJointListVariable : ListVariable<UnityEngine.SpringJoint>
	{
		
		public SpringJointListVariable()
		{
		}
		
		public SpringJointListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SpringJoint))]
	public sealed partial class SpringJointRef : BaseComponentRef<UnityEngine.SpringJoint>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SpringJoint))]
	public sealed partial class SpringJointVar : BaseComponentVar<UnityEngine.SpringJoint>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SpringJoint))]
	public sealed partial class SpringJointListRef : ListVariableRef<UnityEngine.SpringJoint>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SpringJoint))]
	public sealed partial class SpringJointListVar : ListVariableVar<UnityEngine.SpringJoint>
	{
	}
}
