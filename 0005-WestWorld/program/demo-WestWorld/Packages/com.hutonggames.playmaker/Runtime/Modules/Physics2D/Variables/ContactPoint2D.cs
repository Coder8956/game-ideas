
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.ContactPoint2D))]
	public sealed partial class ContactPoint2DVariable : Variable<UnityEngine.ContactPoint2D>
	{
		
		public ContactPoint2DVariable()
		{
		}
		
		public ContactPoint2DVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ContactPoint2D))]
	public sealed partial class ContactPoint2DListVariable : ListVariable<UnityEngine.ContactPoint2D>
	{
		
		public ContactPoint2DListVariable()
		{
		}
		
		public ContactPoint2DListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ContactPoint2D))]
	public sealed partial class ContactPoint2DRef : VariableRef<UnityEngine.ContactPoint2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ContactPoint2D))]
	public sealed partial class ContactPoint2DVar : VariableVar<UnityEngine.ContactPoint2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ContactPoint2D))]
	public sealed partial class ContactPoint2DListRef : ListVariableRef<UnityEngine.ContactPoint2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ContactPoint2D))]
	public sealed partial class ContactPoint2DListVar : ListVariableVar<UnityEngine.ContactPoint2D>
	{
	}
}
