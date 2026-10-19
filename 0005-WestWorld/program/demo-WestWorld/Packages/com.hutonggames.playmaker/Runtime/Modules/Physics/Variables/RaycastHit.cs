
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.RaycastHit))]
	public sealed partial class RaycastHitVariable : Variable<UnityEngine.RaycastHit>
	{
		
		public RaycastHitVariable()
		{
		}
		
		public RaycastHitVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RaycastHit))]
	public sealed partial class RaycastHitListVariable : ListVariable<UnityEngine.RaycastHit>
	{
		
		public RaycastHitListVariable()
		{
		}
		
		public RaycastHitListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RaycastHit))]
	public sealed partial class RaycastHitRef : VariableRef<UnityEngine.RaycastHit>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RaycastHit))]
	public sealed partial class RaycastHitVar : VariableVar<UnityEngine.RaycastHit>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RaycastHit))]
	public sealed partial class RaycastHitOverride : VariableOverride<UnityEngine.RaycastHit, RaycastHitVariable, RaycastHitVar>
	{
		
		public RaycastHitOverride(IVariable variable) : 
			base(variable)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RaycastHit))]
	public sealed partial class RaycastHitOutput : VariableOutput<UnityEngine.RaycastHit, RaycastHitVariable, RaycastHitRef>
	{
		
		public RaycastHitOutput(IVariable variable) : 
			base(variable)
		{
		}
	}
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.RaycastHit))]
	public sealed partial class RaycastHitListRef : ListVariableRef<UnityEngine.RaycastHit>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.RaycastHit))]
	public sealed partial class RaycastHitListVar : ListVariableVar<UnityEngine.RaycastHit>
	{
	}
}
