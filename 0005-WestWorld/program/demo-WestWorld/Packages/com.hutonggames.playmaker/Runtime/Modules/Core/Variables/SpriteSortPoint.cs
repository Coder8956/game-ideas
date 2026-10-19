
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.SpriteSortPoint))]
	public sealed partial class SpriteSortPointVariable : Variable<UnityEngine.SpriteSortPoint>
	{
		
		public SpriteSortPointVariable()
		{
		}
		
		public SpriteSortPointVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SpriteSortPoint))]
	public sealed partial class SpriteSortPointListVariable : ListVariable<UnityEngine.SpriteSortPoint>
	{
		
		public SpriteSortPointListVariable()
		{
		}
		
		public SpriteSortPointListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SpriteSortPoint))]
	public sealed partial class SpriteSortPointRef : VariableRef<UnityEngine.SpriteSortPoint>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SpriteSortPoint))]
	public sealed partial class SpriteSortPointVar : VariableVar<UnityEngine.SpriteSortPoint>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SpriteSortPoint))]
	public sealed partial class SpriteSortPointListRef : ListVariableRef<UnityEngine.SpriteSortPoint>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SpriteSortPoint))]
	public sealed partial class SpriteSortPointListVar : ListVariableVar<UnityEngine.SpriteSortPoint>
	{
	}
}
