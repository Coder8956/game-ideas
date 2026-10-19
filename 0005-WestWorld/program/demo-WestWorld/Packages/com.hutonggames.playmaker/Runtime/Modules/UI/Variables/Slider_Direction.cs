
using System;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Slider.Direction))]
	public sealed partial class Slider_DirectionVariable : Variable<UnityEngine.UI.Slider.Direction>
	{
		
		public Slider_DirectionVariable()
		{
		}
		
		public Slider_DirectionVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Slider.Direction))]
	public sealed partial class Slider_DirectionListVariable : ListVariable<UnityEngine.UI.Slider.Direction>
	{
		
		public Slider_DirectionListVariable()
		{
		}
		
		public Slider_DirectionListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Slider.Direction))]
	public sealed partial class Slider_DirectionRef : VariableRef<UnityEngine.UI.Slider.Direction>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Slider.Direction))]
	public sealed partial class Slider_DirectionVar : VariableVar<UnityEngine.UI.Slider.Direction>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Slider.Direction))]
	public sealed partial class Slider_DirectionListRef : ListVariableRef<UnityEngine.UI.Slider.Direction>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Slider.Direction))]
	public sealed partial class Slider_DirectionListVar : ListVariableVar<UnityEngine.UI.Slider.Direction>
	{
	}
}
