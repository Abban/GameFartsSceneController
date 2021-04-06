using UnityEditor;
using UnityEngine;

namespace GF.Library.SceneController
{
    [CreateAssetMenu(fileName = "SceneReference", menuName = "GF/Scene Controller/Scene Reference")]
    public class SceneReference : ScriptableObject, ISceneReference
    {
#if UNITY_EDITOR
        [SerializeField] private SceneAsset scene = null;

        private void SetSceneName()
        {
            if (scene == null) return;
            sceneName = scene.name;
        }

        private void OnValidate()
        {
            SetSceneName();
        }
#endif
        [SerializeField] private bool reloadable = true;
        [SerializeField] private string sceneName = string.Empty;
        public string SceneName => sceneName;
        public bool Reloadable => reloadable;
    }
}