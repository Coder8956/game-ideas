
using System;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.ScrollRect.MovementType))]
	public sealed partial class ScrollRect_MovementTypeVariable : Variable<UnityEngine.UI.ScrollRect.MovementType>
	{
		
		public ScrollRect_MovementTypeVariable()
		{
		}
		
		public ScrollRect_MovementTypeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.ScrollRect.MovementType))]
	public sealed partial class ScrollRect_MovementTypeListVariable : ListVariable<UnityEngine.UI.ScrollRect.MovementType>
	{
		
		public ScrollRect_MovementTypeListVariable()
		{
		}
		
		public ScrollRect_MovementTypeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.ScrollRect.MovementType))]
	public sealed partial class ScrollRect_MovementTypeRef : VariableRef<UnityEngine.UI.ScrollRect.MovementType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.ScrollRect.MovementType))]
	public sealed partial class ScrollRect_MovementTypeVar : VariableVar<UnityEngine.UI.ScrollRect.MovementType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.ScrollRect.MovementType))]
	public sealed partial class ScrollRect_MovementTypeListRef : ListVariableRef<UnityEngine.UI.ScrollRect.MovementType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.ScrollRect.MovementType))]
	public sealed partial class ScrollRect_MovementTypeListVar : ListVariableVar<UnityEngine.UI.ScrollRect.MovementType>
	{
	}
}
