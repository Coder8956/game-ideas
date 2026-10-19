
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.RenderMode))]
	public sealed partial class RenderModeVariable : Variable<UnityEngine.RenderMode>
	{
		
		public RenderModeVariable()
		{
		}
		
		public RenderModeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RenderMode))]
	public sealed partial class RenderModeListVariable : ListVariable<UnityEngine.RenderMode>
	{
		
		public RenderModeListVariable()
		{
		}
		
		public RenderModeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RenderMode))]
	public sealed partial class RenderModeRef : VariableRef<UnityEngine.RenderMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RenderMode))]
	public sealed partial class RenderModeVar : VariableVar<UnityEngine.RenderMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RenderMode))]
	public sealed partial class RenderModeListRef : ListVariableRef<UnityEngine.RenderMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RenderMode))]
	public sealed partial class RenderModeListVar : ListVariableVar<UnityEngine.RenderMode>
	{
	}
}
