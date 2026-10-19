
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemTriggerEventType))]
	public sealed partial class ParticleSystemTriggerEventTypeVariable : Variable<UnityEngine.ParticleSystemTriggerEventType>
	{
		
		public ParticleSystemTriggerEventTypeVariable()
		{
		}
		
		public ParticleSystemTriggerEventTypeVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemTriggerEventType))]
	public sealed partial class ParticleSystemTriggerEventTypeListVariable : ListVariable<UnityEngine.ParticleSystemTriggerEventType>
	{
		
		public ParticleSystemTriggerEventTypeListVariable()
		{
		}
		
		public ParticleSystemTriggerEventTypeListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemTriggerEventType))]
	public sealed partial class ParticleSystemTriggerEventTypeRef : VariableRef<UnityEngine.ParticleSystemTriggerEventType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemTriggerEventType))]
	public sealed partial class ParticleSystemTriggerEventTypeVar : VariableVar<UnityEngine.ParticleSystemTriggerEventType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemTriggerEventType))]
	public sealed partial class ParticleSystemTriggerEventTypeListRef : ListVariableRef<UnityEngine.ParticleSystemTriggerEventType>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemTriggerEventType))]
	public sealed partial class ParticleSystemTriggerEventTypeListVar : ListVariableVar<UnityEngine.ParticleSystemTriggerEventType>
	{
	}
}
