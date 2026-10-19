
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.ModifiableContactPair))]
	public sealed partial class ModifiableContactPairVariable : Variable<UnityEngine.ModifiableContactPair>
	{
		
		public ModifiableContactPairVariable()
		{
		}
		
		public ModifiableContactPairVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ModifiableContactPair))]
	public sealed partial class ModifiableContactPairListVariable : ListVariable<UnityEngine.ModifiableContactPair>
	{
		
		public ModifiableContactPairListVariable()
		{
		}
		
		public ModifiableContactPairListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ModifiableContactPair))]
	public sealed partial class ModifiableContactPairRef : VariableRef<UnityEngine.ModifiableContactPair>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ModifiableContactPair))]
	public sealed partial class ModifiableContactPairVar : VariableVar<UnityEngine.ModifiableContactPair>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ModifiableContactPair))]
	public sealed partial class ModifiableContactPairListRef : ListVariableRef<UnityEngine.ModifiableContactPair>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ModifiableContactPair))]
	public sealed partial class ModifiableContactPairListVar : ListVariableVar<UnityEngine.ModifiableContactPair>
	{
	}
}
