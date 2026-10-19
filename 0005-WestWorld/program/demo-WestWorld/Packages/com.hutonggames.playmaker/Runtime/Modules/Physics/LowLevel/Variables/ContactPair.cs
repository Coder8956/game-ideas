
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.ContactPair))]
	public sealed partial class ContactPairVariable : Variable<UnityEngine.ContactPair>
	{
		
		public ContactPairVariable()
		{
		}
		
		public ContactPairVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ContactPair))]
	public sealed partial class ContactPairListVariable : ListVariable<UnityEngine.ContactPair>
	{
		
		public ContactPairListVariable()
		{
		}
		
		public ContactPairListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ContactPair))]
	public sealed partial class ContactPairRef : VariableRef<UnityEngine.ContactPair>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ContactPair))]
	public sealed partial class ContactPairVar : VariableVar<UnityEngine.ContactPair>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ContactPair))]
	public sealed partial class ContactPairListRef : ListVariableRef<UnityEngine.ContactPair>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ContactPair))]
	public sealed partial class ContactPairListVar : ListVariableVar<UnityEngine.ContactPair>
	{
	}
}
