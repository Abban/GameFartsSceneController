using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GF.Library.SceneTransition
{
    public class SceneTransitionController : ISceneTransitionController
    {
        private readonly ISceneTransition _transition;
        private ISceneReference _currentScene;
        private LoadingState _loadingState;

        public SceneTransitionController(
            ISceneTransition transition,
            ISceneReference startScene)
        {
            _transition = transition;
            _currentScene = startScene;
            _loadingState = LoadingState.Idle;
        }


        public Action<ISceneReference> SceneChanged { get; set; } = delegate { };
        public Action<LoadingState> LoadingStateChanged { get; set; } = delegate { };


        public ISceneReference CurrentScene
        {
            get => _currentScene;
            private set
            {
                _currentScene = value;
                SceneChanged.Invoke(_currentScene);
            }
        }


        public LoadingState LoadingState
        {
            get => _loadingState;
            private set
            {
                _loadingState = value;
                LoadingStateChanged.Invoke(_loadingState);
            }
        }


        public IEnumerator LoadScene(ISceneReference scene, TransitionType transitionType = TransitionType.None)
        {
            if (!scene.Reloadable && scene == CurrentScene) yield break;

            LoadingState = LoadingState.Loading;
            
            if (transitionType != TransitionType.None)
            {
                yield return _transition.Show();
            }

            yield return SceneManager.LoadSceneAsync(scene.SceneName, LoadSceneMode.Single);
            CurrentScene = scene;

            if (transitionType == TransitionType.ShowAndHide)
            {
                yield return HideTransition();
            }
            else if (transitionType == TransitionType.None)
            {
                LoadingState = LoadingState.Idle;
            }
        }


        public IEnumerator HideTransition()
        {
            yield return _transition.Hide();
            LoadingState = LoadingState.Idle;
        }
    }
}