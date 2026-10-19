
using System;


namespace HutongGames.PlayMaker.Actions.Audio
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Audio.AudioMixerUpdateMode))]
	public sealed partial class AudioMixerUpdateModeVariable : Variable<UnityEngine.Audio.AudioMixerUpdateMode>
	{
		
		public AudioMixerUpdateModeVariable()
		{
		}
		
		public AudioMixerUpdateModeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Audio.AudioMixerUpdateMode))]
	public sealed partial class AudioMixerUpdateModeListVariable : ListVariable<UnityEngine.Audio.AudioMixerUpdateMode>
	{
		
		public AudioMixerUpdateModeListVariable()
		{
		}
		
		public AudioMixerUpdateModeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Audio.AudioMixerUpdateMode))]
	public sealed partial class AudioMixerUpdateModeRef : VariableRef<UnityEngine.Audio.AudioMixerUpdateMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Audio.AudioMixerUpdateMode))]
	public sealed partial class AudioMixerUpdateModeVar : VariableVar<UnityEngine.Audio.AudioMixerUpdateMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Audio.AudioMixerUpdateMode))]
	public sealed partial class AudioMixerUpdateModeListRef : ListVariableRef<UnityEngine.Audio.AudioMixerUpdateMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Audio.AudioMixerUpdateMode))]
	public sealed partial class AudioMixerUpdateModeListVar : ListVariableVar<UnityEngine.Audio.AudioMixerUpdateMode>
	{
	}
}
