using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explsion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Des",2f);
    }

    private void Des()
    {
        Destroy(gameObject);
    }

}
