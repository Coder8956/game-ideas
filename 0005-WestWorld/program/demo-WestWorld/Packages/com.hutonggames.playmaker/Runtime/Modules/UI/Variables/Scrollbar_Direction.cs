
using System;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Scrollbar.Direction))]
	public sealed partial class Scrollbar_DirectionVariable : Variable<UnityEngine.UI.Scrollbar.Direction>
	{
		
		public Scrollbar_DirectionVariable()
		{
		}
		
		public Scrollbar_DirectionVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Scrollbar.Direction))]
	public sealed partial class Scrollbar_DirectionListVariable : ListVariable<UnityEngine.UI.Scrollbar.Direction>
	{
		
		public Scrollbar_DirectionListVariable()
		{
		}
		
		public Scrollbar_DirectionListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Scrollbar.Direction))]
	public sealed partial class Scrollbar_DirectionRef : VariableRef<UnityEngine.UI.Scrollbar.Direction>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Scrollbar.Direction))]
	public sealed partial class Scrollbar_DirectionVar : VariableVar<UnityEngine.UI.Scrollbar.Direction>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Scrollbar.Direction))]
	public sealed partial class Scrollbar_DirectionListRef : ListVariableRef<UnityEngine.UI.Scrollbar.Direction>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Scrollbar.Direction))]
	public sealed partial class Scrollbar_DirectionListVar : ListVariableVar<UnityEngine.UI.Scrollbar.Direction>
	{
	}
}
