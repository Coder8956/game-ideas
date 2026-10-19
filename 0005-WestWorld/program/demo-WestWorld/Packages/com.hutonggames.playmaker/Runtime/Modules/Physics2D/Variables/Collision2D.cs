
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Collision2D))]
	public sealed partial class Collision2DVariable : Variable<UnityEngine.Collision2D>
	{
		
		public Collision2DVariable()
		{
		}
		
		public Collision2DVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Collision2D))]
	public sealed partial class Collision2DListVariable : ListVariable<UnityEngine.Collision2D>
	{
		
		public Collision2DListVariable()
		{
		}
		
		public Collision2DListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Collision2D))]
	public sealed partial class Collision2DRef : VariableRef<UnityEngine.Collision2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Collision2D))]
	public sealed partial class Collision2DVar : VariableVar<UnityEngine.Collision2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Collision2D))]
	public sealed partial class Collision2DListRef : ListVariableRef<UnityEngine.Collision2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Collision2D))]
	public sealed partial class Collision2DListVar : ListVariableVar<UnityEngine.Collision2D>
	{
	}
}
