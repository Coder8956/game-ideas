
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Space))]
	public sealed partial class SpaceVariable : Variable<UnityEngine.Space>
	{
		
		public SpaceVariable()
		{
		}
		
		public SpaceVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Space))]
	public sealed partial class SpaceListVariable : ListVariable<UnityEngine.Space>
	{
		
		public SpaceListVariable()
		{
		}
		
		public SpaceListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Space))]
	public sealed partial class SpaceRef : VariableRef<UnityEngine.Space>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Space))]
	public sealed partial class SpaceVar : VariableVar<UnityEngine.Space>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Space))]
	public sealed partial class SpaceListRef : ListVariableRef<UnityEngine.Space>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Space))]
	public sealed partial class SpaceListVar : ListVariableVar<UnityEngine.Space>
	{
	}
}
