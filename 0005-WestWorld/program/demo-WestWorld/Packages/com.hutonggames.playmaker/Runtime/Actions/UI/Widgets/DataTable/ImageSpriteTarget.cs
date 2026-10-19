using System;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.UI
{
    [Serializable]
    public sealed class ImageSpriteTarget : IDataFieldTarget
    {
        [SerializeField] private Image _image;

        public void Apply(IVariableVar value, DataDefinition def, SerializableGuid guid)
        {
            if (_image == null) return;

            if (value?.GetValue() is Sprite s)
                _image.sprite = s;
        }
    }
}