
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.EffectorSelection2D))]
	public sealed partial class EffectorSelection2DVariable : Variable<UnityEngine.EffectorSelection2D>
	{
		
		public EffectorSelection2DVariable()
		{
		}
		
		public EffectorSelection2DVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.EffectorSelection2D))]
	public sealed partial class EffectorSelection2DListVariable : ListVariable<UnityEngine.EffectorSelection2D>
	{
		
		public EffectorSelection2DListVariable()
		{
		}
		
		public EffectorSelection2DListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.EffectorSelection2D))]
	public sealed partial class EffectorSelection2DRef : VariableRef<UnityEngine.EffectorSelection2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.EffectorSelection2D))]
	public sealed partial class EffectorSelection2DVar : VariableVar<UnityEngine.EffectorSelection2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.EffectorSelection2D))]
	public sealed partial class EffectorSelection2DListRef : ListVariableRef<UnityEngine.EffectorSelection2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.EffectorSelection2D))]
	public sealed partial class EffectorSelection2DListVar : ListVariableVar<UnityEngine.EffectorSelection2D>
	{
	}
}
