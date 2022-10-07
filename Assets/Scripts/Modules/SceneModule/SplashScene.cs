using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Modules.SceneManager
{
    public class SplashScene : BaseScene
    {
        public override UniTask<bool> StartOpen()
        {
            var res = new UniTaskCompletionSource<bool>();
            return res.Task;
        }

        public override UniTask<bool> StartClose()
        {
            var res = new UniTaskCompletionSource<bool>();
            return res.Task;
        }

        public override async UniTask<bool> Opened()
        {
            var res = new UniTaskCompletionSource<bool>();
            await UniTask.Delay(2);
            await SceneSwitcher.Load("Game");
            return await res.Task;
        }

        public override UniTask<bool> Closed()
        {
            var res = new UniTaskCompletionSource<bool>();
            return res.Task;
        }
    }
}