using UnityEngine;

public class Weapons : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bulletlPrefab;
    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            shoot();
        }
    }

    void shoot()
    {
        Instantiate(bulletlPrefab, firepoint.position, firepoint.rotation);
    }

}
