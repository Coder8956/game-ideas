
using System;
using System.Collections.Generic;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Sprite))]
	public sealed partial class SpriteVariable : Variable<UnityEngine.Sprite>
	{
		
		public SpriteVariable()
		{
		}
		
		public SpriteVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Sprite))]
	public sealed partial class SpriteListVariable : ListVariable<UnityEngine.Sprite>
	{
		
		public SpriteListVariable()
		{
		}
		
		public SpriteListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Sprite))]
	public sealed partial class SpriteRef : VariableRef<UnityEngine.Sprite>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Sprite))]
	public sealed partial class SpriteVar : VariableVar<UnityEngine.Sprite>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Sprite))]
	public sealed partial class SpriteOverride : VariableOverride<UnityEngine.Sprite, SpriteVariable, SpriteVar>
	{
		public SpriteOverride(IVariable variable) : base(variable)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Sprite))]
	public sealed partial class SpriteOutput : VariableOutput<UnityEngine.Sprite, SpriteVariable, SpriteRef>
	{
		public SpriteOutput(IVariable variable) : base(variable)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Sprite))]
	public sealed partial class SpriteListRef : ListVariableRef<UnityEngine.Sprite>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Sprite))]
	public sealed partial class SpriteListVar : ListVariableVar<UnityEngine.Sprite>
	{
	}

	[Serializable]
	[DataType(typeof(UnityEngine.Sprite))]
	public sealed partial class SpriteListOverride : VariableOverride<List<UnityEngine.Sprite>, SpriteListVariable, SpriteListVar>
	{
		public SpriteListOverride(IVariable variable) : base(variable)
		{
		}
	}

	[Serializable]
	[DataType(typeof(UnityEngine.Sprite))]
	public sealed partial class SpriteListOutput : VariableOutput<List<UnityEngine.Sprite>, SpriteListVariable, SpriteListRef>
	{
		public SpriteListOutput(IVariable variable) : base(variable)
		{
		}
	}
}
