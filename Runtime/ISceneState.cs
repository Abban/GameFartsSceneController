using System;

namespace GF.Library.SceneController
{
    public interface ISceneState
    {
        ISceneReference CurrentScene { get; }
        LoadingState LoadingState { get; }
        Action<ISceneReference> SceneChanged { get; set; }
        Action<LoadingState> LoadingStateChanged { get; set; }
    }
}