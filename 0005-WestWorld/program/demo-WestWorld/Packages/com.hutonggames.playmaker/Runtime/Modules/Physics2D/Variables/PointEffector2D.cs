
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.PointEffector2D))]
	public sealed partial class PointEffector2DVariable : Variable<UnityEngine.PointEffector2D>
	{
		
		public PointEffector2DVariable()
		{
		}
		
		public PointEffector2DVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.PointEffector2D))]
	public sealed partial class PointEffector2DListVariable : ListVariable<UnityEngine.PointEffector2D>
	{
		
		public PointEffector2DListVariable()
		{
		}
		
		public PointEffector2DListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.PointEffector2D))]
	public sealed partial class PointEffector2DRef : BaseComponentRef<UnityEngine.PointEffector2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.PointEffector2D))]
	public sealed partial class PointEffector2DVar : BaseComponentVar<UnityEngine.PointEffector2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.PointEffector2D))]
	public sealed partial class PointEffector2DListRef : ListVariableRef<UnityEngine.PointEffector2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.PointEffector2D))]
	public sealed partial class PointEffector2DListVar : ListVariableVar<UnityEngine.PointEffector2D>
	{
	}
}
