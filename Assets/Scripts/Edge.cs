using UnityEngine;

public class Edge : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name + "delete");
        Destroy(collision.gameObject);
    }
}
