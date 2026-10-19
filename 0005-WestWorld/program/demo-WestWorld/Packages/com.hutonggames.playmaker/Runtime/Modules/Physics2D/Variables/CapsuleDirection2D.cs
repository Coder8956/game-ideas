
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.CapsuleDirection2D))]
	public sealed partial class CapsuleDirection2DVariable : Variable<UnityEngine.CapsuleDirection2D>
	{
		
		public CapsuleDirection2DVariable()
		{
		}
		
		public CapsuleDirection2DVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CapsuleDirection2D))]
	public sealed partial class CapsuleDirection2DListVariable : ListVariable<UnityEngine.CapsuleDirection2D>
	{
		
		public CapsuleDirection2DListVariable()
		{
		}
		
		public CapsuleDirection2DListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CapsuleDirection2D))]
	public sealed partial class CapsuleDirection2DRef : VariableRef<UnityEngine.CapsuleDirection2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CapsuleDirection2D))]
	public sealed partial class CapsuleDirection2DVar : VariableVar<UnityEngine.CapsuleDirection2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CapsuleDirection2D))]
	public sealed partial class CapsuleDirection2DListRef : ListVariableRef<UnityEngine.CapsuleDirection2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CapsuleDirection2D))]
	public sealed partial class CapsuleDirection2DListVar : ListVariableVar<UnityEngine.CapsuleDirection2D>
	{
	}
}
