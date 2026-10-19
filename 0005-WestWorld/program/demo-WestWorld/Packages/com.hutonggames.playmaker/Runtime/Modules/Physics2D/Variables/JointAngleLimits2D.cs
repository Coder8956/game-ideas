
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.JointAngleLimits2D))]
	public sealed partial class JointAngleLimits2DVariable : Variable<UnityEngine.JointAngleLimits2D>
	{
		
		public JointAngleLimits2DVariable()
		{
		}
		
		public JointAngleLimits2DVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.JointAngleLimits2D))]
	public sealed partial class JointAngleLimits2DListVariable : ListVariable<UnityEngine.JointAngleLimits2D>
	{
		
		public JointAngleLimits2DListVariable()
		{
		}
		
		public JointAngleLimits2DListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.JointAngleLimits2D))]
	public sealed partial class JointAngleLimits2DRef : VariableRef<UnityEngine.JointAngleLimits2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.JointAngleLimits2D))]
	public sealed partial class JointAngleLimits2DVar : VariableVar<UnityEngine.JointAngleLimits2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.JointAngleLimits2D))]
	public sealed partial class JointAngleLimits2DListRef : ListVariableRef<UnityEngine.JointAngleLimits2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.JointAngleLimits2D))]
	public sealed partial class JointAngleLimits2DListVar : ListVariableVar<UnityEngine.JointAngleLimits2D>
	{
	}
}
