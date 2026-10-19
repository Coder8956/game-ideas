
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.ContactPairHeader))]
	public sealed partial class ContactPairHeaderVariable : Variable<UnityEngine.ContactPairHeader>
	{
		
		public ContactPairHeaderVariable()
		{
		}
		
		public ContactPairHeaderVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ContactPairHeader))]
	public sealed partial class ContactPairHeaderListVariable : ListVariable<UnityEngine.ContactPairHeader>
	{
		
		public ContactPairHeaderListVariable()
		{
		}
		
		public ContactPairHeaderListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ContactPairHeader))]
	public sealed partial class ContactPairHeaderRef : VariableRef<UnityEngine.ContactPairHeader>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ContactPairHeader))]
	public sealed partial class ContactPairHeaderVar : VariableVar<UnityEngine.ContactPairHeader>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ContactPairHeader))]
	public sealed partial class ContactPairHeaderListRef : ListVariableRef<UnityEngine.ContactPairHeader>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ContactPairHeader))]
	public sealed partial class ContactPairHeaderListVar : ListVariableVar<UnityEngine.ContactPairHeader>
	{
	}
}
