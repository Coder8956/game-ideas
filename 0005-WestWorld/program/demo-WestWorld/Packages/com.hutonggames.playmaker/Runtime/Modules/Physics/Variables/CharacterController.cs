
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.CharacterController))]
	public sealed partial class CharacterControllerVariable : Variable<UnityEngine.CharacterController>
	{
		
		public CharacterControllerVariable()
		{
		}
		
		public CharacterControllerVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CharacterController))]
	public sealed partial class CharacterControllerListVariable : ListVariable<UnityEngine.CharacterController>
	{
		
		public CharacterControllerListVariable()
		{
		}
		
		public CharacterControllerListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CharacterController))]
	public sealed partial class CharacterControllerRef : BaseComponentRef<UnityEngine.CharacterController>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CharacterController))]
	public sealed partial class CharacterControllerVar : BaseComponentVar<UnityEngine.CharacterController>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CharacterController))]
	public sealed partial class CharacterControllerListRef : ListVariableRef<UnityEngine.CharacterController>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.CharacterController))]
	public sealed partial class CharacterControllerListVar : ListVariableVar<UnityEngine.CharacterController>
	{
	}
}
