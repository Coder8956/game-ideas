
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.EffectorForceMode2D))]
	public sealed partial class EffectorForceMode2DVariable : Variable<UnityEngine.EffectorForceMode2D>
	{
		
		public EffectorForceMode2DVariable()
		{
		}
		
		public EffectorForceMode2DVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.EffectorForceMode2D))]
	public sealed partial class EffectorForceMode2DListVariable : ListVariable<UnityEngine.EffectorForceMode2D>
	{
		
		public EffectorForceMode2DListVariable()
		{
		}
		
		public EffectorForceMode2DListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.EffectorForceMode2D))]
	public sealed partial class EffectorForceMode2DRef : VariableRef<UnityEngine.EffectorForceMode2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.EffectorForceMode2D))]
	public sealed partial class EffectorForceMode2DVar : VariableVar<UnityEngine.EffectorForceMode2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.EffectorForceMode2D))]
	public sealed partial class EffectorForceMode2DListRef : ListVariableRef<UnityEngine.EffectorForceMode2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.EffectorForceMode2D))]
	public sealed partial class EffectorForceMode2DListVar : ListVariableVar<UnityEngine.EffectorForceMode2D>
	{
	}
}
