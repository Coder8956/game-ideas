
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.SpriteDrawMode))]
	public sealed partial class SpriteDrawModeVariable : Variable<UnityEngine.SpriteDrawMode>
	{
		
		public SpriteDrawModeVariable()
		{
		}
		
		public SpriteDrawModeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SpriteDrawMode))]
	public sealed partial class SpriteDrawModeListVariable : ListVariable<UnityEngine.SpriteDrawMode>
	{
		
		public SpriteDrawModeListVariable()
		{
		}
		
		public SpriteDrawModeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SpriteDrawMode))]
	public sealed partial class SpriteDrawModeRef : VariableRef<UnityEngine.SpriteDrawMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SpriteDrawMode))]
	public sealed partial class SpriteDrawModeVar : VariableVar<UnityEngine.SpriteDrawMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SpriteDrawMode))]
	public sealed partial class SpriteDrawModeListRef : ListVariableRef<UnityEngine.SpriteDrawMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SpriteDrawMode))]
	public sealed partial class SpriteDrawModeListVar : ListVariableVar<UnityEngine.SpriteDrawMode>
	{
	}
}
