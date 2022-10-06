using UnityEngine;

public class Root : MonoBehaviour
{
   [SerializeField] private BaseEnemy _anemy;
    // Start is called before the first frame update
    void Start()
    {
        _anemy = GetComponent<BaseEnemy>();
    }

    public void Action()
    {
        _anemy.Damage();
    }
}
