using System.Linq.Expressions;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Transform)]
    [ActionDescription("Tests if a Transform's screen position is inside a screen rectangle.")]
    [HelpURL("actions/transform-actions/measurement-actions/")]
    [MovedFrom(true, null, null, "TransformIsInScreenRect")]
    public class TransformCheckIsInScreenRect : BaseTrueFalseAction
    {
        [OwnerDefaultValue]
        [Tooltip("The Transform.")]
        [SerializeField]
        private TransformVar _transform;

        [Tooltip("The Camera to use.")]
        [SerializeField, DefaultValue("~MainCamera")]
        private CameraVar _camera;

        [SerializeField, DefaultValue("Rect.one")]
        private RectVar _screenRect;
        
        [Tooltip("Used normalized screen coordinates.")]
        [SerializeField, DefaultValue(true)]
        private BoolVar _normalized;

        public override bool CanExecute() => CheckParameters(_transform, _camera, _screenRect, _normalized);

        protected override bool Test()
        {
            var camera = _camera.Value;
            if (camera == null) return false;
            
            var transform = _transform.Value;
            if (transform == null) return false;
            
            var screenPosition = camera.WorldToScreenPoint(transform.position);
            if (_normalized.Value)
            {
                screenPosition.x /= Screen.width;
                screenPosition.y /= Screen.height;
            }

            return _screenRect.Value.Contains(screenPosition);
        }

        protected override string TrueSummary => "{_transform} is in {_screenRect}";
        protected override string FalseSummary => "{_transform} is not in {_screenRect}";
    }
}