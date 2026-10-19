
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioChorusFilter))]
	public sealed partial class AudioChorusFilterVariable : Variable<UnityEngine.AudioChorusFilter>
	{
		
		public AudioChorusFilterVariable()
		{
		}
		
		public AudioChorusFilterVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioChorusFilter))]
	public sealed partial class AudioChorusFilterListVariable : ListVariable<UnityEngine.AudioChorusFilter>
	{
		
		public AudioChorusFilterListVariable()
		{
		}
		
		public AudioChorusFilterListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioChorusFilter))]
	public sealed partial class AudioChorusFilterRef : BaseComponentRef<UnityEngine.AudioChorusFilter>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioChorusFilter))]
	public sealed partial class AudioChorusFilterVar : BaseComponentVar<UnityEngine.AudioChorusFilter>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioChorusFilter))]
	public sealed partial class AudioChorusFilterListRef : ListVariableRef<UnityEngine.AudioChorusFilter>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioChorusFilter))]
	public sealed partial class AudioChorusFilterListVar : ListVariableVar<UnityEngine.AudioChorusFilter>
	{
	}
}
