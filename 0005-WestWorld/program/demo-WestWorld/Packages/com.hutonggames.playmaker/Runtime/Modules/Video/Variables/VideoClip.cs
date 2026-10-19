
using System;
using UnityEngine;
using UnityEngine.Video;


namespace HutongGames.PlayMaker
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Video.VideoClip))]
	public sealed partial class VideoClipVariable : Variable<VideoClip>
	{
		
		public VideoClipVariable()
		{
		}
		
		public VideoClipVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Video.VideoClip))]
	public sealed partial class VideoClipListVariable : ListVariable<VideoClip>
	{
		
		public VideoClipListVariable()
		{
		}
		
		public VideoClipListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Video.VideoClip))]
	public sealed partial class VideoClipRef : VariableRef<VideoClip>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Video.VideoClip))]
	public sealed partial class VideoClipVar : VariableVar<VideoClip>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Video.VideoClip))]
	public sealed partial class VideoClipListRef : ListVariableRef<VideoClip>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Video.VideoClip))]
	public sealed partial class VideoClipListVar : ListVariableVar<VideoClip>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Video.VideoClip))]
	public sealed partial class VideoClipOverride : VariableOverride<VideoClip,VideoClipVariable,VideoClipVar>
	{
		
		public VideoClipOverride(IVariable variable) : 
				base(variable)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Video.VideoClip))]
	public sealed partial class VideoClipOutput : VariableOutput<VideoClip,VideoClipVariable,VideoClipRef>
	{
		
		public VideoClipOutput(IVariable variable) : 
				base(variable)
		{
		}
	}
}
