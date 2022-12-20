using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorsoMovement : MonoBehaviour
{

    [Header("Movement")]
    [SerializeField] private float _horizontalLimit;
    [SerializeField] private float _horizontalSpeed;
    private float _horizontal;
    [SerializeField] private float _moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BallMoveForward();
        BallHorizontalMovement();
    }
    private void BallHorizontalMovement()
    {
        float _newX = 0;

        if (Input.GetMouseButton(0))
        {
            _horizontal = Input.GetAxisRaw("Mouse X");
        }
        else
        {
            _horizontal = 0;
        }

        _newX = transform.position.x + _horizontal * _horizontalSpeed * Time.deltaTime;
        _newX = Mathf.Clamp(_newX, -_horizontalLimit, _horizontalLimit);

        transform.position = new Vector3(
            _newX,
            transform.position.y,
            transform.position.z
        );


    }



    private void BallMoveForward()
    {
        transform.Translate(Vector3.down * _moveSpeed * Time.deltaTime);
    }
}
