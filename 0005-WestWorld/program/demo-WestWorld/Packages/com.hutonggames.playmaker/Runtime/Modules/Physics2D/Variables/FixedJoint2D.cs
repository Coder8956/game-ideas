
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.FixedJoint2D))]
	public sealed partial class FixedJoint2DVariable : Variable<UnityEngine.FixedJoint2D>
	{
		
		public FixedJoint2DVariable()
		{
		}
		
		public FixedJoint2DVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.FixedJoint2D))]
	public sealed partial class FixedJoint2DListVariable : ListVariable<UnityEngine.FixedJoint2D>
	{
		
		public FixedJoint2DListVariable()
		{
		}
		
		public FixedJoint2DListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.FixedJoint2D))]
	public sealed partial class FixedJoint2DRef : BaseComponentRef<UnityEngine.FixedJoint2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.FixedJoint2D))]
	public sealed partial class FixedJoint2DVar : BaseComponentVar<UnityEngine.FixedJoint2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.FixedJoint2D))]
	public sealed partial class FixedJoint2DListRef : ListVariableRef<UnityEngine.FixedJoint2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.FixedJoint2D))]
	public sealed partial class FixedJoint2DListVar : ListVariableVar<UnityEngine.FixedJoint2D>
	{
	}
}
