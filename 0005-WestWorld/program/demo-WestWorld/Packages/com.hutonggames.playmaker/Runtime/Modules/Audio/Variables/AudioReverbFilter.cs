
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioReverbFilter))]
	public sealed partial class AudioReverbFilterVariable : Variable<UnityEngine.AudioReverbFilter>
	{
		
		public AudioReverbFilterVariable()
		{
		}
		
		public AudioReverbFilterVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioReverbFilter))]
	public sealed partial class AudioReverbFilterListVariable : ListVariable<UnityEngine.AudioReverbFilter>
	{
		
		public AudioReverbFilterListVariable()
		{
		}
		
		public AudioReverbFilterListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioReverbFilter))]
	public sealed partial class AudioReverbFilterRef : BaseComponentRef<UnityEngine.AudioReverbFilter>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioReverbFilter))]
	public sealed partial class AudioReverbFilterVar : BaseComponentVar<UnityEngine.AudioReverbFilter>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioReverbFilter))]
	public sealed partial class AudioReverbFilterListRef : ListVariableRef<UnityEngine.AudioReverbFilter>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioReverbFilter))]
	public sealed partial class AudioReverbFilterListVar : ListVariableVar<UnityEngine.AudioReverbFilter>
	{
	}
}
