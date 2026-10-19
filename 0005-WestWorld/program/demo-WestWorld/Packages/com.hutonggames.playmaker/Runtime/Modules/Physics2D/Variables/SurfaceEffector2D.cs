
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.SurfaceEffector2D))]
	public sealed partial class SurfaceEffector2DVariable : Variable<UnityEngine.SurfaceEffector2D>
	{
		
		public SurfaceEffector2DVariable()
		{
		}
		
		public SurfaceEffector2DVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SurfaceEffector2D))]
	public sealed partial class SurfaceEffector2DListVariable : ListVariable<UnityEngine.SurfaceEffector2D>
	{
		
		public SurfaceEffector2DListVariable()
		{
		}
		
		public SurfaceEffector2DListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SurfaceEffector2D))]
	public sealed partial class SurfaceEffector2DRef : BaseComponentRef<UnityEngine.SurfaceEffector2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SurfaceEffector2D))]
	public sealed partial class SurfaceEffector2DVar : BaseComponentVar<UnityEngine.SurfaceEffector2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SurfaceEffector2D))]
	public sealed partial class SurfaceEffector2DListRef : ListVariableRef<UnityEngine.SurfaceEffector2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SurfaceEffector2D))]
	public sealed partial class SurfaceEffector2DListVar : ListVariableVar<UnityEngine.SurfaceEffector2D>
	{
	}
}
