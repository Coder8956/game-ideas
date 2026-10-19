
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.RelativeJoint2D))]
	public sealed partial class RelativeJoint2DVariable : Variable<UnityEngine.RelativeJoint2D>
	{
		
		public RelativeJoint2DVariable()
		{
		}
		
		public RelativeJoint2DVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RelativeJoint2D))]
	public sealed partial class RelativeJoint2DListVariable : ListVariable<UnityEngine.RelativeJoint2D>
	{
		
		public RelativeJoint2DListVariable()
		{
		}
		
		public RelativeJoint2DListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RelativeJoint2D))]
	public sealed partial class RelativeJoint2DRef : BaseComponentRef<UnityEngine.RelativeJoint2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RelativeJoint2D))]
	public sealed partial class RelativeJoint2DVar : BaseComponentVar<UnityEngine.RelativeJoint2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RelativeJoint2D))]
	public sealed partial class RelativeJoint2DListRef : ListVariableRef<UnityEngine.RelativeJoint2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RelativeJoint2D))]
	public sealed partial class RelativeJoint2DListVar : ListVariableVar<UnityEngine.RelativeJoint2D>
	{
	}
}
