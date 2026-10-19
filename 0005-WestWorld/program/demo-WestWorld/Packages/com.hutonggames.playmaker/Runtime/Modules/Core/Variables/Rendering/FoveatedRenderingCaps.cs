
using System;


namespace HutongGames.PlayMaker.Actions.Rendering
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.FoveatedRenderingCaps))]
	public sealed partial class FoveatedRenderingCapsVariable : Variable<UnityEngine.Rendering.FoveatedRenderingCaps>
	{
		
		public FoveatedRenderingCapsVariable()
		{
		}
		
		public FoveatedRenderingCapsVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.FoveatedRenderingCaps))]
	public sealed partial class FoveatedRenderingCapsListVariable : ListVariable<UnityEngine.Rendering.FoveatedRenderingCaps>
	{
		
		public FoveatedRenderingCapsListVariable()
		{
		}
		
		public FoveatedRenderingCapsListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.FoveatedRenderingCaps))]
	public sealed partial class FoveatedRenderingCapsRef : VariableRef<UnityEngine.Rendering.FoveatedRenderingCaps>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.FoveatedRenderingCaps))]
	public sealed partial class FoveatedRenderingCapsVar : VariableVar<UnityEngine.Rendering.FoveatedRenderingCaps>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.FoveatedRenderingCaps))]
	public sealed partial class FoveatedRenderingCapsListRef : ListVariableRef<UnityEngine.Rendering.FoveatedRenderingCaps>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.FoveatedRenderingCaps))]
	public sealed partial class FoveatedRenderingCapsListVar : ListVariableVar<UnityEngine.Rendering.FoveatedRenderingCaps>
	{
	}
}
