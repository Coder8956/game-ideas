
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystem))]
	public sealed partial class ParticleSystemVariable : Variable<UnityEngine.ParticleSystem>
	{
		
		public ParticleSystemVariable()
		{
		}
		
		public ParticleSystemVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystem))]
	public sealed partial class ParticleSystemListVariable : ListVariable<UnityEngine.ParticleSystem>
	{
		
		public ParticleSystemListVariable()
		{
		}
		
		public ParticleSystemListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystem))]
	public sealed partial class ParticleSystemRef : BaseComponentRef<UnityEngine.ParticleSystem>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystem))]
	public sealed partial class ParticleSystemVar : BaseComponentVar<UnityEngine.ParticleSystem>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystem))]
	public sealed partial class ParticleSystemListRef : ListVariableRef<UnityEngine.ParticleSystem>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystem))]
	public sealed partial class ParticleSystemListVar : ListVariableVar<UnityEngine.ParticleSystem>
	{
	}

	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystem))]
	public sealed partial class ParticleSystemOverride : VariableOverride<UnityEngine.ParticleSystem, ParticleSystemVariable, ParticleSystemVar>
	{
		public ParticleSystemOverride(IVariable variable) : base(variable)
		{
		}
	}

	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystem))]
	public sealed partial class ParticleSystemOutput : VariableOutput<UnityEngine.ParticleSystem, ParticleSystemVariable, ParticleSystemRef>
	{
		public ParticleSystemOutput(IVariable variable) : base(variable)
		{
		}
	}

	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystem))]
	public sealed partial class ParticleSystemListOverride : VariableOverride<System.Collections.Generic.List<UnityEngine.ParticleSystem>, ParticleSystemListVariable, ParticleSystemListVar>
	{
		public ParticleSystemListOverride(IVariable variable) : base(variable)
		{
		}
	}

	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystem))]
	public sealed partial class ParticleSystemListOutput : VariableOutput<System.Collections.Generic.List<UnityEngine.ParticleSystem>, ParticleSystemListVariable, ParticleSystemListRef>
	{
		public ParticleSystemListOutput(IVariable variable) : base(variable)
		{
		}
	}
}
