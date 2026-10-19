
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.JointSpring))]
	public sealed partial class JointSpringVariable : Variable<UnityEngine.JointSpring>
	{
		
		public JointSpringVariable()
		{
		}
		
		public JointSpringVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.JointSpring))]
	public sealed partial class JointSpringListVariable : ListVariable<UnityEngine.JointSpring>
	{
		
		public JointSpringListVariable()
		{
		}
		
		public JointSpringListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.JointSpring))]
	public sealed partial class JointSpringRef : VariableRef<UnityEngine.JointSpring>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.JointSpring))]
	public sealed partial class JointSpringVar : VariableVar<UnityEngine.JointSpring>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.JointSpring))]
	public sealed partial class JointSpringListRef : ListVariableRef<UnityEngine.JointSpring>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.JointSpring))]
	public sealed partial class JointSpringListVar : ListVariableVar<UnityEngine.JointSpring>
	{
	}
}
