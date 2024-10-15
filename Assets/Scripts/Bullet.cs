using Lean.Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Rigidbody _rb;
    [SerializeField] float _speed;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        _rb.velocity = transform.right * _speed;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Common.Wall) || other.CompareTag(Common.Destroyable))
        {
            LeanPool.Despawn(this);
        }
    }
}
