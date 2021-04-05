using System;

namespace GF.Library.SceneTransition
{
    public interface ISceneTransitionState
    {
        ISceneReference CurrentScene { get; }
        LoadingState LoadingState { get; }
        Action<ISceneReference> SceneChanged { get; set; }
        Action<LoadingState> LoadingStateChanged { get; set; }
    }
}