
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioDataLoadState))]
	public sealed partial class AudioDataLoadStateVariable : Variable<UnityEngine.AudioDataLoadState>
	{
		
		public AudioDataLoadStateVariable()
		{
		}
		
		public AudioDataLoadStateVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioDataLoadState))]
	public sealed partial class AudioDataLoadStateListVariable : ListVariable<UnityEngine.AudioDataLoadState>
	{
		
		public AudioDataLoadStateListVariable()
		{
		}
		
		public AudioDataLoadStateListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioDataLoadState))]
	public sealed partial class AudioDataLoadStateRef : VariableRef<UnityEngine.AudioDataLoadState>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioDataLoadState))]
	public sealed partial class AudioDataLoadStateVar : VariableVar<UnityEngine.AudioDataLoadState>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioDataLoadState))]
	public sealed partial class AudioDataLoadStateListRef : ListVariableRef<UnityEngine.AudioDataLoadState>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioDataLoadState))]
	public sealed partial class AudioDataLoadStateListVar : ListVariableVar<UnityEngine.AudioDataLoadState>
	{
	}
}
