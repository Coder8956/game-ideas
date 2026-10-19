
using System;


namespace HutongGames.PlayMaker.Actions.Video
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Video.VideoRenderMode))]
	public sealed partial class VideoRenderModeVariable : Variable<UnityEngine.Video.VideoRenderMode>
	{
		
		public VideoRenderModeVariable()
		{
		}
		
		public VideoRenderModeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Video.VideoRenderMode))]
	public sealed partial class VideoRenderModeListVariable : ListVariable<UnityEngine.Video.VideoRenderMode>
	{
		
		public VideoRenderModeListVariable()
		{
		}
		
		public VideoRenderModeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Video.VideoRenderMode))]
	public sealed partial class VideoRenderModeRef : VariableRef<UnityEngine.Video.VideoRenderMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Video.VideoRenderMode))]
	public sealed partial class VideoRenderModeVar : VariableVar<UnityEngine.Video.VideoRenderMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Video.VideoRenderMode))]
	public sealed partial class VideoRenderModeListRef : ListVariableRef<UnityEngine.Video.VideoRenderMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Video.VideoRenderMode))]
	public sealed partial class VideoRenderModeListVar : ListVariableVar<UnityEngine.Video.VideoRenderMode>
	{
	}
}
