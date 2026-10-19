
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.DepthTextureMode))]
	public sealed partial class DepthTextureModeVariable : Variable<UnityEngine.DepthTextureMode>
	{
		
		public DepthTextureModeVariable()
		{
		}
		
		public DepthTextureModeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.DepthTextureMode))]
	public sealed partial class DepthTextureModeListVariable : ListVariable<UnityEngine.DepthTextureMode>
	{
		
		public DepthTextureModeListVariable()
		{
		}
		
		public DepthTextureModeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.DepthTextureMode))]
	public sealed partial class DepthTextureModeRef : VariableRef<UnityEngine.DepthTextureMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.DepthTextureMode))]
	public sealed partial class DepthTextureModeVar : VariableVar<UnityEngine.DepthTextureMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.DepthTextureMode))]
	public sealed partial class DepthTextureModeListRef : ListVariableRef<UnityEngine.DepthTextureMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.DepthTextureMode))]
	public sealed partial class DepthTextureModeListVar : ListVariableVar<UnityEngine.DepthTextureMode>
	{
	}
}
