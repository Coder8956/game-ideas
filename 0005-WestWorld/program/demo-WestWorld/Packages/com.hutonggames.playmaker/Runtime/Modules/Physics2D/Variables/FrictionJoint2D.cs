
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.FrictionJoint2D))]
	public sealed partial class FrictionJoint2DVariable : Variable<UnityEngine.FrictionJoint2D>
	{
		
		public FrictionJoint2DVariable()
		{
		}
		
		public FrictionJoint2DVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.FrictionJoint2D))]
	public sealed partial class FrictionJoint2DListVariable : ListVariable<UnityEngine.FrictionJoint2D>
	{
		
		public FrictionJoint2DListVariable()
		{
		}
		
		public FrictionJoint2DListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.FrictionJoint2D))]
	public sealed partial class FrictionJoint2DRef : BaseComponentRef<UnityEngine.FrictionJoint2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.FrictionJoint2D))]
	public sealed partial class FrictionJoint2DVar : BaseComponentVar<UnityEngine.FrictionJoint2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.FrictionJoint2D))]
	public sealed partial class FrictionJoint2DListRef : ListVariableRef<UnityEngine.FrictionJoint2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.FrictionJoint2D))]
	public sealed partial class FrictionJoint2DListVar : ListVariableVar<UnityEngine.FrictionJoint2D>
	{
	}
}
