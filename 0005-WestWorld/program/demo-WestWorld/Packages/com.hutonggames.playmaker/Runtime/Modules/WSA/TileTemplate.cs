
using System;


namespace HutongGames.PlayMaker.Actions.WSA
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.WSA.TileTemplate))]
	public sealed partial class TileTemplateVariable : Variable<UnityEngine.WSA.TileTemplate>
	{
		
		public TileTemplateVariable()
		{
		}
		
		public TileTemplateVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.WSA.TileTemplate))]
	public sealed partial class TileTemplateListVariable : ListVariable<UnityEngine.WSA.TileTemplate>
	{
		
		public TileTemplateListVariable()
		{
		}
		
		public TileTemplateListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.WSA.TileTemplate))]
	public sealed partial class TileTemplateRef : VariableRef<UnityEngine.WSA.TileTemplate>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.WSA.TileTemplate))]
	public sealed partial class TileTemplateVar : VariableVar<UnityEngine.WSA.TileTemplate>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.WSA.TileTemplate))]
	public sealed partial class TileTemplateListRef : ListVariableRef<UnityEngine.WSA.TileTemplate>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.WSA.TileTemplate))]
	public sealed partial class TileTemplateListVar : ListVariableVar<UnityEngine.WSA.TileTemplate>
	{
	}
}
