
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioReverbPreset))]
	public sealed partial class AudioReverbPresetVariable : Variable<UnityEngine.AudioReverbPreset>
	{
		
		public AudioReverbPresetVariable()
		{
		}
		
		public AudioReverbPresetVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioReverbPreset))]
	public sealed partial class AudioReverbPresetListVariable : ListVariable<UnityEngine.AudioReverbPreset>
	{
		
		public AudioReverbPresetListVariable()
		{
		}
		
		public AudioReverbPresetListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioReverbPreset))]
	public sealed partial class AudioReverbPresetRef : VariableRef<UnityEngine.AudioReverbPreset>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioReverbPreset))]
	public sealed partial class AudioReverbPresetVar : VariableVar<UnityEngine.AudioReverbPreset>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioReverbPreset))]
	public sealed partial class AudioReverbPresetListRef : ListVariableRef<UnityEngine.AudioReverbPreset>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioReverbPreset))]
	public sealed partial class AudioReverbPresetListVar : ListVariableVar<UnityEngine.AudioReverbPreset>
	{
	}
}
