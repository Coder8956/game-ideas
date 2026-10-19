
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.SpringJoint2D))]
	public sealed partial class SpringJoint2DVariable : Variable<UnityEngine.SpringJoint2D>
	{
		
		public SpringJoint2DVariable()
		{
		}
		
		public SpringJoint2DVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SpringJoint2D))]
	public sealed partial class SpringJoint2DListVariable : ListVariable<UnityEngine.SpringJoint2D>
	{
		
		public SpringJoint2DListVariable()
		{
		}
		
		public SpringJoint2DListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SpringJoint2D))]
	public sealed partial class SpringJoint2DRef : BaseComponentRef<UnityEngine.SpringJoint2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SpringJoint2D))]
	public sealed partial class SpringJoint2DVar : BaseComponentVar<UnityEngine.SpringJoint2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SpringJoint2D))]
	public sealed partial class SpringJoint2DListRef : ListVariableRef<UnityEngine.SpringJoint2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SpringJoint2D))]
	public sealed partial class SpringJoint2DListVar : ListVariableVar<UnityEngine.SpringJoint2D>
	{
	}
}
