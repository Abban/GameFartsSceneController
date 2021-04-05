using System.Collections;

namespace GF.Library.SceneTransition
{
    public interface ISceneTransitionController : ISceneTransitionState
    {
        IEnumerator LoadScene(ISceneReference scene, TransitionType transitionType = TransitionType.None);
        IEnumerator HideTransition();
    }
}