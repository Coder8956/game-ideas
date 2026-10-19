
using System;


namespace HutongGames.PlayMaker.Actions.Audio
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Audio.AudioMixer))]
	public sealed partial class AudioMixerVariable : Variable<UnityEngine.Audio.AudioMixer>
	{
		
		public AudioMixerVariable()
		{
		}
		
		public AudioMixerVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Audio.AudioMixer))]
	public sealed partial class AudioMixerListVariable : ListVariable<UnityEngine.Audio.AudioMixer>
	{
		
		public AudioMixerListVariable()
		{
		}
		
		public AudioMixerListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Audio.AudioMixer))]
	public sealed partial class AudioMixerRef : VariableRef<UnityEngine.Audio.AudioMixer>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Audio.AudioMixer))]
	public sealed partial class AudioMixerVar : VariableVar<UnityEngine.Audio.AudioMixer>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Audio.AudioMixer))]
	public sealed partial class AudioMixerListRef : ListVariableRef<UnityEngine.Audio.AudioMixer>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Audio.AudioMixer))]
	public sealed partial class AudioMixerListVar : ListVariableVar<UnityEngine.Audio.AudioMixer>
	{
	}
}
