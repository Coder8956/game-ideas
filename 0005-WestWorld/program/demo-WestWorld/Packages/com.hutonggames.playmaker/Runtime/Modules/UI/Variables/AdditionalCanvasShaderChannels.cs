
using System;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.AdditionalCanvasShaderChannels))]
	public sealed partial class AdditionalCanvasShaderChannelsVariable : Variable<UnityEngine.AdditionalCanvasShaderChannels>
	{
		
		public AdditionalCanvasShaderChannelsVariable()
		{
		}
		
		public AdditionalCanvasShaderChannelsVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AdditionalCanvasShaderChannels))]
	public sealed partial class AdditionalCanvasShaderChannelsListVariable : ListVariable<UnityEngine.AdditionalCanvasShaderChannels>
	{
		
		public AdditionalCanvasShaderChannelsListVariable()
		{
		}
		
		public AdditionalCanvasShaderChannelsListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AdditionalCanvasShaderChannels))]
	public sealed partial class AdditionalCanvasShaderChannelsRef : VariableRef<UnityEngine.AdditionalCanvasShaderChannels>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AdditionalCanvasShaderChannels))]
	public sealed partial class AdditionalCanvasShaderChannelsVar : VariableVar<UnityEngine.AdditionalCanvasShaderChannels>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AdditionalCanvasShaderChannels))]
	public sealed partial class AdditionalCanvasShaderChannelsListRef : ListVariableRef<UnityEngine.AdditionalCanvasShaderChannels>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AdditionalCanvasShaderChannels))]
	public sealed partial class AdditionalCanvasShaderChannelsListVar : ListVariableVar<UnityEngine.AdditionalCanvasShaderChannels>
	{
	}
}
