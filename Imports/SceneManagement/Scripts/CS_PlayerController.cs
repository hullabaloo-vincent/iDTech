using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_PlayerController : MonoBehaviour
{
    //
    // Summary:
    //      Uncomment and the gameobject with this script will not be destroyed
    //      on new level load.
    /*void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }*/
    
    void Start()
    {
        // Gets a reference to the player's rigidbody compoonent.
        _Rd = GetComponent<Rigidbody>();
    }
    public void Update()
    {   // Get horizontal and vertical axis value
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        // Turn horizonal and vertical axis values into a Vector3
        Vector3 tempVect = new Vector3(h, 0, v);
        // Normalize the values (value becomes something between 0 and 1), multiply it by
        // a speed value (ForceAmount), and multiply that by the time between the current and previous frame (Time.deltaTime)
        tempVect = tempVect.normalized * ForceAmount * Time.deltaTime;
        // Add the new Vector3 movement value to the current player position to simulate movement.
        _Rd.MovePosition(transform.position + tempVect);
    }

    private Rigidbody _Rd;
    public float ForceAmount = 20f;
}
