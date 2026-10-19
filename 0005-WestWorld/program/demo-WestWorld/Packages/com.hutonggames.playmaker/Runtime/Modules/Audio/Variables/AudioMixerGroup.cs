
using System;


namespace HutongGames.PlayMaker.Actions.Audio
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Audio.AudioMixerGroup))]
	public sealed partial class AudioMixerGroupVariable : Variable<UnityEngine.Audio.AudioMixerGroup>
	{
		
		public AudioMixerGroupVariable()
		{
		}
		
		public AudioMixerGroupVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Audio.AudioMixerGroup))]
	public sealed partial class AudioMixerGroupListVariable : ListVariable<UnityEngine.Audio.AudioMixerGroup>
	{
		
		public AudioMixerGroupListVariable()
		{
		}
		
		public AudioMixerGroupListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Audio.AudioMixerGroup))]
	public sealed partial class AudioMixerGroupRef : VariableRef<UnityEngine.Audio.AudioMixerGroup>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Audio.AudioMixerGroup))]
	public sealed partial class AudioMixerGroupVar : VariableVar<UnityEngine.Audio.AudioMixerGroup>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Audio.AudioMixerGroup))]
	public sealed partial class AudioMixerGroupListRef : ListVariableRef<UnityEngine.Audio.AudioMixerGroup>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Audio.AudioMixerGroup))]
	public sealed partial class AudioMixerGroupListVar : ListVariableVar<UnityEngine.Audio.AudioMixerGroup>
	{
	}
}
