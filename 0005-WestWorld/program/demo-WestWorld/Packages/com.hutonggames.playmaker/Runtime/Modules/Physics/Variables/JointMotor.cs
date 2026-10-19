
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.JointMotor))]
	public sealed partial class JointMotorVariable : Variable<UnityEngine.JointMotor>
	{
		
		public JointMotorVariable()
		{
		}
		
		public JointMotorVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.JointMotor))]
	public sealed partial class JointMotorListVariable : ListVariable<UnityEngine.JointMotor>
	{
		
		public JointMotorListVariable()
		{
		}
		
		public JointMotorListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.JointMotor))]
	public sealed partial class JointMotorRef : VariableRef<UnityEngine.JointMotor>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.JointMotor))]
	public sealed partial class JointMotorVar : VariableVar<UnityEngine.JointMotor>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.JointMotor))]
	public sealed partial class JointMotorListRef : ListVariableRef<UnityEngine.JointMotor>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.JointMotor))]
	public sealed partial class JointMotorListVar : ListVariableVar<UnityEngine.JointMotor>
	{
	}
}
