using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDame : MonoBehaviour
{
    private Health _health;
    [SerializeField] private float radiusExplosion;
    [SerializeField] private float damageExplosion;
    private void Start()
    {
        _health = GetComponent<Health>();
    }
    // Update is called once per frame
    void Update()
    {
        if(_health.Maxhealth <= 0)
        {
            ExplosionDamage();
        }
    }
    private void ExplosionDamage()
    {
        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, radiusExplosion);
        foreach (var hit in hitColliders)
        {
            if (hit.CompareTag(Common.Player) || hit.CompareTag(Common.Enemy) || hit.CompareTag(Common.Destroyable))
            {
                hit.GetComponent<Health>().TakeDame(damageExplosion);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(this.transform.position, radiusExplosion);
    }
}
