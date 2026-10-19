
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.ContactFilter2D))]
	public sealed partial class ContactFilter2DVariable : Variable<UnityEngine.ContactFilter2D>
	{
		
		public ContactFilter2DVariable()
		{
		}
		
		public ContactFilter2DVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ContactFilter2D))]
	public sealed partial class ContactFilter2DListVariable : ListVariable<UnityEngine.ContactFilter2D>
	{
		
		public ContactFilter2DListVariable()
		{
		}
		
		public ContactFilter2DListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ContactFilter2D))]
	public sealed partial class ContactFilter2DRef : VariableRef<UnityEngine.ContactFilter2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ContactFilter2D))]
	public sealed partial class ContactFilter2DVar : VariableVar<UnityEngine.ContactFilter2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ContactFilter2D))]
	public sealed partial class ContactFilter2DListRef : ListVariableRef<UnityEngine.ContactFilter2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ContactFilter2D))]
	public sealed partial class ContactFilter2DListVar : ListVariableVar<UnityEngine.ContactFilter2D>
	{
	}
}
