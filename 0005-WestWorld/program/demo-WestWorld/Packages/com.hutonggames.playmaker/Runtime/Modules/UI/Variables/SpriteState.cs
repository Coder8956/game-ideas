
using System;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.SpriteState))]
	public sealed partial class SpriteStateVariable : Variable<UnityEngine.UI.SpriteState>
	{
		
		public SpriteStateVariable()
		{
		}
		
		public SpriteStateVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.SpriteState))]
	public sealed partial class SpriteStateListVariable : ListVariable<UnityEngine.UI.SpriteState>
	{
		
		public SpriteStateListVariable()
		{
		}
		
		public SpriteStateListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.SpriteState))]
	public sealed partial class SpriteStateRef : VariableRef<UnityEngine.UI.SpriteState>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.SpriteState))]
	public sealed partial class SpriteStateVar : VariableVar<UnityEngine.UI.SpriteState>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.SpriteState))]
	public sealed partial class SpriteStateListRef : ListVariableRef<UnityEngine.UI.SpriteState>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.SpriteState))]
	public sealed partial class SpriteStateListVar : ListVariableVar<UnityEngine.UI.SpriteState>
	{
	}
}
