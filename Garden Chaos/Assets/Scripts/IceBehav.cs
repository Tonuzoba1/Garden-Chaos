using UnityEngine;

public class IceBehav : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject.FindObjectOfType<CloudBehav>().drops.Remove(gameObject);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject.FindObjectOfType<CloudBehav>().drops.Remove(gameObject);
        Destroy(gameObject);
    }
}
