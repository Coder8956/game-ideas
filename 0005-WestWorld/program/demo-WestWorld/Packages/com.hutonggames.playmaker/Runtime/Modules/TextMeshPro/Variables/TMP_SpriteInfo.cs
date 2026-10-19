
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_SpriteInfo))]
	public sealed partial class TMP_SpriteInfoVariable : Variable<TMPro.TMP_SpriteInfo>
	{
		
		public TMP_SpriteInfoVariable()
		{
		}
		
		public TMP_SpriteInfoVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_SpriteInfo))]
	public sealed partial class TMP_SpriteInfoListVariable : ListVariable<TMPro.TMP_SpriteInfo>
	{
		
		public TMP_SpriteInfoListVariable()
		{
		}
		
		public TMP_SpriteInfoListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_SpriteInfo))]
	public sealed partial class TMP_SpriteInfoRef : VariableRef<TMPro.TMP_SpriteInfo>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_SpriteInfo))]
	public sealed partial class TMP_SpriteInfoVar : VariableVar<TMPro.TMP_SpriteInfo>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_SpriteInfo))]
	public sealed partial class TMP_SpriteInfoListRef : ListVariableRef<TMPro.TMP_SpriteInfo>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_SpriteInfo))]
	public sealed partial class TMP_SpriteInfoListVar : ListVariableVar<TMPro.TMP_SpriteInfo>
	{
	}
}
