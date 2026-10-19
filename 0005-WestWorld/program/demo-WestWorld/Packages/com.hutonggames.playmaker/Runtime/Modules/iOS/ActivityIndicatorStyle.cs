
using System;


namespace HutongGames.PlayMaker.Actions.iOS
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.iOS.ActivityIndicatorStyle))]
	public sealed partial class ActivityIndicatorStyleVariable : Variable<UnityEngine.iOS.ActivityIndicatorStyle>
	{
		
		public ActivityIndicatorStyleVariable()
		{
		}
		
		public ActivityIndicatorStyleVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.iOS.ActivityIndicatorStyle))]
	public sealed partial class ActivityIndicatorStyleListVariable : ListVariable<UnityEngine.iOS.ActivityIndicatorStyle>
	{
		
		public ActivityIndicatorStyleListVariable()
		{
		}
		
		public ActivityIndicatorStyleListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.iOS.ActivityIndicatorStyle))]
	public sealed partial class ActivityIndicatorStyleRef : VariableRef<UnityEngine.iOS.ActivityIndicatorStyle>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.iOS.ActivityIndicatorStyle))]
	public sealed partial class ActivityIndicatorStyleVar : VariableVar<UnityEngine.iOS.ActivityIndicatorStyle>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.iOS.ActivityIndicatorStyle))]
	public sealed partial class ActivityIndicatorStyleListRef : ListVariableRef<UnityEngine.iOS.ActivityIndicatorStyle>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.iOS.ActivityIndicatorStyle))]
	public sealed partial class ActivityIndicatorStyleListVar : ListVariableVar<UnityEngine.iOS.ActivityIndicatorStyle>
	{
	}
}
