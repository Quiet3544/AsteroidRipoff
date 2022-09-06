using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float bulletSpeed = 200f;
    public Rigidbody2D rb;

    void Start()
    {
        rb.AddForce(transform.up * bulletSpeed * Time.deltaTime);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        Destroy(gameObject);
        UIUpdater.score++;
    }


}
