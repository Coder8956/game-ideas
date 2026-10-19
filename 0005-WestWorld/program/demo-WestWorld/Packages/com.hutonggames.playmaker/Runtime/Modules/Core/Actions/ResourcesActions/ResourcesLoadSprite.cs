using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Resources)]
    [ActionDescription("Loads a Sprite from a Resources folder.")]
    public class ResourcesLoadSprite : BaseResourcesLoad<Sprite, SpriteRef>
    {
    }
}