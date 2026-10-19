
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioDistortionFilter))]
	public sealed partial class AudioDistortionFilterVariable : Variable<UnityEngine.AudioDistortionFilter>
	{
		
		public AudioDistortionFilterVariable()
		{
		}
		
		public AudioDistortionFilterVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioDistortionFilter))]
	public sealed partial class AudioDistortionFilterListVariable : ListVariable<UnityEngine.AudioDistortionFilter>
	{
		
		public AudioDistortionFilterListVariable()
		{
		}
		
		public AudioDistortionFilterListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioDistortionFilter))]
	public sealed partial class AudioDistortionFilterRef : BaseComponentRef<UnityEngine.AudioDistortionFilter>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioDistortionFilter))]
	public sealed partial class AudioDistortionFilterVar : BaseComponentVar<UnityEngine.AudioDistortionFilter>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioDistortionFilter))]
	public sealed partial class AudioDistortionFilterListRef : ListVariableRef<UnityEngine.AudioDistortionFilter>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioDistortionFilter))]
	public sealed partial class AudioDistortionFilterListVar : ListVariableVar<UnityEngine.AudioDistortionFilter>
	{
	}
}
