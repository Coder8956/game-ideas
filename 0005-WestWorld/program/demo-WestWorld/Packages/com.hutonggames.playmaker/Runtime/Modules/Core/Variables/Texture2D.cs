
using System;
using UnityEngine;


namespace HutongGames.PlayMaker
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Texture2D))]
	public sealed partial class Texture2DVariable : Variable<Texture2D>
	{
		
		public Texture2DVariable()
		{
		}
		
		public Texture2DVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Texture2D))]
	public sealed partial class Texture2DListVariable : ListVariable<Texture2D>
	{
		
		public Texture2DListVariable()
		{
		}
		
		public Texture2DListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Texture2D))]
	public sealed partial class Texture2DRef : VariableRef<Texture2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Texture2D))]
	public sealed partial class Texture2DVar : VariableVar<Texture2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Texture2D))]
	public sealed partial class Texture2DListRef : ListVariableRef<Texture2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Texture2D))]
	public sealed partial class Texture2DListVar : ListVariableVar<Texture2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Texture2D))]
	public sealed partial class Texture2DOverride : VariableOverride<Texture2D,Texture2DVariable,Texture2DVar>
	{
		
		public Texture2DOverride(IVariable variable) : 
				base(variable)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Texture2D))]
	public sealed partial class Texture2DOutput : VariableOutput<Texture2D,Texture2DVariable,Texture2DRef>
	{
		
		public Texture2DOutput(IVariable variable) : 
				base(variable)
		{
		}
	}
}
