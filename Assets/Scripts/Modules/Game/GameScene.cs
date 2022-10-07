using Cysharp.Threading.Tasks;
using Modules.SceneManager;
using UnityEngine;

public class GameScene : BaseScene
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

    public override UniTask<bool> Opened()
    {
        var res = new UniTaskCompletionSource<bool>();
        
        return res.Task;
    }

    public override UniTask<bool> Closed()
    {
        var res = new UniTaskCompletionSource<bool>();
        return res.Task;
    }
}
