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
    [SerializeField] float _speed;
    [SerializeField] Transform _cannonTank;
    [SerializeField] Transform _spawBulletPoint;
    [SerializeField] Vector3 _offset;
    [SerializeField] GameObject _bullet;

    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        Move();
        RotateCannonAndShot();
        MoveCamera();
    }



    private void MoveCamera()
    {
        Camera.main.transform.position = this.transform.position - _offset; 
    }

    private void RotateCannonAndShot()
    {
        if(_joystickShot.Horizontal != 0 || _joystickShot.Vertical != 0)
        {
            float angle = Mathf.Atan2(_joystickShot.Horizontal, _joystickShot.Vertical) * Mathf.Rad2Deg;
            _cannonTank.transform.eulerAngles = new Vector3(0, angle, 0);
            LeanPool.Spawn(_bullet, _spawBulletPoint.transform.position, _spawBulletPoint.transform.rotation);
        }
    }

    private void Move()
    {
        float horizontalMove = _joystickMove.Horizontal * _speed;
        float verticalMove = _joystickMove.Vertical * _speed;
        var direction = new Vector3(horizontalMove, 0, verticalMove);
        _rb.velocity = Camera.main.transform.TransformDirection(direction);       
        direction.y = 0;
        if(_joystickMove.Horizontal !=0 ||  _joystickMove.Vertical !=0)
        {
            transform.rotation = Quaternion.LookRotation(_rb.velocity);
        }

    }
}
