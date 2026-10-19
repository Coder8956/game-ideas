using System;
using UnityEngine;


namespace HutongGames.PlayMaker
{
	
	
    [Serializable]
    [DataType(typeof(UnityEngine.SkinnedMeshRenderer))]
    public sealed partial class SkinnedMeshRendererVariable : Variable<SkinnedMeshRenderer>
    {
		
        public SkinnedMeshRendererVariable()
        {
        }
		
        public SkinnedMeshRendererVariable(string name) : 
            base(name)
        {
        }
    }
	
    [Serializable]
    [DataType(typeof(UnityEngine.SkinnedMeshRenderer))]
    public sealed partial class SkinnedMeshRendererListVariable : ListVariable<SkinnedMeshRenderer>
    {
		
        public SkinnedMeshRendererListVariable()
        {
        }
		
        public SkinnedMeshRendererListVariable(string name) : 
            base(name)
        {
        }
    }
	
    [Serializable]
    [DataType(typeof(UnityEngine.SkinnedMeshRenderer))]
    public sealed partial class SkinnedMeshRendererRef : BaseComponentRef<SkinnedMeshRenderer>
    {
    }
	
    [Serializable]
    [DataType(typeof(UnityEngine.SkinnedMeshRenderer))]
    public sealed partial class SkinnedMeshRendererVar : BaseComponentVar<SkinnedMeshRenderer>
    {
    }
	
    [Serializable]
    [DataType(typeof(UnityEngine.SkinnedMeshRenderer))]
    public sealed partial class SkinnedMeshRendererListRef : ListVariableRef<SkinnedMeshRenderer>
    {
    }
	
    [Serializable]
    [DataType(typeof(UnityEngine.SkinnedMeshRenderer))]
    public sealed partial class SkinnedMeshRendererListVar : ListVariableVar<SkinnedMeshRenderer>
    {
    }
}