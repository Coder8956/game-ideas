
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.AnisotropicFiltering))]
	public sealed partial class AnisotropicFilteringVariable : Variable<UnityEngine.AnisotropicFiltering>
	{
		
		public AnisotropicFilteringVariable()
		{
		}
		
		public AnisotropicFilteringVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AnisotropicFiltering))]
	public sealed partial class AnisotropicFilteringListVariable : ListVariable<UnityEngine.AnisotropicFiltering>
	{
		
		public AnisotropicFilteringListVariable()
		{
		}
		
		public AnisotropicFilteringListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AnisotropicFiltering))]
	public sealed partial class AnisotropicFilteringRef : VariableRef<UnityEngine.AnisotropicFiltering>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AnisotropicFiltering))]
	public sealed partial class AnisotropicFilteringVar : VariableVar<UnityEngine.AnisotropicFiltering>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AnisotropicFiltering))]
	public sealed partial class AnisotropicFilteringListRef : ListVariableRef<UnityEngine.AnisotropicFiltering>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.AnisotropicFiltering))]
	public sealed partial class AnisotropicFilteringListVar : ListVariableVar<UnityEngine.AnisotropicFiltering>
	{
	}
}
