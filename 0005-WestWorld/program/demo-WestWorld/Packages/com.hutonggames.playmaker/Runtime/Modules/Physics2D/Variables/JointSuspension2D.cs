
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.JointSuspension2D))]
	public sealed partial class JointSuspension2DVariable : Variable<UnityEngine.JointSuspension2D>
	{
		
		public JointSuspension2DVariable()
		{
		}
		
		public JointSuspension2DVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.JointSuspension2D))]
	public sealed partial class JointSuspension2DListVariable : ListVariable<UnityEngine.JointSuspension2D>
	{
		
		public JointSuspension2DListVariable()
		{
		}
		
		public JointSuspension2DListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.JointSuspension2D))]
	public sealed partial class JointSuspension2DRef : VariableRef<UnityEngine.JointSuspension2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.JointSuspension2D))]
	public sealed partial class JointSuspension2DVar : VariableVar<UnityEngine.JointSuspension2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.JointSuspension2D))]
	public sealed partial class JointSuspension2DListRef : ListVariableRef<UnityEngine.JointSuspension2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.JointSuspension2D))]
	public sealed partial class JointSuspension2DListVar : ListVariableVar<UnityEngine.JointSuspension2D>
	{
	}
}
