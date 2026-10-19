
using System;
using UnityEngine;


namespace HutongGames.PlayMaker
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.SpriteMaskInteraction))]
	public sealed partial class SpriteMaskInteractionVariable : Variable<SpriteMaskInteraction>
	{
		
		public SpriteMaskInteractionVariable()
		{
		}
		
		public SpriteMaskInteractionVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SpriteMaskInteraction))]
	public sealed partial class SpriteMaskInteractionListVariable : ListVariable<SpriteMaskInteraction>
	{
		
		public SpriteMaskInteractionListVariable()
		{
		}
		
		public SpriteMaskInteractionListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SpriteMaskInteraction))]
	public sealed partial class SpriteMaskInteractionRef : VariableRef<SpriteMaskInteraction>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SpriteMaskInteraction))]
	public sealed partial class SpriteMaskInteractionVar : VariableVar<SpriteMaskInteraction>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SpriteMaskInteraction))]
	public sealed partial class SpriteMaskInteractionListRef : ListVariableRef<SpriteMaskInteraction>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SpriteMaskInteraction))]
	public sealed partial class SpriteMaskInteractionListVar : ListVariableVar<SpriteMaskInteraction>
	{
	}
}
