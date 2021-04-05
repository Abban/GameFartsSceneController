using UnityEngine;

namespace GF.Library.SceneTransition.TestResources
{
    // [CreateAssetMenu(fileName = "TestScenes", menuName = "GF/Scene Transition/Test Scenes")]
    public class TransitionControllerTestScenes : ScriptableObject
    {
        [SerializeField] private SceneReference defaultTestScene = null;
        [SerializeField] private SceneReference reloadableTestScene = null;

        public SceneReference DefaultTestScene => defaultTestScene;
        public SceneReference ReloadableTestScene => reloadableTestScene;
    }
}