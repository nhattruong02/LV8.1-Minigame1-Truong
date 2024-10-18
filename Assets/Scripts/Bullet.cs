using Lean.Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _damage;
    private Health _health;
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
        if (other.CompareTag(Common.Wall) || other.CompareTag(Common.Destroyable) || other.CompareTag(Common.Enemy) || other.CompareTag(Common.Base))
        {
            LeanPool.Despawn(this);
        }
        if (other.CompareTag(Common.Enemy) || other.CompareTag(Common.Destroyable) || other.CompareTag(Common.Base))
        {
            _health = other.GetComponent<Health>();
            _health.TakeDame(_damage);
        }
    }
}
