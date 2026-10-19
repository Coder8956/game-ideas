
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Joint2D))]
	public sealed partial class Joint2DVariable : Variable<UnityEngine.Joint2D>
	{
		
		public Joint2DVariable()
		{
		}
		
		public Joint2DVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Joint2D))]
	public sealed partial class Joint2DListVariable : ListVariable<UnityEngine.Joint2D>
	{
		
		public Joint2DListVariable()
		{
		}
		
		public Joint2DListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Joint2D))]
	public sealed partial class Joint2DRef : BaseComponentRef<UnityEngine.Joint2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Joint2D))]
	public sealed partial class Joint2DVar : BaseComponentVar<UnityEngine.Joint2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Joint2D))]
	public sealed partial class Joint2DListRef : ListVariableRef<UnityEngine.Joint2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Joint2D))]
	public sealed partial class Joint2DListVar : ListVariableVar<UnityEngine.Joint2D>
	{
	}
}
