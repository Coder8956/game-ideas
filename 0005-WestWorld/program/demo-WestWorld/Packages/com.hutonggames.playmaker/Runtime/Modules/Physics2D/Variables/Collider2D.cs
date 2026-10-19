
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Collider2D))]
	public sealed partial class Collider2DVariable : Variable<UnityEngine.Collider2D>
	{
		
		public Collider2DVariable()
		{
		}
		
		public Collider2DVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Collider2D))]
	public sealed partial class Collider2DListVariable : ListVariable<UnityEngine.Collider2D>
	{
		
		public Collider2DListVariable()
		{
		}
		
		public Collider2DListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Collider2D))]
	public sealed partial class Collider2DRef : BaseComponentRef<UnityEngine.Collider2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Collider2D))]
	public sealed partial class Collider2DVar : BaseComponentVar<UnityEngine.Collider2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Collider2D))]
	public sealed partial class Collider2DListRef : ListVariableRef<UnityEngine.Collider2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Collider2D))]
	public sealed partial class Collider2DListVar : ListVariableVar<UnityEngine.Collider2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Collider2D))]
	public sealed partial class Collider2DOverride : VariableOverride<UnityEngine.Collider2D, Collider2DVariable, Collider2DVar>
	{
		
		public Collider2DOverride(IVariable variable) : 
			base(variable)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Collider2D))]
	public sealed partial class Collider2DOutput : VariableOutput<UnityEngine.Collider2D, Collider2DVariable, Collider2DRef>
	{
		
		public Collider2DOutput(IVariable variable) : 
			base(variable)
		{
		}
	}
}
