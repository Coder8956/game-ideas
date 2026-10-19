
using System;


namespace HutongGames.PlayMaker.Actions.Rendering
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.TextureDimension))]
	public sealed partial class TextureDimensionVariable : Variable<UnityEngine.Rendering.TextureDimension>
	{
		
		public TextureDimensionVariable()
		{
		}
		
		public TextureDimensionVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.TextureDimension))]
	public sealed partial class TextureDimensionListVariable : ListVariable<UnityEngine.Rendering.TextureDimension>
	{
		
		public TextureDimensionListVariable()
		{
		}
		
		public TextureDimensionListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.TextureDimension))]
	public sealed partial class TextureDimensionRef : VariableRef<UnityEngine.Rendering.TextureDimension>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.TextureDimension))]
	public sealed partial class TextureDimensionVar : VariableVar<UnityEngine.Rendering.TextureDimension>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.TextureDimension))]
	public sealed partial class TextureDimensionListRef : ListVariableRef<UnityEngine.Rendering.TextureDimension>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.TextureDimension))]
	public sealed partial class TextureDimensionListVar : ListVariableVar<UnityEngine.Rendering.TextureDimension>
	{
	}
}
