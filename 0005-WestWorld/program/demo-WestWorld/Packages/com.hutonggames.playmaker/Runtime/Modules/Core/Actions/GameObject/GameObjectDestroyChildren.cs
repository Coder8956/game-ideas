using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.GameObject)]
    [ActionDescription("Destroys all children of a GameObject.")]
    [MovedFrom( true,null,null,"DestroyChildren")]   
    [HelpURL("actions/gameobject-actions/lifecycle/game-object-destroy-children/")]
    public class GameObjectDestroyChildren : BaseAction
    {
        [OwnerDefaultValue]
        [Tooltip("The parent GameObject. All children of this GameObject will be destroyed.")]
        public GameObjectVar GameObject;

        public override bool CanExecute() => CheckParameters(GameObject);

        public override void Execute()
        {
            var gameObject = GameObject.Value;
            if (gameObject == null) return;

            var transform = gameObject.transform;
            if (transform == null) return;

            var childCount = transform.childCount;
            if (childCount == 0) return;

            var children = new Transform[childCount];
            for (var i = 0; i < childCount; i++)
            {
                children[i] = transform.GetChild(i);
            }

            foreach (var child in children)
            {
                if (child == null) continue;
                child.SetParent(null);
                Object.Destroy(child.gameObject);
            }
        }

        public override string GetSummary() => "Destroy children of {GameObject}";
    }
}
