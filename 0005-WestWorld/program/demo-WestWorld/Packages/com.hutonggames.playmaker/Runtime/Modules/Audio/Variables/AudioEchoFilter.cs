
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioEchoFilter))]
	public sealed partial class AudioEchoFilterVariable : Variable<UnityEngine.AudioEchoFilter>
	{
		
		public AudioEchoFilterVariable()
		{
		}
		
		public AudioEchoFilterVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioEchoFilter))]
	public sealed partial class AudioEchoFilterListVariable : ListVariable<UnityEngine.AudioEchoFilter>
	{
		
		public AudioEchoFilterListVariable()
		{
		}
		
		public AudioEchoFilterListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioEchoFilter))]
	public sealed partial class AudioEchoFilterRef : BaseComponentRef<UnityEngine.AudioEchoFilter>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioEchoFilter))]
	public sealed partial class AudioEchoFilterVar : BaseComponentVar<UnityEngine.AudioEchoFilter>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioEchoFilter))]
	public sealed partial class AudioEchoFilterListRef : ListVariableRef<UnityEngine.AudioEchoFilter>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioEchoFilter))]
	public sealed partial class AudioEchoFilterListVar : ListVariableVar<UnityEngine.AudioEchoFilter>
	{
	}
}
