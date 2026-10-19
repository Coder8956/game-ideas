
using System;
using UnityEngine;
using UnityEngine.Video;


namespace HutongGames.PlayMaker
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Video.VideoPlayer))]
	public sealed partial class VideoPlayerVariable : Variable<VideoPlayer>
	{
		
		public VideoPlayerVariable()
		{
		}
		
		public VideoPlayerVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Video.VideoPlayer))]
	public sealed partial class VideoPlayerListVariable : ListVariable<VideoPlayer>
	{
		
		public VideoPlayerListVariable()
		{
		}
		
		public VideoPlayerListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Video.VideoPlayer))]
	public sealed partial class VideoPlayerRef : BaseComponentRef<VideoPlayer>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Video.VideoPlayer))]
	public sealed partial class VideoPlayerVar : BaseComponentVar<VideoPlayer>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Video.VideoPlayer))]
	public sealed partial class VideoPlayerListRef : ListVariableRef<VideoPlayer>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Video.VideoPlayer))]
	public sealed partial class VideoPlayerListVar : ListVariableVar<VideoPlayer>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Video.VideoPlayer))]
	public sealed partial class VideoPlayerOverride : VariableOverride<VideoPlayer,VideoPlayerVariable,VideoPlayerVar>
	{
		
		public VideoPlayerOverride(IVariable variable) : 
				base(variable)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Video.VideoPlayer))]
	public sealed partial class VideoPlayerOutput : VariableOutput<VideoPlayer,VideoPlayerVariable,VideoPlayerRef>
	{
		
		public VideoPlayerOutput(IVariable variable) : 
				base(variable)
		{
		}
	}
}
