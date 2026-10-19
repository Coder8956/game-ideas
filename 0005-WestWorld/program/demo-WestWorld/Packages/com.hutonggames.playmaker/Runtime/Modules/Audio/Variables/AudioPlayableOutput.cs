
using System;


namespace HutongGames.PlayMaker.Actions.Audio
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Audio.AudioPlayableOutput))]
	public sealed partial class AudioPlayableOutputVariable : Variable<UnityEngine.Audio.AudioPlayableOutput>
	{
		
		public AudioPlayableOutputVariable()
		{
		}
		
		public AudioPlayableOutputVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Audio.AudioPlayableOutput))]
	public sealed partial class AudioPlayableOutputListVariable : ListVariable<UnityEngine.Audio.AudioPlayableOutput>
	{
		
		public AudioPlayableOutputListVariable()
		{
		}
		
		public AudioPlayableOutputListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Audio.AudioPlayableOutput))]
	public sealed partial class AudioPlayableOutputRef : VariableRef<UnityEngine.Audio.AudioPlayableOutput>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Audio.AudioPlayableOutput))]
	public sealed partial class AudioPlayableOutputVar : VariableVar<UnityEngine.Audio.AudioPlayableOutput>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Audio.AudioPlayableOutput))]
	public sealed partial class AudioPlayableOutputListRef : ListVariableRef<UnityEngine.Audio.AudioPlayableOutput>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Audio.AudioPlayableOutput))]
	public sealed partial class AudioPlayableOutputListVar : ListVariableVar<UnityEngine.Audio.AudioPlayableOutput>
	{
	}
}
