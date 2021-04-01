using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2021.4.1
/// </summary>

[RequireComponent(typeof(Rigidbody))]
public class MoveCube : MonoBehaviour
{
    /*
     3D person camera control
    (third person)
     */
    [SerializeField]
    private float moveSpeed = 20f;

    //catched
    Rigidbody _rigidbody;
    public Camera _camera;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        if(_camera == null)
        {
            _camera = Camera.main;
        }
    }

    // Update is called once per frame
    void Update()
    {
         Movments();
    }

    void Movments()
    {
        // Vector3 right = Vector3.Cross(Vector3.up, _camera.transform.forward); //no need
        Vector3 right = _camera.transform.right;
        Vector3 forward = Vector3.Cross(right,Vector3.up);
       // Vector3 foward = transform.forward;
       // Vector3 right = _camera.transform.right;
        Vector3 movement = Vector3.zero;

        //movement.x = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        //movement.z = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        movement += right * (Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime);
        movement += forward * (Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime);
        _rigidbody.AddForce(movement, ForceMode.VelocityChange);
    }
}
