
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemShapeTextureChannel))]
	public sealed partial class ParticleSystemShapeTextureChannelVariable : Variable<UnityEngine.ParticleSystemShapeTextureChannel>
	{
		
		public ParticleSystemShapeTextureChannelVariable()
		{
		}
		
		public ParticleSystemShapeTextureChannelVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemShapeTextureChannel))]
	public sealed partial class ParticleSystemShapeTextureChannelListVariable : ListVariable<UnityEngine.ParticleSystemShapeTextureChannel>
	{
		
		public ParticleSystemShapeTextureChannelListVariable()
		{
		}
		
		public ParticleSystemShapeTextureChannelListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemShapeTextureChannel))]
	public sealed partial class ParticleSystemShapeTextureChannelRef : VariableRef<UnityEngine.ParticleSystemShapeTextureChannel>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemShapeTextureChannel))]
	public sealed partial class ParticleSystemShapeTextureChannelVar : VariableVar<UnityEngine.ParticleSystemShapeTextureChannel>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemShapeTextureChannel))]
	public sealed partial class ParticleSystemShapeTextureChannelListRef : ListVariableRef<UnityEngine.ParticleSystemShapeTextureChannel>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.ParticleSystemShapeTextureChannel))]
	public sealed partial class ParticleSystemShapeTextureChannelListVar : ListVariableVar<UnityEngine.ParticleSystemShapeTextureChannel>
	{
	}
}
