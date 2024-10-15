using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] Health health;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Common.Bullet))
        {
            Debug.Log(1);
            health.TakeDame(1);
        }    
    }
}
