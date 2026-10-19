
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.ContactPairPoint))]
	public sealed partial class ContactPairPointVariable : Variable<UnityEngine.ContactPairPoint>
	{
		
		public ContactPairPointVariable()
		{
		}
		
		public ContactPairPointVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ContactPairPoint))]
	public sealed partial class ContactPairPointListVariable : ListVariable<UnityEngine.ContactPairPoint>
	{
		
		public ContactPairPointListVariable()
		{
		}
		
		public ContactPairPointListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ContactPairPoint))]
	public sealed partial class ContactPairPointRef : VariableRef<UnityEngine.ContactPairPoint>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ContactPairPoint))]
	public sealed partial class ContactPairPointVar : VariableVar<UnityEngine.ContactPairPoint>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ContactPairPoint))]
	public sealed partial class ContactPairPointListRef : ListVariableRef<UnityEngine.ContactPairPoint>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ContactPairPoint))]
	public sealed partial class ContactPairPointListVar : ListVariableVar<UnityEngine.ContactPairPoint>
	{
	}
}
