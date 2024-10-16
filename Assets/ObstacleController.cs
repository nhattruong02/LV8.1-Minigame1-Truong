using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ObstacleController : MonoBehaviour
{
    [SerializeField] Health _health;
    [SerializeField] GameObject _deadEffect;

    private void Start()
    {
    }

    private void Update()
    {
        Dead();
    }


    private void Dead()
    {
        if (_health.Maxhealth <= 0)
        {
            Destroy(gameObject);
            SpawDeadEffect();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Common.Bullet) || other.CompareTag(Common.BulletEnemy))
        {
            _health.TakeDame(1);
        }
    }

    private void SpawDeadEffect()
    {
        _deadEffect = Instantiate(_deadEffect);
        _deadEffect.transform.position = this.transform.position;
        _deadEffect.GetComponent<ParticleSystem>().Play();
    }

}
