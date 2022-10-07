using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Modules.SceneManager
{
    public static class SceneSwitcher
    {
        private static BaseScene _currentScene;


        [RuntimeInitializeOnLoadMethod]
        private static void Start()
        {
            _currentScene = GetCurrentScene();
            _currentScene.Opened();
        }

        private static BaseScene GetCurrentScene()
        {
            BaseScene rootScene = null;
            var scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
            var rootObjects = scene.GetRootGameObjects();
            
            
            foreach (var item in rootObjects)
                if (item.TryGetComponent(out BaseScene rootsceneItem))
                    rootScene = rootsceneItem;

            return rootScene;
        }


        public static async UniTask Load(string sceneName)
        {
            _currentScene.StartClose();
            _currentScene.Closed();
            await UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName).ToUniTask();
            _currentScene = GetCurrentScene();
            _currentScene.StartOpen();
            await _currentScene.Opened();
        }
    }
}