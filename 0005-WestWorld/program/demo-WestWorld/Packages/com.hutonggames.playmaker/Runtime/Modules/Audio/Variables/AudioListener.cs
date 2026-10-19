
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioListener))]
	public sealed partial class AudioListenerVariable : Variable<UnityEngine.AudioListener>
	{
		
		public AudioListenerVariable()
		{
		}
		
		public AudioListenerVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioListener))]
	public sealed partial class AudioListenerListVariable : ListVariable<UnityEngine.AudioListener>
	{
		
		public AudioListenerListVariable()
		{
		}
		
		public AudioListenerListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioListener))]
	public sealed partial class AudioListenerRef : BaseComponentRef<UnityEngine.AudioListener>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioListener))]
	public sealed partial class AudioListenerVar : BaseComponentVar<UnityEngine.AudioListener>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioListener))]
	public sealed partial class AudioListenerListRef : ListVariableRef<UnityEngine.AudioListener>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioListener))]
	public sealed partial class AudioListenerListVar : ListVariableVar<UnityEngine.AudioListener>
	{
	}
}
