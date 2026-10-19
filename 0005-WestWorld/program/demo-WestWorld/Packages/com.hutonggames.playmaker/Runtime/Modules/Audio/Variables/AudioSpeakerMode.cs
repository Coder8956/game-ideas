
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioSpeakerMode))]
	public sealed partial class AudioSpeakerModeVariable : Variable<UnityEngine.AudioSpeakerMode>
	{
		
		public AudioSpeakerModeVariable()
		{
		}
		
		public AudioSpeakerModeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioSpeakerMode))]
	public sealed partial class AudioSpeakerModeListVariable : ListVariable<UnityEngine.AudioSpeakerMode>
	{
		
		public AudioSpeakerModeListVariable()
		{
		}
		
		public AudioSpeakerModeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioSpeakerMode))]
	public sealed partial class AudioSpeakerModeRef : VariableRef<UnityEngine.AudioSpeakerMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioSpeakerMode))]
	public sealed partial class AudioSpeakerModeVar : VariableVar<UnityEngine.AudioSpeakerMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioSpeakerMode))]
	public sealed partial class AudioSpeakerModeListRef : ListVariableRef<UnityEngine.AudioSpeakerMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioSpeakerMode))]
	public sealed partial class AudioSpeakerModeListVar : ListVariableVar<UnityEngine.AudioSpeakerMode>
	{
	}
}
