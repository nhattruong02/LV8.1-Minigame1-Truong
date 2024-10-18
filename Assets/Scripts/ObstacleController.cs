using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ObstacleController : MonoBehaviour
{
    [SerializeField] Health _health;
    [SerializeField] GameObject _deadEffect;
    private void Update()
    {
        Dead();
    }


    private void Dead()
    {
        if (_health.Maxhealth <= 0)
        {
            AudioManager.Instance.PlayOneShot("Dead");
            if (this.CompareTag(Common.Base)) { 
                GameManager.Instance.IsBaseAlive = false;
            }
            Destroy(gameObject);
            StartCoroutine(SpawDeadEffect());
        }
    }

    IEnumerator SpawDeadEffect()
    {
        _deadEffect = Instantiate(_deadEffect);
        _deadEffect.transform.position = this.transform.position;
        _deadEffect.GetComponent<ParticleSystem>().Play();
        yield return new WaitForSeconds(1);
        Destroy(_deadEffect.gameObject);
    }

}
