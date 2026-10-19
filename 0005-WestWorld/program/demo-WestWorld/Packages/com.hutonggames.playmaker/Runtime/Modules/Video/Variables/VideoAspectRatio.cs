
using System;


namespace HutongGames.PlayMaker.Actions.Video
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Video.VideoAspectRatio))]
	public sealed partial class VideoAspectRatioVariable : Variable<UnityEngine.Video.VideoAspectRatio>
	{
		
		public VideoAspectRatioVariable()
		{
		}
		
		public VideoAspectRatioVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Video.VideoAspectRatio))]
	public sealed partial class VideoAspectRatioListVariable : ListVariable<UnityEngine.Video.VideoAspectRatio>
	{
		
		public VideoAspectRatioListVariable()
		{
		}
		
		public VideoAspectRatioListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Video.VideoAspectRatio))]
	public sealed partial class VideoAspectRatioRef : VariableRef<UnityEngine.Video.VideoAspectRatio>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Video.VideoAspectRatio))]
	public sealed partial class VideoAspectRatioVar : VariableVar<UnityEngine.Video.VideoAspectRatio>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Video.VideoAspectRatio))]
	public sealed partial class VideoAspectRatioListRef : ListVariableRef<UnityEngine.Video.VideoAspectRatio>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Video.VideoAspectRatio))]
	public sealed partial class VideoAspectRatioListVar : ListVariableVar<UnityEngine.Video.VideoAspectRatio>
	{
	}
}
