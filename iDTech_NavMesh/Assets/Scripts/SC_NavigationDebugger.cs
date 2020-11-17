using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SC_NavigationDebugger : MonoBehaviour {
    
    private void Start() {
        // Get the NavMeshAgent component attached to the GameObject the script is attached to
        _DebugAgent = gameObject.GetComponent<NavMeshAgent>();
        // Get the LineRenderer component attached to the GameObject the script is attached to
        _LineRenderer = GetComponent<LineRenderer>();
    }
    private void Update() {
        // If the agent has an active set destination
        if (_DebugAgent.hasPath) {
            // Get the corners ("waypoints") of the current path
            _LineRenderer.positionCount = _DebugAgent.path.corners.Length;
            // Draw between the corners
            _LineRenderer.SetPositions(_DebugAgent.path.corners);
            // Make sure LineRenderer is active
            _LineRenderer.enabled = true;
        } else {
            // Turn of LineRenderer because there is no active paths
            _LineRenderer.enabled = false;
        }
    }

    //
    // Summary:
    //      This holds the NavMeshAgent component. It will be assigned in Start()    
    private NavMeshAgent _DebugAgent;
    //
    // Summary:
    //     This holds the LineRenderer component. It will be assigned in Start()    
    private LineRenderer _LineRenderer;
}
