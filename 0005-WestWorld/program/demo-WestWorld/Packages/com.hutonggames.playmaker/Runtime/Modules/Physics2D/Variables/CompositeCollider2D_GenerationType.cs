
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.CompositeCollider2D.GenerationType))]
	public sealed partial class CompositeCollider2D_GenerationTypeVariable : Variable<UnityEngine.CompositeCollider2D.GenerationType>
	{
		
		public CompositeCollider2D_GenerationTypeVariable()
		{
		}
		
		public CompositeCollider2D_GenerationTypeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CompositeCollider2D.GenerationType))]
	public sealed partial class CompositeCollider2D_GenerationTypeListVariable : ListVariable<UnityEngine.CompositeCollider2D.GenerationType>
	{
		
		public CompositeCollider2D_GenerationTypeListVariable()
		{
		}
		
		public CompositeCollider2D_GenerationTypeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CompositeCollider2D.GenerationType))]
	public sealed partial class CompositeCollider2D_GenerationTypeRef : VariableRef<UnityEngine.CompositeCollider2D.GenerationType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CompositeCollider2D.GenerationType))]
	public sealed partial class CompositeCollider2D_GenerationTypeVar : VariableVar<UnityEngine.CompositeCollider2D.GenerationType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CompositeCollider2D.GenerationType))]
	public sealed partial class CompositeCollider2D_GenerationTypeListRef : ListVariableRef<UnityEngine.CompositeCollider2D.GenerationType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CompositeCollider2D.GenerationType))]
	public sealed partial class CompositeCollider2D_GenerationTypeListVar : ListVariableVar<UnityEngine.CompositeCollider2D.GenerationType>
	{
	}
}
