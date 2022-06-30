using Managers;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Sounds
{
    /// <summary>
    /// Class responsible for playing UI sound effects.
    /// </summary>
    [RequireComponent(typeof(RectTransform))]
    public class PlaySoundOnPointerEvents : MonoBehaviour, IPointerEnterHandler, IPointerMoveHandler, 
        IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
    {
        [Header("On Pointer Enter")]
        [SerializeField] SoundEffect[] onPointerEnterSoundEffects;
        
        [Header("On Pointer Move")]
        [SerializeField] SoundEffect[] onPointerMoveSoundEffects;
        
        [Header("On Pointer Exit")]
        [SerializeField] SoundEffect[] onPointerExitSoundEffects;
        
        [Header("On Pointer Down")]
        [SerializeField] SoundEffect[] onPointerDownSoundEffects;
        
        [Header("On Pointer Up")]
        [SerializeField] SoundEffect[] onPointerUpSoundEffects;
        
        [Header("On Pointer Click")]
        [SerializeField] SoundEffect[] onPointerClickSoundEffects;

        public void OnPointerEnter(PointerEventData eventData) => onPointerEnterSoundEffects.PlayRandomSound();
        public void OnPointerMove(PointerEventData eventData) => onPointerMoveSoundEffects.PlayRandomSound();
        public void OnPointerExit(PointerEventData eventData) => onPointerExitSoundEffects.PlayRandomSound();
        public void OnPointerDown(PointerEventData eventData) => onPointerDownSoundEffects.PlayRandomSound();
        public void OnPointerUp(PointerEventData eventData) => onPointerUpSoundEffects.PlayRandomSound();
        public void OnPointerClick(PointerEventData eventData) => onPointerClickSoundEffects.PlayRandomSound();
    }
}