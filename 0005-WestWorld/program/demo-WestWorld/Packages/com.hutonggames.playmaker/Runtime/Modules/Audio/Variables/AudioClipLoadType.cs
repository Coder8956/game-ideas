
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioClipLoadType))]
	public sealed partial class AudioClipLoadTypeVariable : Variable<UnityEngine.AudioClipLoadType>
	{
		
		public AudioClipLoadTypeVariable()
		{
		}
		
		public AudioClipLoadTypeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioClipLoadType))]
	public sealed partial class AudioClipLoadTypeListVariable : ListVariable<UnityEngine.AudioClipLoadType>
	{
		
		public AudioClipLoadTypeListVariable()
		{
		}
		
		public AudioClipLoadTypeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioClipLoadType))]
	public sealed partial class AudioClipLoadTypeRef : VariableRef<UnityEngine.AudioClipLoadType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioClipLoadType))]
	public sealed partial class AudioClipLoadTypeVar : VariableVar<UnityEngine.AudioClipLoadType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioClipLoadType))]
	public sealed partial class AudioClipLoadTypeListRef : ListVariableRef<UnityEngine.AudioClipLoadType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioClipLoadType))]
	public sealed partial class AudioClipLoadTypeListVar : ListVariableVar<UnityEngine.AudioClipLoadType>
	{
	}
}
