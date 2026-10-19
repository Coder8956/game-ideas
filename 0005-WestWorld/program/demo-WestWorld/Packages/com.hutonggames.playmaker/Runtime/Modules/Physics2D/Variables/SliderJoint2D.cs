
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.SliderJoint2D))]
	public sealed partial class SliderJoint2DVariable : Variable<UnityEngine.SliderJoint2D>
	{
		
		public SliderJoint2DVariable()
		{
		}
		
		public SliderJoint2DVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SliderJoint2D))]
	public sealed partial class SliderJoint2DListVariable : ListVariable<UnityEngine.SliderJoint2D>
	{
		
		public SliderJoint2DListVariable()
		{
		}
		
		public SliderJoint2DListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SliderJoint2D))]
	public sealed partial class SliderJoint2DRef : BaseComponentRef<UnityEngine.SliderJoint2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SliderJoint2D))]
	public sealed partial class SliderJoint2DVar : BaseComponentVar<UnityEngine.SliderJoint2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SliderJoint2D))]
	public sealed partial class SliderJoint2DListRef : ListVariableRef<UnityEngine.SliderJoint2D>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SliderJoint2D))]
	public sealed partial class SliderJoint2DListVar : ListVariableVar<UnityEngine.SliderJoint2D>
	{
	}
}
