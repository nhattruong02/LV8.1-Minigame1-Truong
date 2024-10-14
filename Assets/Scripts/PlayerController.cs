using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Joystick _joystickMove;
    [SerializeField] Joystick _joystickShot;
    [SerializeField] Rigidbody _rb;
    [SerializeField] float _speed;
    Vector3 _move;
    // Start is called before the first frame update
    void Start()
    {
    }
    private void FixedUpdate()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        float horizontalMove = _joystickMove.Horizontal * _speed;
        float verticalMove = _joystickMove.Vertical * _speed;
        Debug.Log(horizontalMove);
        var direction = new Vector3(horizontalMove, 0, verticalMove);
        _rb.velocity = Camera.main.transform.TransformDirection(direction);
        direction.y = 0;
    }
}
