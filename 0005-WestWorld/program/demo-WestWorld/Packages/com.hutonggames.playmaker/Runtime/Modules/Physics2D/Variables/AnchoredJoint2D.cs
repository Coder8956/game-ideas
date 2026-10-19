
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.AnchoredJoint2D))]
	public sealed partial class AnchoredJoint2DVariable : Variable<UnityEngine.AnchoredJoint2D>
	{
		
		public AnchoredJoint2DVariable()
		{
		}
		
		public AnchoredJoint2DVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AnchoredJoint2D))]
	public sealed partial class AnchoredJoint2DListVariable : ListVariable<UnityEngine.AnchoredJoint2D>
	{
		
		public AnchoredJoint2DListVariable()
		{
		}
		
		public AnchoredJoint2DListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AnchoredJoint2D))]
	public sealed partial class AnchoredJoint2DRef : BaseComponentRef<UnityEngine.AnchoredJoint2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AnchoredJoint2D))]
	public sealed partial class AnchoredJoint2DVar : BaseComponentVar<UnityEngine.AnchoredJoint2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AnchoredJoint2D))]
	public sealed partial class AnchoredJoint2DListRef : ListVariableRef<UnityEngine.AnchoredJoint2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AnchoredJoint2D))]
	public sealed partial class AnchoredJoint2DListVar : ListVariableVar<UnityEngine.AnchoredJoint2D>
	{
	}
}
