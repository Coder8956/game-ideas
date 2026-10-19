
using System;
using UnityEngine;


namespace HutongGames.PlayMaker
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.WrapMode))]
	public sealed partial class WrapModeVariable : Variable<WrapMode>
	{
		
		public WrapModeVariable()
		{
		}
		
		public WrapModeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.WrapMode))]
	public sealed partial class WrapModeListVariable : ListVariable<WrapMode>
	{
		
		public WrapModeListVariable()
		{
		}
		
		public WrapModeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.WrapMode))]
	public sealed partial class WrapModeRef : VariableRef<WrapMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.WrapMode))]
	public sealed partial class WrapModeVar : VariableVar<WrapMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.WrapMode))]
	public sealed partial class WrapModeListRef : ListVariableRef<WrapMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.WrapMode))]
	public sealed partial class WrapModeListVar : ListVariableVar<WrapMode>
	{
	}
}
