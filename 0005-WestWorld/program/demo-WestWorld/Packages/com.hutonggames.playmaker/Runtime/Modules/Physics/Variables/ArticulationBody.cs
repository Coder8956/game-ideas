
using System;
using UnityEngine;

// ReSharper disable PartialTypeWithSinglePart

namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(ArticulationBody))]
	public sealed partial class ArticulationBodyVariable : Variable<ArticulationBody>
	{
		
		public ArticulationBodyVariable()
		{
		}
		
		public ArticulationBodyVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(ArticulationBody))]
	public sealed partial class ArticulationBodyListVariable : ListVariable<ArticulationBody>
	{
		
		public ArticulationBodyListVariable()
		{
		}
		
		public ArticulationBodyListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(ArticulationBody))]
	public sealed partial class ArticulationBodyRef : BaseComponentRef<ArticulationBody>
	{
	}
	
	[Serializable]
	[DataType(typeof(ArticulationBody))]
	public sealed partial class ArticulationBodyVar : BaseComponentVar<ArticulationBody>
	{
	}
	
	[Serializable]
	[DataType(typeof(ArticulationBody))]
	public sealed partial class ArticulationBodyListRef : ListVariableRef<ArticulationBody>
	{
	}
	
	[Serializable]
	[DataType(typeof(ArticulationBody))]
	public sealed partial class ArticulationBodyListVar : ListVariableVar<ArticulationBody>
	{
	}
}
