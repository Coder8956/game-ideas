
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.JointLimitState2D))]
	public sealed partial class JointLimitState2DVariable : Variable<UnityEngine.JointLimitState2D>
	{
		
		public JointLimitState2DVariable()
		{
		}
		
		public JointLimitState2DVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.JointLimitState2D))]
	public sealed partial class JointLimitState2DListVariable : ListVariable<UnityEngine.JointLimitState2D>
	{
		
		public JointLimitState2DListVariable()
		{
		}
		
		public JointLimitState2DListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.JointLimitState2D))]
	public sealed partial class JointLimitState2DRef : VariableRef<UnityEngine.JointLimitState2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.JointLimitState2D))]
	public sealed partial class JointLimitState2DVar : VariableVar<UnityEngine.JointLimitState2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.JointLimitState2D))]
	public sealed partial class JointLimitState2DListRef : ListVariableRef<UnityEngine.JointLimitState2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.JointLimitState2D))]
	public sealed partial class JointLimitState2DListVar : ListVariableVar<UnityEngine.JointLimitState2D>
	{
	}
}
