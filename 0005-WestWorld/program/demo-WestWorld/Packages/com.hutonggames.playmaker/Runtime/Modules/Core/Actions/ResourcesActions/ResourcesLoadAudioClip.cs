using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Resources)]
    [ActionDescription("Loads an AudioClip from a Resources folder.")]
    public class ResourcesLoadAudioClip : BaseResourcesLoad<AudioClip, AudioClipRef>
    {
    }
}