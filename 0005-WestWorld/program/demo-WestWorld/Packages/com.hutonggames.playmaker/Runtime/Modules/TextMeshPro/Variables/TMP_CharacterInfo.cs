
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_CharacterInfo))]
	public sealed partial class TMP_CharacterInfoVariable : Variable<TMPro.TMP_CharacterInfo>
	{
		
		public TMP_CharacterInfoVariable()
		{
		}
		
		public TMP_CharacterInfoVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_CharacterInfo))]
	public sealed partial class TMP_CharacterInfoListVariable : ListVariable<TMPro.TMP_CharacterInfo>
	{
		
		public TMP_CharacterInfoListVariable()
		{
		}
		
		public TMP_CharacterInfoListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_CharacterInfo))]
	public sealed partial class TMP_CharacterInfoRef : VariableRef<TMPro.TMP_CharacterInfo>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_CharacterInfo))]
	public sealed partial class TMP_CharacterInfoVar : VariableVar<TMPro.TMP_CharacterInfo>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_CharacterInfo))]
	public sealed partial class TMP_CharacterInfoListRef : ListVariableRef<TMPro.TMP_CharacterInfo>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_CharacterInfo))]
	public sealed partial class TMP_CharacterInfoListVar : ListVariableVar<TMPro.TMP_CharacterInfo>
	{
	}
}
