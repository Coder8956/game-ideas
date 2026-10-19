
using System;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Slider.SliderEvent))]
	public sealed partial class Slider_SliderEventVariable : Variable<UnityEngine.UI.Slider.SliderEvent>
	{
		
		public Slider_SliderEventVariable()
		{
		}
		
		public Slider_SliderEventVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Slider.SliderEvent))]
	public sealed partial class Slider_SliderEventRef : VariableRef<UnityEngine.UI.Slider.SliderEvent>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Slider.SliderEvent))]
	public sealed partial class Slider_SliderEventVar : VariableVar<UnityEngine.UI.Slider.SliderEvent>
	{
	}
	
	/*
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Slider.SliderEvent))]
	public sealed partial class Slider_SliderEventListVariable : ListVariable<UnityEngine.UI.Slider.SliderEvent>
	{
		
		public Slider_SliderEventListVariable()
		{
		}
		
		public Slider_SliderEventListVariable(string name) : 
			base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Slider.SliderEvent))]
	public sealed partial class Slider_SliderEventListRef : ListVariableRef<UnityEngine.UI.Slider.SliderEvent>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Slider.SliderEvent))]
	public sealed partial class Slider_SliderEventListVar : ListVariableVar<UnityEngine.UI.Slider.SliderEvent>
	{
	}
	*/
}
