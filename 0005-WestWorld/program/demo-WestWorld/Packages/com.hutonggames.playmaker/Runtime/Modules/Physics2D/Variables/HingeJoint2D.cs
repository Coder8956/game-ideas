
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.HingeJoint2D))]
	public sealed partial class HingeJoint2DVariable : Variable<UnityEngine.HingeJoint2D>
	{
		
		public HingeJoint2DVariable()
		{
		}
		
		public HingeJoint2DVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.HingeJoint2D))]
	public sealed partial class HingeJoint2DListVariable : ListVariable<UnityEngine.HingeJoint2D>
	{
		
		public HingeJoint2DListVariable()
		{
		}
		
		public HingeJoint2DListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.HingeJoint2D))]
	public sealed partial class HingeJoint2DRef : BaseComponentRef<UnityEngine.HingeJoint2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.HingeJoint2D))]
	public sealed partial class HingeJoint2DVar : BaseComponentVar<UnityEngine.HingeJoint2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.HingeJoint2D))]
	public sealed partial class HingeJoint2DListRef : ListVariableRef<UnityEngine.HingeJoint2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.HingeJoint2D))]
	public sealed partial class HingeJoint2DListVar : ListVariableVar<UnityEngine.HingeJoint2D>
	{
	}
}
