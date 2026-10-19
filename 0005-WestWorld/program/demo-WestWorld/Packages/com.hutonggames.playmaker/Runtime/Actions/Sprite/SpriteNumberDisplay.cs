using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Scripting.APIUpdating;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [MovedFrom("Actions.Sprite")]
    [ActionCategory(Category.Sprite)]
    [ActionDescription("Use number sprites to display a number.")]
    [HelpURL("actions/sprite-actions/sprite-number-display/")]
    public class SpriteNumberDisplay : BaseAction
    {
        public enum Alignment { Left, Right };

        [Tooltip("The parent GameObject should have child SpriteRenderers or Images for each digit you want to display. " +
                 "<br/>For example, if you want to display 123, you should have 3 children, one for each digit.")]
        [SerializeField, OwnerDefaultValue]
        private GameObjectVar _digitsParent;
        
        [Tooltip("The number to display.")]
        [SerializeField]
        private IntegerVar _number;
        
        [Tooltip("The alignment of the number in the display. " +
                 "Only used if the empty sprite is None, otherwise all digits are used.")]
        [SerializeField]
        private Alignment _alignment = Alignment.Left;
        
        [Tooltip("Assign 0-9 sprites.")]
        [SerializeField]
        private SpriteListVar _numberSprites;

        [Tooltip("Sprite to use for empty space. " +
                 "<br/>You can use an empty sprite, or a '0' sprite if you want to display '001' instead of '1'.")]
        [SerializeField, OptionalField]
        private SpriteVar _emptySprite;

        // Cache components used to render the digits
        private SpriteRenderer[] _digitRenderers;
        private Image[] _digitsImages;
        private GameObject[] _digits;
        
        public override bool CanExecute() => CheckParameters(_number, _numberSprites, _digits);

        private GameObject _cachedForGameObject;
        
        private void CacheRenderers(GameObject parent)
        {
            if (_cachedForGameObject == parent) return;
            
            // For now, we just try to grab both components.
            // Technically this allows mixing sprite components.
            // But that's probably not that useful, so maybe we
            // change this to detect the component type first.
            
            _cachedForGameObject = parent;
            _digits = new GameObject[parent.transform.childCount];
            for (int i = 0; i < parent.transform.childCount; i++)
            {
                _digits[i] = parent.transform.GetChild(i).gameObject;
            }

            _digitRenderers = new SpriteRenderer[_digits.Length];
            _digitsImages = new Image[_digits.Length];
            
            for (var i = 0; i < _digits.Length; i++)
            {
                var gameObject = _digits[i];
                _digitRenderers[i] = gameObject.GetComponent<SpriteRenderer>();
                _digitsImages[i] = gameObject.GetComponent<Image>();
            }
        }

        public override void Execute()
        {
            if (_numberSprites.Value == null || _numberSprites.Value.Count < 10)
            {
                LogError("Number Sprites must contain 10 sprites:\n0, 1, 2, 3, 4, 5, 6, 7, 8, 9.");
                Finish();
                return;
            }
            
            if (_digitsParent.Value == null) return;
            
            CacheRenderers(_digitsParent.Value);
            
            var numbers = _numberSprites.Value;
            var scoreString = _number.Value.ToString();
            var numDigits = scoreString.Length;
            var maxDigits = _digits.Length;
            
            // Clear previous display
            for (var i = 0; i < _digits.Length; i++)
            {
                SetDigit(i, _emptySprite.Value);
            }

            if (_alignment == Alignment.Left && _emptySprite.Value == null)
            {
                for (var i = 0; i < numDigits && i < maxDigits; i++)
                {
                    var digitChar = scoreString[i];
                    var digitValue = int.Parse(digitChar.ToString());
                    SetDigit(i, numbers[digitValue]);
                }
            }
            else // Right alignment
            {
                for (var i = 0; i < numDigits && i < maxDigits; i++)
                {
                    var digitChar = scoreString[numDigits - 1 - i];
                    var digitValue = int.Parse(digitChar.ToString());

                    // Assign the sprite to the corresponding positioned renderer
                    var digitIndex = maxDigits - 1 - i;
                    if (digitIndex >= 0)
                    {
                        SetDigit(digitIndex, numbers[digitValue]);
                    }
                }
            }
        }

        private void SetDigit(int index, UnityEngine.Sprite sprite)
        {
            var spriteRenderer = _digitRenderers[index];
            if (spriteRenderer != null)
            {
                spriteRenderer.sprite = sprite;
                return;
            }
            
            var image = _digitsImages[index];
            if (image != null)
            {
                image.sprite = sprite;
            }
        }

        public override string ErrorCheck()
        {
            if (_numberSprites.IsConstantValue && _numberSprites.Value?.Count < 10)
            {
                return "Number Sprites must contain 10 sprites:\n0, 1, 2, 3, 4, 5, 6, 7, 8, 9.";
            }

            return null;
        }

        public override string GetSummary() => "{_digitsParent} display number {_number} using {_numberSprites}";
    }
}
