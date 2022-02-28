using UnityEngine;

public class WeakSpot : MonoBehaviour
{
    public GameObject objectToDestroy;
    public bool isDestroy = false;
    private void onTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("MainPlayer")){
            Destroy(objectToDestroy);
            isDestroy = true; 
        }
    }
}
