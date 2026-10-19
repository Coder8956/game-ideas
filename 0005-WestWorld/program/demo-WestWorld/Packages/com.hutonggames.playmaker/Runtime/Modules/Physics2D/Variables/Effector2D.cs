
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Effector2D))]
	public sealed partial class Effector2DVariable : Variable<UnityEngine.Effector2D>
	{
		
		public Effector2DVariable()
		{
		}
		
		public Effector2DVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Effector2D))]
	public sealed partial class Effector2DListVariable : ListVariable<UnityEngine.Effector2D>
	{
		
		public Effector2DListVariable()
		{
		}
		
		public Effector2DListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Effector2D))]
	public sealed partial class Effector2DRef : BaseComponentRef<UnityEngine.Effector2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Effector2D))]
	public sealed partial class Effector2DVar : BaseComponentVar<UnityEngine.Effector2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Effector2D))]
	public sealed partial class Effector2DListRef : ListVariableRef<UnityEngine.Effector2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Effector2D))]
	public sealed partial class Effector2DListVar : ListVariableVar<UnityEngine.Effector2D>
	{
	}
}
