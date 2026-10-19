
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.BuoyancyEffector2D))]
	public sealed partial class BuoyancyEffector2DVariable : Variable<UnityEngine.BuoyancyEffector2D>
	{
		
		public BuoyancyEffector2DVariable()
		{
		}
		
		public BuoyancyEffector2DVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.BuoyancyEffector2D))]
	public sealed partial class BuoyancyEffector2DListVariable : ListVariable<UnityEngine.BuoyancyEffector2D>
	{
		
		public BuoyancyEffector2DListVariable()
		{
		}
		
		public BuoyancyEffector2DListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.BuoyancyEffector2D))]
	public sealed partial class BuoyancyEffector2DRef : BaseComponentRef<UnityEngine.BuoyancyEffector2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.BuoyancyEffector2D))]
	public sealed partial class BuoyancyEffector2DVar : BaseComponentVar<UnityEngine.BuoyancyEffector2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.BuoyancyEffector2D))]
	public sealed partial class BuoyancyEffector2DListRef : ListVariableRef<UnityEngine.BuoyancyEffector2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.BuoyancyEffector2D))]
	public sealed partial class BuoyancyEffector2DListVar : ListVariableVar<UnityEngine.BuoyancyEffector2D>
	{
	}
}
