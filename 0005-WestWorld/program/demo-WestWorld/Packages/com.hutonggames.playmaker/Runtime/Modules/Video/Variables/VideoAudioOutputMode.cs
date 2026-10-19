
using System;


namespace HutongGames.PlayMaker.Actions.Video
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Video.VideoAudioOutputMode))]
	public sealed partial class VideoAudioOutputModeVariable : Variable<UnityEngine.Video.VideoAudioOutputMode>
	{
		
		public VideoAudioOutputModeVariable()
		{
		}
		
		public VideoAudioOutputModeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Video.VideoAudioOutputMode))]
	public sealed partial class VideoAudioOutputModeListVariable : ListVariable<UnityEngine.Video.VideoAudioOutputMode>
	{
		
		public VideoAudioOutputModeListVariable()
		{
		}
		
		public VideoAudioOutputModeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Video.VideoAudioOutputMode))]
	public sealed partial class VideoAudioOutputModeRef : VariableRef<UnityEngine.Video.VideoAudioOutputMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Video.VideoAudioOutputMode))]
	public sealed partial class VideoAudioOutputModeVar : VariableVar<UnityEngine.Video.VideoAudioOutputMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Video.VideoAudioOutputMode))]
	public sealed partial class VideoAudioOutputModeListRef : ListVariableRef<UnityEngine.Video.VideoAudioOutputMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Video.VideoAudioOutputMode))]
	public sealed partial class VideoAudioOutputModeListVar : ListVariableVar<UnityEngine.Video.VideoAudioOutputMode>
	{
	}
}
