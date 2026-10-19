
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.DistanceJoint2D))]
	public sealed partial class DistanceJoint2DVariable : Variable<UnityEngine.DistanceJoint2D>
	{
		
		public DistanceJoint2DVariable()
		{
		}
		
		public DistanceJoint2DVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.DistanceJoint2D))]
	public sealed partial class DistanceJoint2DListVariable : ListVariable<UnityEngine.DistanceJoint2D>
	{
		
		public DistanceJoint2DListVariable()
		{
		}
		
		public DistanceJoint2DListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.DistanceJoint2D))]
	public sealed partial class DistanceJoint2DRef : BaseComponentRef<UnityEngine.DistanceJoint2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.DistanceJoint2D))]
	public sealed partial class DistanceJoint2DVar : BaseComponentVar<UnityEngine.DistanceJoint2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.DistanceJoint2D))]
	public sealed partial class DistanceJoint2DListRef : ListVariableRef<UnityEngine.DistanceJoint2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.DistanceJoint2D))]
	public sealed partial class DistanceJoint2DListVar : ListVariableVar<UnityEngine.DistanceJoint2D>
	{
	}
}
