
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.AnimatorUpdateMode))]
	public sealed partial class AnimatorUpdateModeVariable : Variable<UnityEngine.AnimatorUpdateMode>
	{
		
		public AnimatorUpdateModeVariable()
		{
		}
		
		public AnimatorUpdateModeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AnimatorUpdateMode))]
	public sealed partial class AnimatorUpdateModeListVariable : ListVariable<UnityEngine.AnimatorUpdateMode>
	{
		
		public AnimatorUpdateModeListVariable()
		{
		}
		
		public AnimatorUpdateModeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AnimatorUpdateMode))]
	public sealed partial class AnimatorUpdateModeRef : VariableRef<UnityEngine.AnimatorUpdateMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AnimatorUpdateMode))]
	public sealed partial class AnimatorUpdateModeVar : VariableVar<UnityEngine.AnimatorUpdateMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AnimatorUpdateMode))]
	public sealed partial class AnimatorUpdateModeListRef : ListVariableRef<UnityEngine.AnimatorUpdateMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AnimatorUpdateMode))]
	public sealed partial class AnimatorUpdateModeListVar : ListVariableVar<UnityEngine.AnimatorUpdateMode>
	{
	}
}
