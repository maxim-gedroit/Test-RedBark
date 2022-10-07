using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Modules.SceneManager
{
    public abstract class BaseScene : MonoBehaviour
    {
        public abstract UniTask<bool> StartOpen();
        public abstract UniTask<bool>  StartClose();
        public abstract UniTask<bool>  Opened();
        public abstract UniTask<bool>  Closed();
    }
}