
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.ContactPoint))]
	public sealed partial class ContactPointVariable : Variable<UnityEngine.ContactPoint>
	{
		
		public ContactPointVariable()
		{
		}
		
		public ContactPointVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ContactPoint))]
	public sealed partial class ContactPointListVariable : ListVariable<UnityEngine.ContactPoint>
	{
		
		public ContactPointListVariable()
		{
		}
		
		public ContactPointListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ContactPoint))]
	public sealed partial class ContactPointRef : VariableRef<UnityEngine.ContactPoint>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ContactPoint))]
	public sealed partial class ContactPointVar : VariableVar<UnityEngine.ContactPoint>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ContactPoint))]
	public sealed partial class ContactPointListRef : ListVariableRef<UnityEngine.ContactPoint>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ContactPoint))]
	public sealed partial class ContactPointListVar : ListVariableVar<UnityEngine.ContactPoint>
	{
	}
}
