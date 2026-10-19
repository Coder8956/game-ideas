
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.SkinQuality))]
	public sealed partial class SkinQualityVariable : Variable<UnityEngine.SkinQuality>
	{
		
		public SkinQualityVariable()
		{
		}
		
		public SkinQualityVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SkinQuality))]
	public sealed partial class SkinQualityListVariable : ListVariable<UnityEngine.SkinQuality>
	{
		
		public SkinQualityListVariable()
		{
		}
		
		public SkinQualityListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SkinQuality))]
	public sealed partial class SkinQualityRef : VariableRef<UnityEngine.SkinQuality>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SkinQuality))]
	public sealed partial class SkinQualityVar : VariableVar<UnityEngine.SkinQuality>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SkinQuality))]
	public sealed partial class SkinQualityListRef : ListVariableRef<UnityEngine.SkinQuality>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SkinQuality))]
	public sealed partial class SkinQualityListVar : ListVariableVar<UnityEngine.SkinQuality>
	{
	}
}
