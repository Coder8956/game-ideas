
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.CharacterJoint))]
	public sealed partial class CharacterJointVariable : Variable<UnityEngine.CharacterJoint>
	{
		
		public CharacterJointVariable()
		{
		}
		
		public CharacterJointVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CharacterJoint))]
	public sealed partial class CharacterJointListVariable : ListVariable<UnityEngine.CharacterJoint>
	{
		
		public CharacterJointListVariable()
		{
		}
		
		public CharacterJointListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CharacterJoint))]
	public sealed partial class CharacterJointRef : BaseComponentRef<UnityEngine.CharacterJoint>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CharacterJoint))]
	public sealed partial class CharacterJointVar : BaseComponentVar<UnityEngine.CharacterJoint>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CharacterJoint))]
	public sealed partial class CharacterJointListRef : ListVariableRef<UnityEngine.CharacterJoint>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CharacterJoint))]
	public sealed partial class CharacterJointListVar : ListVariableVar<UnityEngine.CharacterJoint>
	{
	}
}
