#if !UNITY_6000_0_OR_NEWER
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	[Serializable]
	[DataType(typeof(UnityEngine.LightShape))]
	public sealed partial class LightShapeVariable : Variable<UnityEngine.LightShape>
	{
		
		public LightShapeVariable()
		{
		}
		
		public LightShapeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.LightShape))]
	public sealed partial class LightShapeRef : VariableRef<UnityEngine.LightShape>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.LightShape))]
	public sealed partial class LightShapeVar : VariableVar<UnityEngine.LightShape>
	{
	}
}
#endif