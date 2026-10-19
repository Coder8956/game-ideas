
using System;


namespace HutongGames.PlayMaker.Actions.Video
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Video.VideoTimeUpdateMode))]
	public sealed partial class VideoTimeUpdateModeVariable : Variable<UnityEngine.Video.VideoTimeUpdateMode>
	{
		
		public VideoTimeUpdateModeVariable()
		{
		}
		
		public VideoTimeUpdateModeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Video.VideoTimeUpdateMode))]
	public sealed partial class VideoTimeUpdateModeListVariable : ListVariable<UnityEngine.Video.VideoTimeUpdateMode>
	{
		
		public VideoTimeUpdateModeListVariable()
		{
		}
		
		public VideoTimeUpdateModeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Video.VideoTimeUpdateMode))]
	public sealed partial class VideoTimeUpdateModeRef : VariableRef<UnityEngine.Video.VideoTimeUpdateMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Video.VideoTimeUpdateMode))]
	public sealed partial class VideoTimeUpdateModeVar : VariableVar<UnityEngine.Video.VideoTimeUpdateMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Video.VideoTimeUpdateMode))]
	public sealed partial class VideoTimeUpdateModeListRef : ListVariableRef<UnityEngine.Video.VideoTimeUpdateMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Video.VideoTimeUpdateMode))]
	public sealed partial class VideoTimeUpdateModeListVar : ListVariableVar<UnityEngine.Video.VideoTimeUpdateMode>
	{
	}
}
