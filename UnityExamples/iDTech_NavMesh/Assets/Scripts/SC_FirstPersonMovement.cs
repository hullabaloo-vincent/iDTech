using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_FirstPersonMovement : MonoBehaviour
{
    private void Start()
    {
        _LayerMask = LayerMask.GetMask("Movement");
    }
    
    private void Update()
    {
        //Detect if left mouse button is clicked.
        if (Input.GetMouseButtonDown(0) && !_CanRotate && !_CanMove)
        {
            _CanRotate = true;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // hit will hold all the Raycast collision data
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, _LayerMask))
            {
                GetMousePosition();
                StartCoroutine("RotationBuffer");
            }
        }

        if (_CanMove)
        {
            Move();
        }
        if (_CanRotate)
        {
            Rotate();
        }
    }

    private void Rotate()
    {
        Vector3 lookPos = _SelectedPosition;

        Vector3 targetDirection = _SelectedPosition - transform.position;

        float singleStep = _ROTATIONDAMPING * Time.deltaTime;

        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

        transform.rotation = Quaternion.LookRotation(newDirection.normalized);
    }
    private void Move()
    {
        Vector3 newMovement = new Vector3(transform.forward.x, 0, transform.forward.z);
        transform.position += newMovement * Speed * Time.deltaTime;
    }
    private void GetMousePosition()
    {
        /*
        * Creates a ray from the mouse position. Converts the computer screen xy coordinates to be translated to the dimensions
        * of the main camera.
        */
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // hit will hold all the Raycast collision data
        RaycastHit hit;

        // Draw raycast, send hit data to "hit", make the ray draw to infinity, and only return collision data from the "Ground" layer.
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, _LayerMask))
        {
            // Get transform data from where the raycast hit.
            Vector3 lookPos = hit.point;
            // Set an external Vector3 variable to the hit transform value.
            _SelectedPosition = hit.point;
        }
    }

    IEnumerator Movement()
    {
        yield return new WaitForSeconds(1f);
        _CanMove = false;
        yield return 0;
    }
    IEnumerator RotationBuffer()
    {
        yield return new WaitForSeconds(0.5f);
        _CanMove = true;
        _CanRotate = false;
        StartCoroutine("Movement");
        yield return 0;
    }

    public float Speed = 2f;

    private Vector3 _SelectedPosition;
    private bool _CanMove = false;
    private bool _CanRotate = false;
    private int _LayerMask;
    const float _ROTATIONDAMPING = 5.5f;
}