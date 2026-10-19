using System;
using UnityEngine;


namespace HutongGames.PlayMaker
{
	
	
    [Serializable]
    [DataType(typeof(UnityEngine.MeshRenderer))]
    public sealed partial class MeshRendererVariable : Variable<MeshRenderer>
    {
		
        public MeshRendererVariable()
        {
        }
		
        public MeshRendererVariable(string name) : 
            base(name)
        {
        }
    }
	
    [Serializable]
    [DataType(typeof(UnityEngine.MeshRenderer))]
    public sealed partial class MeshRendererListVariable : ListVariable<MeshRenderer>
    {
		
        public MeshRendererListVariable()
        {
        }
		
        public MeshRendererListVariable(string name) : 
            base(name)
        {
        }
    }
	
    [Serializable]
    [DataType(typeof(UnityEngine.MeshRenderer))]
    public sealed partial class MeshRendererRef : BaseComponentRef<MeshRenderer>
    {
    }
	
    [Serializable]
    [DataType(typeof(UnityEngine.MeshRenderer))]
    public sealed partial class MeshRendererVar : BaseComponentVar<MeshRenderer>
    {
    }
	
    [Serializable]
    [DataType(typeof(UnityEngine.MeshRenderer))]
    public sealed partial class MeshRendererListRef : ListVariableRef<MeshRenderer>
    {
    }
	
    [Serializable]
    [DataType(typeof(UnityEngine.MeshRenderer))]
    public sealed partial class MeshRendererListVar : ListVariableVar<MeshRenderer>
    {
    }
}