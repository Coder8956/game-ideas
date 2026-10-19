
using System;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.AnimationTriggers))]
	public sealed partial class AnimationTriggersVariable : Variable<UnityEngine.UI.AnimationTriggers>
	{
		
		public AnimationTriggersVariable()
		{
		}
		
		public AnimationTriggersVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.AnimationTriggers))]
	public sealed partial class AnimationTriggersListVariable : ListVariable<UnityEngine.UI.AnimationTriggers>
	{
		
		public AnimationTriggersListVariable()
		{
		}
		
		public AnimationTriggersListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.AnimationTriggers))]
	public sealed partial class AnimationTriggersRef : VariableRef<UnityEngine.UI.AnimationTriggers>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.AnimationTriggers))]
	public sealed partial class AnimationTriggersVar : VariableVar<UnityEngine.UI.AnimationTriggers>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.AnimationTriggers))]
	public sealed partial class AnimationTriggersListRef : ListVariableRef<UnityEngine.UI.AnimationTriggers>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.AnimationTriggers))]
	public sealed partial class AnimationTriggersListVar : ListVariableVar<UnityEngine.UI.AnimationTriggers>
	{
	}
}
