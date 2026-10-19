
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.PlatformEffector2D))]
	public sealed partial class PlatformEffector2DVariable : Variable<UnityEngine.PlatformEffector2D>
	{
		
		public PlatformEffector2DVariable()
		{
		}
		
		public PlatformEffector2DVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.PlatformEffector2D))]
	public sealed partial class PlatformEffector2DListVariable : ListVariable<UnityEngine.PlatformEffector2D>
	{
		
		public PlatformEffector2DListVariable()
		{
		}
		
		public PlatformEffector2DListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.PlatformEffector2D))]
	public sealed partial class PlatformEffector2DRef : BaseComponentRef<UnityEngine.PlatformEffector2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.PlatformEffector2D))]
	public sealed partial class PlatformEffector2DVar : BaseComponentVar<UnityEngine.PlatformEffector2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.PlatformEffector2D))]
	public sealed partial class PlatformEffector2DListRef : ListVariableRef<UnityEngine.PlatformEffector2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.PlatformEffector2D))]
	public sealed partial class PlatformEffector2DListVar : ListVariableVar<UnityEngine.PlatformEffector2D>
	{
	}
}
