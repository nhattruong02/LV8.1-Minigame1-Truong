using Lean.Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Common.Wall) || other.CompareTag(Common.Destroyable) || other.CompareTag(Common.Enemy))
        {
            LeanPool.Despawn(this);
        }
    }
}
