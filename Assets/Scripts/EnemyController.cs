using CodeMonkey.HealthSystemCM;
using Lean.Pool;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] Health _health;
    [SerializeField] GameObject _deadEffect;
    [SerializeField] float _radiusChasing;
    [SerializeField] Transform _playerTransform;
    [SerializeField] Transform _cannonTank;
    [SerializeField] LeanGameObjectPool _pool;
    [SerializeField] Transform _spawBulletPoint;
    [SerializeField] float _speedBullet;
    private GameObject _bullet;
    private bool isChasing = false;
    private NavMeshAgent _agent;
    float attackInterval = 0;
    private PlayerController _player;
    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _player = GameObject.FindGameObjectWithTag(Common.Player).GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (_player.IsAlive)
        {
            if (attackInterval >= 0)
            {
                attackInterval -= Time.deltaTime;
            }
            Dead();
            ChasingPlayer();
        }
    }

    private void ChasingPlayer()
    {
        if (Vector3.Distance(this.transform.position, _playerTransform.position) <= _radiusChasing)
        {
            isChasing = true;
            Shot();
        }
        if (isChasing)
        {
            _agent.SetDestination(_playerTransform.position);
        }
    }

    private void Shot()
    {
        _cannonTank.rotation = Quaternion.LookRotation(_cannonTank.position - _playerTransform.position);
        if (attackInterval <= 0)
        {
            _bullet = _pool.Spawn(_spawBulletPoint.position, _spawBulletPoint.rotation);
            _bullet.GetComponent<Rigidbody>().velocity = _spawBulletPoint.forward * _speedBullet;
            attackInterval = 0.2f;
        }
    }

    private void Dead()
    {
        if (_health.Maxhealth <= 0)
        {
            isChasing = false;
            _agent.ResetPath();
            Destroy(gameObject);
            GameManager.Instance.NumberEnemy -= 1;
            SpawDeadEffect();
            AudioManager.Instance.PlayOneShot("Dead");
        }
    }

    private void SpawDeadEffect()
    {
        _deadEffect = Instantiate(_deadEffect);
        _deadEffect.transform.position = this.transform.position;
        _deadEffect.GetComponent<ParticleSystem>().Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Common.Bullet))
        {
            isChasing = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(this.transform.position, _radiusChasing);
    }
}
