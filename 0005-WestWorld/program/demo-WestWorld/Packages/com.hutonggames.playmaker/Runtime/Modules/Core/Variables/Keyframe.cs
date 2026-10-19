
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Keyframe))]
	public sealed partial class KeyframeVariable : Variable<UnityEngine.Keyframe>
	{
		
		public KeyframeVariable()
		{
		}
		
		public KeyframeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Keyframe))]
	public sealed partial class KeyframeListVariable : ListVariable<UnityEngine.Keyframe>
	{
		
		public KeyframeListVariable()
		{
		}
		
		public KeyframeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Keyframe))]
	public sealed partial class KeyframeRef : VariableRef<UnityEngine.Keyframe>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Keyframe))]
	public sealed partial class KeyframeVar : VariableVar<UnityEngine.Keyframe>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Keyframe))]
	public sealed partial class KeyframeListRef : ListVariableRef<UnityEngine.Keyframe>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Keyframe))]
	public sealed partial class KeyframeListVar : ListVariableVar<UnityEngine.Keyframe>
	{
	}
}
