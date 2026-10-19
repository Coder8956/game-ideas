using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace HutongGames.PlayMaker.UI
{
    public interface IDataFieldTarget
    {
        void Apply(IVariableVar value, DataDefinition definition, SerializableGuid fieldGuid);
    }
    
    [Serializable]
    public sealed class DataFieldBinding
    {
        [SerializeField] 
        public SerializableGuid FieldGuid;
        
        [FormerlySerializedAs("Store")] 
        [SerializeReference]
        public IDataFieldTarget Target;
    }
}
