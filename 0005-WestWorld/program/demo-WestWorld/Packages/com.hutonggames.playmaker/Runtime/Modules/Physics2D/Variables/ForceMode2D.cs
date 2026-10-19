
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.ForceMode2D))]
	public sealed partial class ForceMode2DVariable : Variable<UnityEngine.ForceMode2D>
	{
		
		public ForceMode2DVariable()
		{
		}
		
		public ForceMode2DVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ForceMode2D))]
	public sealed partial class ForceMode2DListVariable : ListVariable<UnityEngine.ForceMode2D>
	{
		
		public ForceMode2DListVariable()
		{
		}
		
		public ForceMode2DListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ForceMode2D))]
	public sealed partial class ForceMode2DRef : VariableRef<UnityEngine.ForceMode2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ForceMode2D))]
	public sealed partial class ForceMode2DVar : VariableVar<UnityEngine.ForceMode2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ForceMode2D))]
	public sealed partial class ForceMode2DListRef : ListVariableRef<UnityEngine.ForceMode2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ForceMode2D))]
	public sealed partial class ForceMode2DListVar : ListVariableVar<UnityEngine.ForceMode2D>
	{
	}
}
