
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.JointMotor2D))]
	public sealed partial class JointMotor2DVariable : Variable<UnityEngine.JointMotor2D>
	{
		
		public JointMotor2DVariable()
		{
		}
		
		public JointMotor2DVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.JointMotor2D))]
	public sealed partial class JointMotor2DListVariable : ListVariable<UnityEngine.JointMotor2D>
	{
		
		public JointMotor2DListVariable()
		{
		}
		
		public JointMotor2DListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.JointMotor2D))]
	public sealed partial class JointMotor2DRef : VariableRef<UnityEngine.JointMotor2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.JointMotor2D))]
	public sealed partial class JointMotor2DVar : VariableVar<UnityEngine.JointMotor2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.JointMotor2D))]
	public sealed partial class JointMotor2DListRef : ListVariableRef<UnityEngine.JointMotor2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.JointMotor2D))]
	public sealed partial class JointMotor2DListVar : ListVariableVar<UnityEngine.JointMotor2D>
	{
	}
}
