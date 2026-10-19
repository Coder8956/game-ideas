
using System;


namespace HutongGames.PlayMaker.Actions.Audio
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Audio.AudioMixerSnapshot))]
	public sealed partial class AudioMixerSnapshotVariable : Variable<UnityEngine.Audio.AudioMixerSnapshot>
	{
		
		public AudioMixerSnapshotVariable()
		{
		}
		
		public AudioMixerSnapshotVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Audio.AudioMixerSnapshot))]
	public sealed partial class AudioMixerSnapshotListVariable : ListVariable<UnityEngine.Audio.AudioMixerSnapshot>
	{
		
		public AudioMixerSnapshotListVariable()
		{
		}
		
		public AudioMixerSnapshotListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Audio.AudioMixerSnapshot))]
	public sealed partial class AudioMixerSnapshotRef : VariableRef<UnityEngine.Audio.AudioMixerSnapshot>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Audio.AudioMixerSnapshot))]
	public sealed partial class AudioMixerSnapshotVar : VariableVar<UnityEngine.Audio.AudioMixerSnapshot>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Audio.AudioMixerSnapshot))]
	public sealed partial class AudioMixerSnapshotListRef : ListVariableRef<UnityEngine.Audio.AudioMixerSnapshot>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Audio.AudioMixerSnapshot))]
	public sealed partial class AudioMixerSnapshotListVar : ListVariableVar<UnityEngine.Audio.AudioMixerSnapshot>
	{
	}
}
