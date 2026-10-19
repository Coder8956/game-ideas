namespace HutongGames.PlayMaker
{
	
	[global::System.SerializableAttribute()]
	[DataType(typeof(UnityEngine.Texture))]
	public sealed partial class TextureVariable : HutongGames.PlayMaker.Variable<UnityEngine.Texture>
	{
		
		public TextureVariable() : 
				base()
		{
		}
		
		public TextureVariable(string name) : 
				base(name)
		{
		}
	}
	
	[global::System.SerializableAttribute()]
	[DataType(typeof(UnityEngine.Texture))]
	public sealed partial class TextureListVariable : HutongGames.PlayMaker.ListVariable<UnityEngine.Texture>
	{
		
		public TextureListVariable() : 
				base()
		{
		}
		
		public TextureListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[global::System.SerializableAttribute()]
	[DataType(typeof(UnityEngine.Texture))]
	public sealed partial class TextureRef : HutongGames.PlayMaker.VariableRef<UnityEngine.Texture>
	{
	}
	
	[global::System.SerializableAttribute()]
	[DataType(typeof(UnityEngine.Texture))]
	public sealed partial class TextureVar : HutongGames.PlayMaker.VariableVar<UnityEngine.Texture>
	{
	}
	
	[global::System.SerializableAttribute()]
	[DataType(typeof(UnityEngine.Texture))]
	public sealed partial class TextureListRef : HutongGames.PlayMaker.ListVariableRef<UnityEngine.Texture>
	{
	}
	
	[global::System.SerializableAttribute()]
	[DataType(typeof(UnityEngine.Texture))]
	public sealed partial class TextureListVar : HutongGames.PlayMaker.ListVariableVar<UnityEngine.Texture>
	{
	}
	
	[global::System.SerializableAttribute()]
	[DataType(typeof(UnityEngine.Texture))]
	public sealed class TextureOverride : HutongGames.PlayMaker.VariableOverride<UnityEngine.Texture, HutongGames.PlayMaker.TextureVariable, HutongGames.PlayMaker.TextureVar>
	{
		
		public TextureOverride(IVariable variable) : 
				base(variable)
		{
		}
	}
	
	[global::System.SerializableAttribute()]
	[DataType(typeof(UnityEngine.Texture))]
	public sealed class TextureOutput : HutongGames.PlayMaker.VariableOutput<UnityEngine.Texture, HutongGames.PlayMaker.TextureVariable, HutongGames.PlayMaker.TextureRef>
	{
		
		public TextureOutput(IVariable variable) : 
				base(variable)
		{
		}
	}

	[global::System.SerializableAttribute()]
	[DataType(typeof(UnityEngine.Texture))]
	public sealed class TextureListOverride : HutongGames.PlayMaker.VariableOverride<System.Collections.Generic.List<UnityEngine.Texture>, HutongGames.PlayMaker.TextureListVariable, HutongGames.PlayMaker.TextureListVar>
	{
		public TextureListOverride(IVariable variable) :
				base(variable)
		{
		}
	}

	[global::System.SerializableAttribute()]
	[DataType(typeof(UnityEngine.Texture))]
	public sealed class TextureListOutput : HutongGames.PlayMaker.VariableOutput<System.Collections.Generic.List<UnityEngine.Texture>, HutongGames.PlayMaker.TextureListVariable, HutongGames.PlayMaker.TextureListRef>
	{
		public TextureListOutput(IVariable variable) :
				base(variable)
		{
		}
	}
}
