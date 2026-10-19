
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.AreaEffector2D))]
	public sealed partial class AreaEffector2DVariable : Variable<UnityEngine.AreaEffector2D>
	{
		
		public AreaEffector2DVariable()
		{
		}
		
		public AreaEffector2DVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AreaEffector2D))]
	public sealed partial class AreaEffector2DListVariable : ListVariable<UnityEngine.AreaEffector2D>
	{
		
		public AreaEffector2DListVariable()
		{
		}
		
		public AreaEffector2DListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AreaEffector2D))]
	public sealed partial class AreaEffector2DRef : BaseComponentRef<UnityEngine.AreaEffector2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AreaEffector2D))]
	public sealed partial class AreaEffector2DVar : BaseComponentVar<UnityEngine.AreaEffector2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AreaEffector2D))]
	public sealed partial class AreaEffector2DListRef : ListVariableRef<UnityEngine.AreaEffector2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AreaEffector2D))]
	public sealed partial class AreaEffector2DListVar : ListVariableVar<UnityEngine.AreaEffector2D>
	{
	}
}
