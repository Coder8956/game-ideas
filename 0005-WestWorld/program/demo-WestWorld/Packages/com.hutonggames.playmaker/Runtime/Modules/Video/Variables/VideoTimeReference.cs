
using System;


namespace HutongGames.PlayMaker.Actions.Video
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Video.VideoTimeReference))]
	public sealed partial class VideoTimeReferenceVariable : Variable<UnityEngine.Video.VideoTimeReference>
	{
		
		public VideoTimeReferenceVariable()
		{
		}
		
		public VideoTimeReferenceVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Video.VideoTimeReference))]
	public sealed partial class VideoTimeReferenceListVariable : ListVariable<UnityEngine.Video.VideoTimeReference>
	{
		
		public VideoTimeReferenceListVariable()
		{
		}
		
		public VideoTimeReferenceListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Video.VideoTimeReference))]
	public sealed partial class VideoTimeReferenceRef : VariableRef<UnityEngine.Video.VideoTimeReference>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Video.VideoTimeReference))]
	public sealed partial class VideoTimeReferenceVar : VariableVar<UnityEngine.Video.VideoTimeReference>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Video.VideoTimeReference))]
	public sealed partial class VideoTimeReferenceListRef : ListVariableRef<UnityEngine.Video.VideoTimeReference>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Video.VideoTimeReference))]
	public sealed partial class VideoTimeReferenceListVar : ListVariableVar<UnityEngine.Video.VideoTimeReference>
	{
	}
}
