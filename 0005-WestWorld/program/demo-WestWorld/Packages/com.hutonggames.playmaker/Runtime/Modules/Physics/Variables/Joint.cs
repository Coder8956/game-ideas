
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Joint))]
	public sealed partial class JointVariable : Variable<UnityEngine.Joint>
	{
		
		public JointVariable()
		{
		}
		
		public JointVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Joint))]
	public sealed partial class JointListVariable : ListVariable<UnityEngine.Joint>
	{
		
		public JointListVariable()
		{
		}
		
		public JointListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Joint))]
	public sealed partial class JointRef : BaseComponentRef<UnityEngine.Joint>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Joint))]
	public sealed partial class JointVar : BaseComponentVar<UnityEngine.Joint>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Joint))]
	public sealed partial class JointListRef : ListVariableRef<UnityEngine.Joint>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Joint))]
	public sealed partial class JointListVar : ListVariableVar<UnityEngine.Joint>
	{
	}
}
