using System;
using JetBrains.Annotations;
using UnityEngine;
using Object = UnityEngine.Object;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.Instantiate)]
    [ConvertibleGroup(ConvertibleGroup.Instantiate)]
    [ActionDescription("Clones a GameObject at a position and rotation defined by a Transform. " +
                       "Optionally set a parent and store the created Object.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Object.Instantiate.html")]
    public class GameObjectInstantiateAtTransform : BaseAction
    {
        [NotOwnerDefaultValue]
        [Tooltip("The GameObject to clone.")]
        public GameObjectVar CloneGameObject;
        
        [OwnerDefaultValue]
        [Tooltip("Set the position and rotation for the created object using a Transform in the scene.")]
        public TransformVar AtTransform;
        
        [OptionalField]
        [Tooltip("Set the parent of the created Object.")]
        public TransformVar SetParent;
        
        [OptionalField, WriteOnly]
        [Tooltip("Store the created Object in a GameObject variable.")]
        public GameObjectRef StoreCreatedObject;

        [OptionalField]
        [Tooltip("Select the created Object in the editor (EditorOnly). " +
                 "This can be useful to quickly view an FSM on the instance.")]
        public BoolVar SelectInEditor;
        
        public override bool CanExecute()
        {
            return AtTransform.HasValue() && CloneGameObject.HasValue();
        }

        public override void Execute()
        {
            var position = AtTransform.Value.position;
            var rotation = AtTransform.Value.rotation;

            var created = SetParent.HasValue() 
                ? Object.Instantiate(CloneGameObject.Value, position, rotation, SetParent.Value) 
                : Object.Instantiate(CloneGameObject.Value, position, rotation);

            if (StoreCreatedObject != null)
            {
                StoreCreatedObject.Value = created;
            }
            
#if UNITY_EDITOR

            if (SelectInEditor.Value)
            {
                UnityEditor.Selection.activeGameObject = created;
            }
#endif
        }
        
        public override string GetSummary() => "Instantiate {CloneGameObject} at {AtTransform} position"
                                               + (SetParent.IsAssigned ? ", parent to {SetParent}" : "")
                                               + (StoreCreatedObject.IsAssigned ? " -> {StoreCreatedObject}" : "");
    }
}