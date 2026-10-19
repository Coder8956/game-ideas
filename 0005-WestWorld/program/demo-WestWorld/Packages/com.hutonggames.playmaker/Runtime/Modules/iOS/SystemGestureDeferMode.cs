
using System;


namespace HutongGames.PlayMaker.Actions.iOS
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.iOS.SystemGestureDeferMode))]
	public sealed partial class SystemGestureDeferModeVariable : Variable<UnityEngine.iOS.SystemGestureDeferMode>
	{
		
		public SystemGestureDeferModeVariable()
		{
		}
		
		public SystemGestureDeferModeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.iOS.SystemGestureDeferMode))]
	public sealed partial class SystemGestureDeferModeListVariable : ListVariable<UnityEngine.iOS.SystemGestureDeferMode>
	{
		
		public SystemGestureDeferModeListVariable()
		{
		}
		
		public SystemGestureDeferModeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.iOS.SystemGestureDeferMode))]
	public sealed partial class SystemGestureDeferModeRef : VariableRef<UnityEngine.iOS.SystemGestureDeferMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.iOS.SystemGestureDeferMode))]
	public sealed partial class SystemGestureDeferModeVar : VariableVar<UnityEngine.iOS.SystemGestureDeferMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.iOS.SystemGestureDeferMode))]
	public sealed partial class SystemGestureDeferModeListRef : ListVariableRef<UnityEngine.iOS.SystemGestureDeferMode>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.iOS.SystemGestureDeferMode))]
	public sealed partial class SystemGestureDeferModeListVar : ListVariableVar<UnityEngine.iOS.SystemGestureDeferMode>
	{
	}
}
