using Lean.Pool;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Joystick _joystickMove;
    [SerializeField] Joystick _joystickShot;
    [SerializeField] Rigidbody _rb;
    [SerializeField] float _speedMove;
    [SerializeField] float _speedBullet;
    [SerializeField] Transform _cannonTank;
    [SerializeField] Transform _spawBulletPoint;
    [SerializeField] Vector3 _offset;
    private GameObject _bullet;
    [SerializeField] LeanGameObjectPool _pool;
    [SerializeField] ParticleSystem _particleSystemSmoke;
    float attackInterval = 0;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        Move();
        RotateCannon();
        MoveCamera();
        if(attackInterval >= 0)
        {
            attackInterval -= Time.deltaTime;
        }
    }



    private void MoveCamera()
    {
        Camera.main.transform.position = this.transform.position - _offset; 
    }

    private void RotateCannon()
    {
        if(_joystickShot.Horizontal != 0 || _joystickShot.Vertical != 0)
        {
            var direction = new Vector3(_joystickShot.Horizontal, 0, _joystickShot.Vertical);
            direction.y = 0;
            direction = Camera.main.transform.TransformDirection(direction);
            Quaternion target = Quaternion.LookRotation(direction);
            _cannonTank.eulerAngles = new Vector3(0, target.eulerAngles.y, 0);
            if (direction == Vector3.zero)
            {
                _cannonTank.rotation = _cannonTank.rotation;
            }
            Shot();
        }
    }

    private void Shot()
    {
        if (attackInterval <= 0)
        {
            _bullet = _pool.Spawn( _spawBulletPoint.position, _spawBulletPoint.rotation);
            _bullet.GetComponent<Rigidbody>().velocity = _spawBulletPoint.forward * _speedBullet;
            attackInterval = 0.2f;
        }
    }

    private void Move()
    {
        float horizontalMove = _joystickMove.Horizontal * _speedMove;
        float verticalMove = _joystickMove.Vertical * _speedMove;
        var direction = new Vector3(horizontalMove, 0, verticalMove);
        _rb.velocity = Camera.main.transform.TransformDirection(direction);
        direction.y = 0;
        if(direction != Vector3.zero)
        {
             _particleSystemSmoke.Play();
            transform.rotation = Quaternion.LookRotation(_rb.velocity);
        }
    }
}
