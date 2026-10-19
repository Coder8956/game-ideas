
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.AnimatorControllerParameter))]
	public sealed partial class AnimatorControllerParameterVariable : Variable<UnityEngine.AnimatorControllerParameter>
	{
		
		public AnimatorControllerParameterVariable()
		{
		}
		
		public AnimatorControllerParameterVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AnimatorControllerParameter))]
	public sealed partial class AnimatorControllerParameterListVariable : ListVariable<UnityEngine.AnimatorControllerParameter>
	{
		
		public AnimatorControllerParameterListVariable()
		{
		}
		
		public AnimatorControllerParameterListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AnimatorControllerParameter))]
	public sealed partial class AnimatorControllerParameterRef : VariableRef<UnityEngine.AnimatorControllerParameter>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AnimatorControllerParameter))]
	public sealed partial class AnimatorControllerParameterVar : VariableVar<UnityEngine.AnimatorControllerParameter>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AnimatorControllerParameter))]
	public sealed partial class AnimatorControllerParameterListRef : ListVariableRef<UnityEngine.AnimatorControllerParameter>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AnimatorControllerParameter))]
	public sealed partial class AnimatorControllerParameterListVar : ListVariableVar<UnityEngine.AnimatorControllerParameter>
	{
	}
}
