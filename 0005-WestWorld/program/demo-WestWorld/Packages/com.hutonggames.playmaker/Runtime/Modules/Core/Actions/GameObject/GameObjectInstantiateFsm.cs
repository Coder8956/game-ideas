/* WIP
using JetBrains.Annotations;
using UnityEngine;
using Object = UnityEngine.Object;

namespace HutongGames.PlayMaker.Actions
{
    [PublicAPI]
    [ActionCategory(Category.GameObject)]
    [ConvertibleGroup(ConvertibleGroup.Instantiate)]
    [ActionDescription("Clones a GameObject with an FSM Component. Optionally set parent, and store the created Object.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Object.Instantiate.html")]
    public class GameObjectInstantiateFsm : BaseAction
    {
        [Tooltip("The FSM Component on the GameObject to clone.")]
        [SerializeField]
        private FsmComponentVar _fsmComponent;
        
        [Tooltip("Inputs for the selected FSM Component.")]
        [SerializeField]
        private VariableOverrides _variableOverrides;
        
        [OptionalField]
        [Tooltip("Set the parent of the created Object.")]
        [SerializeField]
        private GameObjectVar _setParent;

        private bool HasParent => _setParent.HasValue();
        
        [OptionalField]
        [HideIf("HasParent", false)]
        [Tooltip("When you assign a parent Object, " +
                 "pass true to position the new object directly in world space. " +
                 "Pass false to set the Object’s position relative to its new parent.")]
        [SerializeField]
        private BoolVar _inWorldSpace;
        
        [OptionalField, WriteOnly]
        [Tooltip("Store the created Object in a GameObject variable.")]
        public GameObjectRef CreatedObject;

        public override bool CanExecute() => _fsmComponent.HasValue();

        public override void Execute()
        {
            var created = _setParent.HasValue() 
                ? Object.Instantiate(_fsmComponent.Value, _setParent.Transform, _inWorldSpace.Value) 
                : Object.Instantiate(_fsmComponent.Value);
            
            if (CreatedObject.IsAssigned)
            {
                CreatedObject.Value = created.GameObject;
            }
        }
        
        public override string GetSummary() => "Instantiate {_fsmComponent} {CreatedObject:output}" 
                                               + (_setParent.IsAssigned ? " parent {_setParent}" : "");
    }
}
*/