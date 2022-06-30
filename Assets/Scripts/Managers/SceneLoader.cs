using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Animation;
using ScriptableObjects;
using Tools;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    /// <summary>
    /// This class is responsible for loading scenes.
    /// </summary>
    public class SceneLoader : MonoBehaviour
    {
        public const string MainMenuSceneName = "Main Menu";
        const string LoadingScreenSceneName = "Loading Screen";
        public const string MainGameSceneName = "Game";
        
        // Awake is called when the script instance is being loaded
        void Awake()
        {
            animationPlayer = GetComponentInChildren<AnimationController>();
            LoadTransitions();
        }

        // Start is called before the first frame update
        void Start() => LoadSceneAction += LoadSceneByName;

        // OnDestroy is called when the behaviour is destroyed
        void OnDestroy() => LoadSceneAction -= LoadSceneByName;

        /// <summary>
        /// Fire this if you want to load a scene.
        /// </summary>
        public static Action<string, TransitionType> LoadSceneAction;
        
        // Cached Components
        AnimationController animationPlayer;

        // References to all the Transitions
        [NotNull] readonly Dictionary<TransitionType, SceneTransitionInfo> transitions = new ();

        /// <summary>
        /// Loads a scene named sceneName.
        /// </summary>
        /// <param name="sceneName"></param>
        /// <param name="transitionType"></param>
        void LoadSceneByName(string sceneName, TransitionType transitionType = default)
        {
            StartCoroutine(LoadSceneByNameCoroutine(sceneName, transitionType));
        }

        /// <summary>
        /// Coroutine that loads a scene named sceneName.
        /// </summary>
        /// <param name="sceneName"></param>
        /// <param name="transitionType"></param>
        /// <returns></returns>
        IEnumerator LoadSceneByNameCoroutine(string sceneName, TransitionType transitionType)
        {
            // Do Not Destroy This Object During Scene Loading
            DontDestroyOnLoad(gameObject);
            
            // Get Transition To Be Used
            SceneTransitionInfo sceneTransitionToUse = transitions[transitionType];

            // Wait For Loading Screen
            yield return LoadSceneWithTransition(LoadingScreenSceneName, sceneTransitionToUse);

            // Wait For Actual Scene Screen
            yield return LoadSceneWithTransition(sceneName, sceneTransitionToUse);

            // Now It Is Safe To Destroy This Object
            Destroy(gameObject);
        }

        /// <summary>
        /// Loads the loading screen to transition between game scenes.
        /// </summary>
        /// <param name="sceneName"></param>
        /// <param name="sceneTransitionToUse"></param>
        /// <param name="loadSceneMode"></param>
        /// <returns></returns>
        IEnumerator LoadSceneWithTransition(string sceneName, SceneTransitionInfo sceneTransitionToUse, LoadSceneMode loadSceneMode = default)
        {
            if (!sceneTransitionToUse) yield break;
            if (!sceneTransitionToUse.PartOne) yield break;
            if (!sceneTransitionToUse.PartTwo) yield break;
            
            // Play First Part Of Transition
            yield return animationPlayer.PlayAnimationUntilTheEnd(Animator.StringToHash(sceneTransitionToUse.PartOne.name));

            // Wait For Loading Screen
            yield return SceneManager.LoadSceneAsync(sceneName, loadSceneMode);

            // Play Second Part Of Transition
            yield return animationPlayer.PlayAnimationUntilTheEnd(Animator.StringToHash(sceneTransitionToUse.PartTwo.name));
        }
        
        /// <summary>
        /// Loads all transitions from the resources folder.
        /// </summary>
        void LoadTransitions()
        {
            SceneTransitionInfo[] loadedTransitions = Resources.LoadAll<SceneTransitionInfo>(Constants.DefaultCSceneTransitionPath);
            if (loadedTransitions == null) return;
            foreach (SceneTransitionInfo transition in loadedTransitions)
            {
                if (!transition) continue;
                transitions.Add(transition.TransitionType, transition);
            }
        }
    }
}
