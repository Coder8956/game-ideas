
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemRenderer))]
	public sealed partial class ParticleSystemRendererVariable : Variable<UnityEngine.ParticleSystemRenderer>
	{
		
		public ParticleSystemRendererVariable()
		{
		}
		
		public ParticleSystemRendererVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemRenderer))]
	public sealed partial class ParticleSystemRendererListVariable : ListVariable<UnityEngine.ParticleSystemRenderer>
	{
		
		public ParticleSystemRendererListVariable()
		{
		}
		
		public ParticleSystemRendererListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemRenderer))]
	public sealed partial class ParticleSystemRendererRef : BaseComponentRef<UnityEngine.ParticleSystemRenderer>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemRenderer))]
	public sealed partial class ParticleSystemRendererVar : BaseComponentVar<UnityEngine.ParticleSystemRenderer>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemRenderer))]
	public sealed partial class ParticleSystemRendererListRef : ListVariableRef<UnityEngine.ParticleSystemRenderer>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemRenderer))]
	public sealed partial class ParticleSystemRendererListVar : ListVariableVar<UnityEngine.ParticleSystemRenderer>
	{
	}
}
