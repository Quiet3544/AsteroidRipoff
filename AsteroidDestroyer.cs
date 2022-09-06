using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDestroyer : MonoBehaviour
{
    public static float destroyTime = 15;
    void Start()
    {
        Destroy(this.gameObject, destroyTime);
    }

}
