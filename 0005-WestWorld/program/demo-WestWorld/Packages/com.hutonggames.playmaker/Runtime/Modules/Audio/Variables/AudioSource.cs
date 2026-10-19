
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioSource))]
	public sealed partial class AudioSourceVariable : Variable<UnityEngine.AudioSource>
	{
		
		public AudioSourceVariable()
		{
		}
		
		public AudioSourceVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioSource))]
	public sealed partial class AudioSourceListVariable : ListVariable<UnityEngine.AudioSource>
	{
		
		public AudioSourceListVariable()
		{
		}
		
		public AudioSourceListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioSource))]
	public sealed partial class AudioSourceRef : BaseComponentRef<UnityEngine.AudioSource>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioSource))]
	public sealed partial class AudioSourceVar : BaseComponentVar<UnityEngine.AudioSource>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioSource))]
	public sealed partial class AudioSourceListRef : ListVariableRef<UnityEngine.AudioSource>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioSource))]
	public sealed partial class AudioSourceListVar : ListVariableVar<UnityEngine.AudioSource>
	{
	}
}
