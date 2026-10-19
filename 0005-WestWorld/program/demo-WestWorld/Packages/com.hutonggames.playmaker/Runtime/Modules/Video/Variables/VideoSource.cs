
using System;


namespace HutongGames.PlayMaker.Actions.Video
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Video.VideoSource))]
	public sealed partial class VideoSourceVariable : Variable<UnityEngine.Video.VideoSource>
	{
		
		public VideoSourceVariable()
		{
		}
		
		public VideoSourceVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Video.VideoSource))]
	public sealed partial class VideoSourceListVariable : ListVariable<UnityEngine.Video.VideoSource>
	{
		
		public VideoSourceListVariable()
		{
		}
		
		public VideoSourceListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Video.VideoSource))]
	public sealed partial class VideoSourceRef : VariableRef<UnityEngine.Video.VideoSource>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Video.VideoSource))]
	public sealed partial class VideoSourceVar : VariableVar<UnityEngine.Video.VideoSource>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Video.VideoSource))]
	public sealed partial class VideoSourceListRef : ListVariableRef<UnityEngine.Video.VideoSource>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Video.VideoSource))]
	public sealed partial class VideoSourceListVar : ListVariableVar<UnityEngine.Video.VideoSource>
	{
	}
}
