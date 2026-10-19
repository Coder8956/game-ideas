
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemStopBehavior))]
	public sealed partial class ParticleSystemStopBehaviorVariable : Variable<UnityEngine.ParticleSystemStopBehavior>
	{
		
		public ParticleSystemStopBehaviorVariable()
		{
		}
		
		public ParticleSystemStopBehaviorVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemStopBehavior))]
	public sealed partial class ParticleSystemStopBehaviorListVariable : ListVariable<UnityEngine.ParticleSystemStopBehavior>
	{
		
		public ParticleSystemStopBehaviorListVariable()
		{
		}
		
		public ParticleSystemStopBehaviorListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemStopBehavior))]
	public sealed partial class ParticleSystemStopBehaviorRef : VariableRef<UnityEngine.ParticleSystemStopBehavior>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemStopBehavior))]
	public sealed partial class ParticleSystemStopBehaviorVar : VariableVar<UnityEngine.ParticleSystemStopBehavior>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemStopBehavior))]
	public sealed partial class ParticleSystemStopBehaviorListRef : ListVariableRef<UnityEngine.ParticleSystemStopBehavior>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemStopBehavior))]
	public sealed partial class ParticleSystemStopBehaviorListVar : ListVariableVar<UnityEngine.ParticleSystemStopBehavior>
	{
	}
}
