using System.Collections.Generic;
using UnityEngine;


/*
* CREDIT: https://github.com/hugoscurti/mesh-cutter
* MIT License
*
* Copyright (c) 2019 Hugo Scurti
*
* Permission is hereby granted, free of charge, to any person obtaining a copy
* of this software and associated documentation files (the "Software"), to deal
* in the Software without restriction, including without limitation the rights
* to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
* copies of the Software, and to permit persons to whom the Software is
* furnished to do so, subject to the following conditions:
*
* The above copyright notice and this permission notice shall be included in all
* copies or substantial portions of the Software.
*
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
* IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
* FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
* AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
* LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
* OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
* SOFTWARE.
*/

public class SliceManager : MonoBehaviour {

    public Transform ObjectContainer;

    // How far away from the slice do we separate resulting objects
    public float separation;

    // Do we draw a plane object associated with the slice
    private Plane slicePlane = new Plane();

    private MeshCutter meshCutter;
    private TempMesh biggerMesh, smallerMesh;

    public GameObject StartSword;
    public GameObject EndSword;

    public Material InsideMat;


    void Start () {
        meshCutter = new MeshCutter(256);
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Slicing: " + other.gameObject.name);
        Vector3 depth = StartSword.transform.position;
        var planeTangent = (EndSword.transform.position - StartSword.transform.position).normalized;

        if (planeTangent == Vector3.zero)
            planeTangent = Vector3.right;

        var normalVec = Vector3.Cross(depth, planeTangent);

        SliceObjects(StartSword.transform.position, normalVec);
    }
    

    void SliceObjects(Vector3 point, Vector3 normal)
    {
        var toSlice = GameObject.FindGameObjectsWithTag("Sliceable");

        // Put results in positive and negative array so that we separate all meshes if there was a cut made
        List<Transform> positive = new List<Transform>(),
            negative = new List<Transform>();

        GameObject obj;
        bool slicedAny = false;
        for (int i = 0; i < toSlice.Length; ++i)
        {
            obj = toSlice[i];
            // We multiply by the inverse transpose of the worldToLocal Matrix, a.k.a the transpose of the localToWorld Matrix
            // Since this is how normal are transformed
            var transformedNormal = ((Vector3)(obj.transform.localToWorldMatrix.transpose * normal)).normalized;

            //Convert plane in object's local frame
            slicePlane.SetNormalAndPosition(
                transformedNormal,
                obj.transform.InverseTransformPoint(point));

            slicedAny = SliceObject(ref slicePlane, obj, positive, negative) || slicedAny;
        }

        // Separate meshes if a slice was made
        if (slicedAny)
            SeparateMeshes(positive, negative, normal);
    }

    bool SliceObject(ref Plane slicePlane, GameObject obj, List<Transform> positiveObjects, List<Transform> negativeObjects)
    {
        var mesh = obj.GetComponent<MeshFilter>().mesh;

        if (!meshCutter.SliceMesh(mesh, ref slicePlane))
        {
            if (slicePlane.GetDistanceToPoint(meshCutter.GetFirstVertex()) >= 0)
                positiveObjects.Add(obj.transform);
            else
                negativeObjects.Add(obj.transform);

            return false;
        }

        bool posBigger = meshCutter.PositiveMesh.surfacearea > meshCutter.NegativeMesh.surfacearea;
        if (posBigger)
        {
            biggerMesh = meshCutter.PositiveMesh;
            smallerMesh = meshCutter.NegativeMesh;
        }
        else
        {
            biggerMesh = meshCutter.NegativeMesh;
            smallerMesh = meshCutter.PositiveMesh;
        }

        // Create new Sliced object with the other mesh
        GameObject newObject = Instantiate(obj, ObjectContainer);
        newObject.transform.SetPositionAndRotation(obj.transform.position, obj.transform.rotation);
        var newObjMesh = newObject.GetComponent<MeshFilter>().mesh;


        ReplaceMesh(mesh, biggerMesh);
        ReplaceMesh(newObjMesh, smallerMesh);

        (posBigger ? positiveObjects : negativeObjects).Add(obj.transform);
        (posBigger ? negativeObjects : positiveObjects).Add(newObject.transform);

        return true;
    }

    void ReplaceMesh(Mesh mesh, TempMesh tempMesh, MeshCollider collider = null)
    {
        mesh.Clear();
        mesh.SetVertices(tempMesh.vertices);
        mesh.SetTriangles(tempMesh.triangles, 0);
        mesh.SetNormals(tempMesh.normals);
        mesh.SetUVs(0, tempMesh.uvs);
        mesh.RecalculateNormals();
        mesh.RecalculateTangents();

        if (collider != null && collider.enabled)
        {
            collider.sharedMesh = mesh;
            collider.convex = true;
        }
    }
    void SeparateMeshes(List<Transform> positives, List<Transform> negatives, Vector3 worldPlaneNormal)
    {
        int i;
        var separationVector = worldPlaneNormal * separation;

        for(i = 0; i <positives.Count; ++i)
            positives[i].transform.position += separationVector;

        for (i = 0; i < negatives.Count; ++i)
            negatives[i].transform.position -= separationVector;
    }
}
