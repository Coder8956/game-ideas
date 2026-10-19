
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioReverbZone))]
	public sealed partial class AudioReverbZoneVariable : Variable<UnityEngine.AudioReverbZone>
	{
		
		public AudioReverbZoneVariable()
		{
		}
		
		public AudioReverbZoneVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioReverbZone))]
	public sealed partial class AudioReverbZoneListVariable : ListVariable<UnityEngine.AudioReverbZone>
	{
		
		public AudioReverbZoneListVariable()
		{
		}
		
		public AudioReverbZoneListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioReverbZone))]
	public sealed partial class AudioReverbZoneRef : BaseComponentRef<UnityEngine.AudioReverbZone>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioReverbZone))]
	public sealed partial class AudioReverbZoneVar : BaseComponentVar<UnityEngine.AudioReverbZone>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioReverbZone))]
	public sealed partial class AudioReverbZoneListRef : ListVariableRef<UnityEngine.AudioReverbZone>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioReverbZone))]
	public sealed partial class AudioReverbZoneListVar : ListVariableVar<UnityEngine.AudioReverbZone>
	{
	}
}
