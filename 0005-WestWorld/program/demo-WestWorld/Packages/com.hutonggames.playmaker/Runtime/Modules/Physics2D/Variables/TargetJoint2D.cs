
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.TargetJoint2D))]
	public sealed partial class TargetJoint2DVariable : Variable<UnityEngine.TargetJoint2D>
	{
		
		public TargetJoint2DVariable()
		{
		}
		
		public TargetJoint2DVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.TargetJoint2D))]
	public sealed partial class TargetJoint2DListVariable : ListVariable<UnityEngine.TargetJoint2D>
	{
		
		public TargetJoint2DListVariable()
		{
		}
		
		public TargetJoint2DListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.TargetJoint2D))]
	public sealed partial class TargetJoint2DRef : BaseComponentRef<UnityEngine.TargetJoint2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.TargetJoint2D))]
	public sealed partial class TargetJoint2DVar : BaseComponentVar<UnityEngine.TargetJoint2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.TargetJoint2D))]
	public sealed partial class TargetJoint2DListRef : ListVariableRef<UnityEngine.TargetJoint2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.TargetJoint2D))]
	public sealed partial class TargetJoint2DListVar : ListVariableVar<UnityEngine.TargetJoint2D>
	{
	}
}
