
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.CompositeCollider2D.GeometryType))]
	public sealed partial class CompositeCollider2D_GeometryTypeVariable : Variable<UnityEngine.CompositeCollider2D.GeometryType>
	{
		
		public CompositeCollider2D_GeometryTypeVariable()
		{
		}
		
		public CompositeCollider2D_GeometryTypeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CompositeCollider2D.GeometryType))]
	public sealed partial class CompositeCollider2D_GeometryTypeListVariable : ListVariable<UnityEngine.CompositeCollider2D.GeometryType>
	{
		
		public CompositeCollider2D_GeometryTypeListVariable()
		{
		}
		
		public CompositeCollider2D_GeometryTypeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CompositeCollider2D.GeometryType))]
	public sealed partial class CompositeCollider2D_GeometryTypeRef : VariableRef<UnityEngine.CompositeCollider2D.GeometryType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CompositeCollider2D.GeometryType))]
	public sealed partial class CompositeCollider2D_GeometryTypeVar : VariableVar<UnityEngine.CompositeCollider2D.GeometryType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CompositeCollider2D.GeometryType))]
	public sealed partial class CompositeCollider2D_GeometryTypeListRef : ListVariableRef<UnityEngine.CompositeCollider2D.GeometryType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CompositeCollider2D.GeometryType))]
	public sealed partial class CompositeCollider2D_GeometryTypeListVar : ListVariableVar<UnityEngine.CompositeCollider2D.GeometryType>
	{
	}
}
