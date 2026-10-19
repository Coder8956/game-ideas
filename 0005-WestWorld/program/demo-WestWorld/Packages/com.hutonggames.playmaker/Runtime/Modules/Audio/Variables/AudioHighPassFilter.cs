
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioHighPassFilter))]
	public sealed partial class AudioHighPassFilterVariable : Variable<UnityEngine.AudioHighPassFilter>
	{
		
		public AudioHighPassFilterVariable()
		{
		}
		
		public AudioHighPassFilterVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioHighPassFilter))]
	public sealed partial class AudioHighPassFilterListVariable : ListVariable<UnityEngine.AudioHighPassFilter>
	{
		
		public AudioHighPassFilterListVariable()
		{
		}
		
		public AudioHighPassFilterListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioHighPassFilter))]
	public sealed partial class AudioHighPassFilterRef : BaseComponentRef<UnityEngine.AudioHighPassFilter>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioHighPassFilter))]
	public sealed partial class AudioHighPassFilterVar : BaseComponentVar<UnityEngine.AudioHighPassFilter>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioHighPassFilter))]
	public sealed partial class AudioHighPassFilterListRef : ListVariableRef<UnityEngine.AudioHighPassFilter>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioHighPassFilter))]
	public sealed partial class AudioHighPassFilterListVar : ListVariableVar<UnityEngine.AudioHighPassFilter>
	{
	}
}
