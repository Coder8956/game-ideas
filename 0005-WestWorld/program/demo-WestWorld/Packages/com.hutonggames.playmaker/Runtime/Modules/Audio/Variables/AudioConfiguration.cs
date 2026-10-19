
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioConfiguration))]
	public sealed partial class AudioConfigurationVariable : Variable<UnityEngine.AudioConfiguration>
	{
		
		public AudioConfigurationVariable()
		{
		}
		
		public AudioConfigurationVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioConfiguration))]
	public sealed partial class AudioConfigurationListVariable : ListVariable<UnityEngine.AudioConfiguration>
	{
		
		public AudioConfigurationListVariable()
		{
		}
		
		public AudioConfigurationListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioConfiguration))]
	public sealed partial class AudioConfigurationRef : VariableRef<UnityEngine.AudioConfiguration>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioConfiguration))]
	public sealed partial class AudioConfigurationVar : VariableVar<UnityEngine.AudioConfiguration>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioConfiguration))]
	public sealed partial class AudioConfigurationListRef : ListVariableRef<UnityEngine.AudioConfiguration>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioConfiguration))]
	public sealed partial class AudioConfigurationListVar : ListVariableVar<UnityEngine.AudioConfiguration>
	{
	}
}
