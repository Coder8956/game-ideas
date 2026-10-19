using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Resources)]
    [ActionDescription("Loads an AnimationClip from a Resources folder.")]
    public class ResourcesLoadAnimationClip : BaseResourcesLoad<AnimationClip, AnimationClipRef>
    {
    }
}