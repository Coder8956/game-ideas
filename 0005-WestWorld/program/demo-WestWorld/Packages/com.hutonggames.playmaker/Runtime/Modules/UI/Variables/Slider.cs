
using System;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Slider))]
	public sealed partial class SliderVariable : Variable<UnityEngine.UI.Slider>
	{
		
		public SliderVariable()
		{
		}
		
		public SliderVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Slider))]
	public sealed partial class SliderListVariable : ListVariable<UnityEngine.UI.Slider>
	{
		
		public SliderListVariable()
		{
		}
		
		public SliderListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Slider))]
	public sealed partial class SliderRef : BaseComponentRef<UnityEngine.UI.Slider>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Slider))]
	public sealed partial class SliderVar : BaseComponentVar<UnityEngine.UI.Slider>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Slider))]
	public sealed partial class SliderListRef : ListVariableRef<UnityEngine.UI.Slider>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.UI.Slider))]
	public sealed partial class SliderListVar : ListVariableVar<UnityEngine.UI.Slider>
	{
	}
}
