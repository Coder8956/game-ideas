
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.AnimatorClipInfo))]
	public sealed partial class AnimatorClipInfoVariable : Variable<UnityEngine.AnimatorClipInfo>
	{
		
		public AnimatorClipInfoVariable()
		{
		}
		
		public AnimatorClipInfoVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AnimatorClipInfo))]
	public sealed partial class AnimatorClipInfoListVariable : ListVariable<UnityEngine.AnimatorClipInfo>
	{
		
		public AnimatorClipInfoListVariable()
		{
		}
		
		public AnimatorClipInfoListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AnimatorClipInfo))]
	public sealed partial class AnimatorClipInfoRef : VariableRef<UnityEngine.AnimatorClipInfo>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AnimatorClipInfo))]
	public sealed partial class AnimatorClipInfoVar : VariableVar<UnityEngine.AnimatorClipInfo>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AnimatorClipInfo))]
	public sealed partial class AnimatorClipInfoListRef : ListVariableRef<UnityEngine.AnimatorClipInfo>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AnimatorClipInfo))]
	public sealed partial class AnimatorClipInfoListVar : ListVariableVar<UnityEngine.AnimatorClipInfo>
	{
	}
}
