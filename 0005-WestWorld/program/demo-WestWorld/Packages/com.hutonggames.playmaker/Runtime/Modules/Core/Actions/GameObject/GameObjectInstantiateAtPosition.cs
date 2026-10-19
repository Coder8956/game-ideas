using JetBrains.Annotations;
using UnityEngine;
using Object = UnityEngine.Object;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Instantiate)]
    [ConvertibleGroup(ConvertibleGroup.Instantiate)]
    [ActionDescription("Clones a GameObject at a position and rotation. " +
                       "Optionally set parent, and store the created Object.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Object.Instantiate.html")]
    public class GameObjectInstantiateAtPosition : BaseAction
    {
        [NotOwnerDefaultValue]
        [Tooltip("The GameObject to clone.")]
        public GameObjectVar GameObject;
        
        [Tooltip("Set the position of the created Object.")]
        public Vector3Var Position;
        
        [Tooltip("Set the rotation of the created Object.")]
        public QuaternionVar Rotation;
        
        [OptionalField]
        [Tooltip("Set the parent of the created Object.")]
        public GameObjectVar SetParent;

        private bool HasParent => SetParent.HasValue();
        
        [OptionalField, WriteOnly]
        [Tooltip("Store the created Object in a GameObject variable.")]
        public GameObjectRef CreatedObject;

        [OptionalField]
        [Tooltip("Select the created Object in the editor (EditorOnly). " +
                 "This can be useful to quickly view an FSM on the instance.")]
        public BoolVar SelectInEditor;
        
        public override bool CanExecute() => CheckParameters(GameObject, Position, Rotation);

        public override void Execute()
        {
            var created = SetParent.HasValue()
                ? Object.Instantiate(GameObject.Value, Position.Value, Rotation.Value, SetParent.Transform)
                : Object.Instantiate(GameObject.Value, Position.Value, Rotation.Value);
            
            if (CreatedObject.IsAssigned)
            {
                CreatedObject.Value = created;
            }
            
#if UNITY_EDITOR

            if (SelectInEditor.Value)
            {
                UnityEditor.Selection.activeGameObject = created;
            }
#endif
        }
        
        public override string GetSummary() => "Instantiate {GameObject} at {Position}" 
                                               + (Rotation.IsVariable || Rotation.Value.eulerAngles != Vector3.zero ? " and {Rotation} " : "") 
                                               +" {CreatedObject:output}" 
                                               + (SetParent.IsAssigned ? " parent to {SetParent}" : "");
    }
}