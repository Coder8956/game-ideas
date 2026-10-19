
using System;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Selectable.Transition))]
	public sealed partial class Selectable_TransitionVariable : Variable<UnityEngine.UI.Selectable.Transition>
	{
		
		public Selectable_TransitionVariable()
		{
		}
		
		public Selectable_TransitionVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Selectable.Transition))]
	public sealed partial class Selectable_TransitionListVariable : ListVariable<UnityEngine.UI.Selectable.Transition>
	{
		
		public Selectable_TransitionListVariable()
		{
		}
		
		public Selectable_TransitionListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Selectable.Transition))]
	public sealed partial class Selectable_TransitionRef : VariableRef<UnityEngine.UI.Selectable.Transition>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Selectable.Transition))]
	public sealed partial class Selectable_TransitionVar : VariableVar<UnityEngine.UI.Selectable.Transition>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Selectable.Transition))]
	public sealed partial class Selectable_TransitionListRef : ListVariableRef<UnityEngine.UI.Selectable.Transition>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Selectable.Transition))]
	public sealed partial class Selectable_TransitionListVar : ListVariableVar<UnityEngine.UI.Selectable.Transition>
	{
	}
}
