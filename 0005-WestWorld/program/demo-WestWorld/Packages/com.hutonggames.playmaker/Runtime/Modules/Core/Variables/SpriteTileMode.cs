
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.SpriteTileMode))]
	public sealed partial class SpriteTileModeVariable : Variable<UnityEngine.SpriteTileMode>
	{
		
		public SpriteTileModeVariable()
		{
		}
		
		public SpriteTileModeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SpriteTileMode))]
	public sealed partial class SpriteTileModeListVariable : ListVariable<UnityEngine.SpriteTileMode>
	{
		
		public SpriteTileModeListVariable()
		{
		}
		
		public SpriteTileModeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SpriteTileMode))]
	public sealed partial class SpriteTileModeRef : VariableRef<UnityEngine.SpriteTileMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SpriteTileMode))]
	public sealed partial class SpriteTileModeVar : VariableVar<UnityEngine.SpriteTileMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SpriteTileMode))]
	public sealed partial class SpriteTileModeListRef : ListVariableRef<UnityEngine.SpriteTileMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SpriteTileMode))]
	public sealed partial class SpriteTileModeListVar : ListVariableVar<UnityEngine.SpriteTileMode>
	{
	}
}
