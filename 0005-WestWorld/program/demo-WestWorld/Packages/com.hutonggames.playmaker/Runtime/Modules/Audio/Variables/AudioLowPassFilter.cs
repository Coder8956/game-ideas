
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioLowPassFilter))]
	public sealed partial class AudioLowPassFilterVariable : Variable<UnityEngine.AudioLowPassFilter>
	{
		
		public AudioLowPassFilterVariable()
		{
		}
		
		public AudioLowPassFilterVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioLowPassFilter))]
	public sealed partial class AudioLowPassFilterListVariable : ListVariable<UnityEngine.AudioLowPassFilter>
	{
		
		public AudioLowPassFilterListVariable()
		{
		}
		
		public AudioLowPassFilterListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioLowPassFilter))]
	public sealed partial class AudioLowPassFilterRef : BaseComponentRef<UnityEngine.AudioLowPassFilter>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioLowPassFilter))]
	public sealed partial class AudioLowPassFilterVar : BaseComponentVar<UnityEngine.AudioLowPassFilter>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioLowPassFilter))]
	public sealed partial class AudioLowPassFilterListRef : ListVariableRef<UnityEngine.AudioLowPassFilter>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioLowPassFilter))]
	public sealed partial class AudioLowPassFilterListVar : ListVariableVar<UnityEngine.AudioLowPassFilter>
	{
	}
}
