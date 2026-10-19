namespace HutongGames.PlayMaker
{
	
	[global::System.SerializableAttribute()]
	[DataType(typeof(UnityEngine.RenderTexture))]
	public sealed partial class RenderTextureVariable : HutongGames.PlayMaker.Variable<UnityEngine.RenderTexture>
	{
		
		public RenderTextureVariable() : 
				base()
		{
		}
		
		public RenderTextureVariable(string name) : 
				base(name)
		{
		}
	}
	
	[global::System.SerializableAttribute()]
	[DataType(typeof(UnityEngine.RenderTexture))]
	public sealed partial class RenderTextureListVariable : HutongGames.PlayMaker.ListVariable<UnityEngine.RenderTexture>
	{
		
		public RenderTextureListVariable() : 
				base()
		{
		}
		
		public RenderTextureListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[global::System.SerializableAttribute()]
	[DataType(typeof(UnityEngine.RenderTexture))]
	public sealed partial class RenderTextureRef : HutongGames.PlayMaker.VariableRef<UnityEngine.RenderTexture>
	{
	}
	
	[global::System.SerializableAttribute()]
	[DataType(typeof(UnityEngine.RenderTexture))]
	public sealed partial class RenderTextureVar : HutongGames.PlayMaker.VariableVar<UnityEngine.RenderTexture>
	{
	}
	
	[global::System.SerializableAttribute()]
	[DataType(typeof(UnityEngine.RenderTexture))]
	public sealed partial class RenderTextureListRef : HutongGames.PlayMaker.ListVariableRef<UnityEngine.RenderTexture>
	{
	}
	
	[global::System.SerializableAttribute()]
	[DataType(typeof(UnityEngine.RenderTexture))]
	public sealed partial class RenderTextureListVar : HutongGames.PlayMaker.ListVariableVar<UnityEngine.RenderTexture>
	{
	}
	
	[global::System.SerializableAttribute()]
	[DataType(typeof(UnityEngine.RenderTexture))]
	public sealed class RenderTextureOverride : HutongGames.PlayMaker.VariableOverride<UnityEngine.RenderTexture, HutongGames.PlayMaker.RenderTextureVariable, HutongGames.PlayMaker.RenderTextureVar>
	{
		
		public RenderTextureOverride(IVariable variable) : 
				base(variable)
		{
		}
	}
	
	[global::System.SerializableAttribute()]
	[DataType(typeof(UnityEngine.RenderTexture))]
	public sealed class RenderTextureOutput : HutongGames.PlayMaker.VariableOutput<UnityEngine.RenderTexture, HutongGames.PlayMaker.RenderTextureVariable, HutongGames.PlayMaker.RenderTextureRef>
	{
		
		public RenderTextureOutput(IVariable variable) : 
				base(variable)
		{
		}
	}

	[global::System.SerializableAttribute()]
	[DataType(typeof(UnityEngine.RenderTexture))]
	public sealed class RenderTextureListOverride : HutongGames.PlayMaker.VariableOverride<System.Collections.Generic.List<UnityEngine.RenderTexture>, HutongGames.PlayMaker.RenderTextureListVariable, HutongGames.PlayMaker.RenderTextureListVar>
	{
		public RenderTextureListOverride(IVariable variable) :
				base(variable)
		{
		}
	}

	[global::System.SerializableAttribute()]
	[DataType(typeof(UnityEngine.RenderTexture))]
	public sealed class RenderTextureListOutput : HutongGames.PlayMaker.VariableOutput<System.Collections.Generic.List<UnityEngine.RenderTexture>, HutongGames.PlayMaker.RenderTextureListVariable, HutongGames.PlayMaker.RenderTextureListRef>
	{
		public RenderTextureListOutput(IVariable variable) :
				base(variable)
		{
		}
	}
	
}
