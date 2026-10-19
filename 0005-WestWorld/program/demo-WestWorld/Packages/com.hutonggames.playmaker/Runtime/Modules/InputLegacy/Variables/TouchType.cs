
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.TouchType))]
	public sealed partial class TouchTypeVariable : Variable<UnityEngine.TouchType>
	{
		
		public TouchTypeVariable()
		{
		}
		
		public TouchTypeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.TouchType))]
	public sealed partial class TouchTypeListVariable : ListVariable<UnityEngine.TouchType>
	{
		
		public TouchTypeListVariable()
		{
		}
		
		public TouchTypeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.TouchType))]
	public sealed partial class TouchTypeRef : VariableRef<UnityEngine.TouchType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.TouchType))]
	public sealed partial class TouchTypeVar : VariableVar<UnityEngine.TouchType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.TouchType))]
	public sealed partial class TouchTypeListRef : ListVariableRef<UnityEngine.TouchType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.TouchType))]
	public sealed partial class TouchTypeListVar : ListVariableVar<UnityEngine.TouchType>
	{
	}
}
