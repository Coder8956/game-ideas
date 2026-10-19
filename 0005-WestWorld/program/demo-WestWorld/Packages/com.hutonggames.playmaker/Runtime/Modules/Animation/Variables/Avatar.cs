
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.Avatar))]
	public sealed partial class AvatarVariable : Variable<UnityEngine.Avatar>
	{
		
		public AvatarVariable()
		{
		}
		
		public AvatarVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Avatar))]
	public sealed partial class AvatarListVariable : ListVariable<UnityEngine.Avatar>
	{
		
		public AvatarListVariable()
		{
		}
		
		public AvatarListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Avatar))]
	public sealed partial class AvatarRef : VariableRef<UnityEngine.Avatar>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Avatar))]
	public sealed partial class AvatarVar : VariableVar<UnityEngine.Avatar>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Avatar))]
	public sealed partial class AvatarListRef : ListVariableRef<UnityEngine.Avatar>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.Avatar))]
	public sealed partial class AvatarListVar : ListVariableVar<UnityEngine.Avatar>
	{
	}
}
