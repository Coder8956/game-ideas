
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioSourceCurveType))]
	public sealed partial class AudioSourceCurveTypeVariable : Variable<UnityEngine.AudioSourceCurveType>
	{
		
		public AudioSourceCurveTypeVariable()
		{
		}
		
		public AudioSourceCurveTypeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioSourceCurveType))]
	public sealed partial class AudioSourceCurveTypeListVariable : ListVariable<UnityEngine.AudioSourceCurveType>
	{
		
		public AudioSourceCurveTypeListVariable()
		{
		}
		
		public AudioSourceCurveTypeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioSourceCurveType))]
	public sealed partial class AudioSourceCurveTypeRef : VariableRef<UnityEngine.AudioSourceCurveType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioSourceCurveType))]
	public sealed partial class AudioSourceCurveTypeVar : VariableVar<UnityEngine.AudioSourceCurveType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioSourceCurveType))]
	public sealed partial class AudioSourceCurveTypeListRef : ListVariableRef<UnityEngine.AudioSourceCurveType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AudioSourceCurveType))]
	public sealed partial class AudioSourceCurveTypeListVar : ListVariableVar<UnityEngine.AudioSourceCurveType>
	{
	}
}
