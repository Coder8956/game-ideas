#if UNITY_EDITOR || UNITY_PS4 || UNITY_PS5

using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.GamepadSpeakerOutputType))]
	public sealed partial class GamepadSpeakerOutputTypeVariable : Variable<UnityEngine.GamepadSpeakerOutputType>
	{
		
		public GamepadSpeakerOutputTypeVariable()
		{
		}
		
		public GamepadSpeakerOutputTypeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.GamepadSpeakerOutputType))]
	public sealed partial class GamepadSpeakerOutputTypeListVariable : ListVariable<UnityEngine.GamepadSpeakerOutputType>
	{
		
		public GamepadSpeakerOutputTypeListVariable()
		{
		}
		
		public GamepadSpeakerOutputTypeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.GamepadSpeakerOutputType))]
	public sealed partial class GamepadSpeakerOutputTypeRef : VariableRef<UnityEngine.GamepadSpeakerOutputType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.GamepadSpeakerOutputType))]
	public sealed partial class GamepadSpeakerOutputTypeVar : VariableVar<UnityEngine.GamepadSpeakerOutputType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.GamepadSpeakerOutputType))]
	public sealed partial class GamepadSpeakerOutputTypeListRef : ListVariableRef<UnityEngine.GamepadSpeakerOutputType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.GamepadSpeakerOutputType))]
	public sealed partial class GamepadSpeakerOutputTypeListVar : ListVariableVar<UnityEngine.GamepadSpeakerOutputType>
	{
	}
}

#endif