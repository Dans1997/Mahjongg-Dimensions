using System.Collections.Generic;
using Managers;
using ScriptableObjects;
using Tiles;
using UnityEngine;

namespace Sounds
{
    /// <summary>
    /// Class responsible for playing the <see cref="Tiles.TileMatcher"/>'s sounds.
    /// </summary>
    public class PlaySoundTileMatcher : MonoBehaviour
    {
        [SerializeField] SoundEffect[] onMatchSoundEffects;
        [SerializeField] SoundEffect[] onMatchFailSoundEffects;
        
        // Start is called before the first frame update
        void Start()
        {
            TileMatcher.OnMatch += OnMatch;
            TileMatcher.OnMatchFail += OnMatchFail;
        }
        
        // OnDestroy is called when the script is destroyed
        void OnDestroy()
        {
            TileMatcher.OnMatch -= OnMatch;
            TileMatcher.OnMatchFail -= OnMatchFail;
        }

        void OnMatch(Stack<Tile> _) => onMatchSoundEffects.PlayRandomSound();
        void OnMatchFail() => onMatchFailSoundEffects.PlayRandomSound();
    }
}