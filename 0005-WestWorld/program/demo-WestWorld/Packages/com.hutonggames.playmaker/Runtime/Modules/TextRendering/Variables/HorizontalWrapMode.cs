
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.HorizontalWrapMode))]
	public sealed partial class HorizontalWrapModeVariable : Variable<UnityEngine.HorizontalWrapMode>
	{
		
		public HorizontalWrapModeVariable()
		{
		}
		
		public HorizontalWrapModeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.HorizontalWrapMode))]
	public sealed partial class HorizontalWrapModeListVariable : ListVariable<UnityEngine.HorizontalWrapMode>
	{
		
		public HorizontalWrapModeListVariable()
		{
		}
		
		public HorizontalWrapModeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.HorizontalWrapMode))]
	public sealed partial class HorizontalWrapModeRef : VariableRef<UnityEngine.HorizontalWrapMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.HorizontalWrapMode))]
	public sealed partial class HorizontalWrapModeVar : VariableVar<UnityEngine.HorizontalWrapMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.HorizontalWrapMode))]
	public sealed partial class HorizontalWrapModeListRef : ListVariableRef<UnityEngine.HorizontalWrapMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.HorizontalWrapMode))]
	public sealed partial class HorizontalWrapModeListVar : ListVariableVar<UnityEngine.HorizontalWrapMode>
	{
	}
}
