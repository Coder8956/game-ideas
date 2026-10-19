
using System;


namespace HutongGames.PlayMaker.Actions.Video
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Video.Video3DLayout))]
	public sealed partial class Video3DLayoutVariable : Variable<UnityEngine.Video.Video3DLayout>
	{
		
		public Video3DLayoutVariable()
		{
		}
		
		public Video3DLayoutVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Video.Video3DLayout))]
	public sealed partial class Video3DLayoutListVariable : ListVariable<UnityEngine.Video.Video3DLayout>
	{
		
		public Video3DLayoutListVariable()
		{
		}
		
		public Video3DLayoutListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Video.Video3DLayout))]
	public sealed partial class Video3DLayoutRef : VariableRef<UnityEngine.Video.Video3DLayout>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Video.Video3DLayout))]
	public sealed partial class Video3DLayoutVar : VariableVar<UnityEngine.Video.Video3DLayout>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Video.Video3DLayout))]
	public sealed partial class Video3DLayoutListRef : ListVariableRef<UnityEngine.Video.Video3DLayout>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Video.Video3DLayout))]
	public sealed partial class Video3DLayoutListVar : ListVariableVar<UnityEngine.Video.Video3DLayout>
	{
	}
}
