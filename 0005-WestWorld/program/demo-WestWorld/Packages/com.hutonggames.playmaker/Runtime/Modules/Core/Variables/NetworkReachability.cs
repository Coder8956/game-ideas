
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.NetworkReachability))]
	public sealed partial class NetworkReachabilityVariable : Variable<UnityEngine.NetworkReachability>
	{
		
		public NetworkReachabilityVariable()
		{
		}
		
		public NetworkReachabilityVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.NetworkReachability))]
	public sealed partial class NetworkReachabilityListVariable : ListVariable<UnityEngine.NetworkReachability>
	{
		
		public NetworkReachabilityListVariable()
		{
		}
		
		public NetworkReachabilityListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.NetworkReachability))]
	public sealed partial class NetworkReachabilityRef : VariableRef<UnityEngine.NetworkReachability>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.NetworkReachability))]
	public sealed partial class NetworkReachabilityVar : VariableVar<UnityEngine.NetworkReachability>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.NetworkReachability))]
	public sealed partial class NetworkReachabilityListRef : ListVariableRef<UnityEngine.NetworkReachability>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.NetworkReachability))]
	public sealed partial class NetworkReachabilityListVar : ListVariableVar<UnityEngine.NetworkReachability>
	{
	}
}
