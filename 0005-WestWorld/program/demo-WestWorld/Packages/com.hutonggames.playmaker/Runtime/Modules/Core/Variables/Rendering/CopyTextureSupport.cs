
using System;


namespace HutongGames.PlayMaker.Actions.Rendering
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.CopyTextureSupport))]
	public sealed partial class CopyTextureSupportVariable : Variable<UnityEngine.Rendering.CopyTextureSupport>
	{
		
		public CopyTextureSupportVariable()
		{
		}
		
		public CopyTextureSupportVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.CopyTextureSupport))]
	public sealed partial class CopyTextureSupportListVariable : ListVariable<UnityEngine.Rendering.CopyTextureSupport>
	{
		
		public CopyTextureSupportListVariable()
		{
		}
		
		public CopyTextureSupportListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.CopyTextureSupport))]
	public sealed partial class CopyTextureSupportRef : VariableRef<UnityEngine.Rendering.CopyTextureSupport>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.CopyTextureSupport))]
	public sealed partial class CopyTextureSupportVar : VariableVar<UnityEngine.Rendering.CopyTextureSupport>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.CopyTextureSupport))]
	public sealed partial class CopyTextureSupportListRef : ListVariableRef<UnityEngine.Rendering.CopyTextureSupport>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Rendering.CopyTextureSupport))]
	public sealed partial class CopyTextureSupportListVar : ListVariableVar<UnityEngine.Rendering.CopyTextureSupport>
	{
	}
}
