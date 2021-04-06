using System.Collections;

namespace GF.Library.SceneController
{
    public interface ISceneController : ISceneState
    {
        IEnumerator LoadScene(ISceneReference scene, TransitionType transitionType = TransitionType.None);
        IEnumerator HideTransition();
    }
}