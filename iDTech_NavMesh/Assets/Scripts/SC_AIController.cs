using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SC_AIController : MonoBehaviour {

    private void Start(){
        // Populates the _Enemies array with all GameObjects with the tag "Enemy".
        _Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        // Initiate NavMeshAgent List
        _EnemyNavMeshes = new List<NavMeshAgent>();
        //Get all enemy NavMeshAgent components and add them to the _EnemyNavMeshes.
        foreach (GameObject enemy in _Enemies) {
            _EnemyNavMeshes.Add(enemy.GetComponent<NavMeshAgent>());
        }
    }
    private void Update() {
        //Get current world position of mouse.
         GetMousePosition();

         //Detect if left mouse button is clicked.
         if (Input.GetMouseButtonDown(0)) {
             MoveAI();
         }
     }

    //
    // Summary:
    //      Gets the current world position of mouse.   
     private void GetMousePosition(){
         /*
         * Creates a ray from the mouse position. Converts the computer screen xy coordinates to be translated to the dimensions
         * of the main camera.
         */
         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
         // hit will hold all the Raycast collision data
         RaycastHit hit;
         //Filter out all Game in other layers
         int layerMask = LayerMask.GetMask("Ground");
         
         // Draw raycast, send hit data to "hit", make the ray draw to infinity, and only return collision data from the "Ground" layer.
         if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask)) {
             // Get transform data from where the raycast hit.
            Vector3 lookPos = hit.point;
             // Set an external Vector3 variable to the hit transform value.
            _SelectedPosition = hit.point;
             // Visualize the raycast hit by moving the mouse pointer prefab position to it.
            _MousePointer.transform.position = lookPos;
        }
     }
    //
    // Summary:
    //      Called from left mouse click. Sets AI destinaion to the current position the mouse was over on click.   
     private void MoveAI() {
         foreach (NavMeshAgent enemy in _EnemyNavMeshes) {
             enemy.SetDestination(_SelectedPosition);
         }
     }

    //
    // Summary:
    //      Holds mouse pointer prefab.
     public GameObject _MousePointer;

    //
    // Summary:
    //      An array of all enemy GameObjects.
     private GameObject[] _Enemies;
    //
    // Summary:
    //      A list that will be populated with the NavMeshAgent components of the contents of _Enemies.
     private List<NavMeshAgent> _EnemyNavMeshes;

    //
    // Summary:
    //      Holds the current world position of mouse. Accessible to all other methods in class. 
     private Vector3 _SelectedPosition;
}
