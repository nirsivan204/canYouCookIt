using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Cutable : MonoBehaviour
{
    public int cuts_needed = 5;
    private int cuts = 0;
    private bool canBeCut = false;
    public GameObject sliced;
    public GameObject notSliced;
    private AudioSource AS;
    private bool isSliced = false;
    public Transform cuttingBoardAnchor;
    [SerializeField] Vegetables veg;
    private PreparedIng ing;

    // Start is called before the first frame update
    void Start()
    {
        AS = GetComponent<AudioSource>();
        ing = new PreparedIng();

    }
    public PreparedIng getPreparedIng()
    {
        return ing;
    }
    // Update is called once per frame
    void Update()
    {
    }


    public void enableCut()
    {
        if (!isSliced)
        {
            canBeCut = true;
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Knife" && canBeCut)
        {
            cut();
            Invoke("enableCut", 0.5f);
        }
    }

    private void cut()
    {
        cuts++;
        AS.Play();
        if (cuts == cuts_needed)
        {
            isSliced = true;
            replaceMesh();
            ing.setDishType(Dishes.Salad);
            ing.setVegType(veg);
        }
        canBeCut = false;

    }

    private void replaceMesh()
    {
        sliced.SetActive(true);
        notSliced.SetActive(false);
    }
/*
    private void SplitMesh(GameObject go)
    {
        MakeHalf(go, true);
        MakeHalf(go, false);
    }

    private void MakeHalf(GameObject go, bool isLeft)
    {
        float sign = isLeft ? -1 : 1;
        GameObject half = Instantiate(go);
        Cutable CutableScript = half.GetComponent<Cutable>();
        CutableScript.isCut = isLeft;
        CutableScript.part_num++;
        MeshFilter filter = half.GetComponent<MeshFilter>();

        Plane cuttingPlane = GetPlane(go);
        filter.mesh = CloneMesh(cuttingPlane, filter.mesh, isLeft);

        half.transform.position = go.transform.position + transform.rotation * new Vector3(sign * 0.05f, 0, 0);
        half.GetComponent<Rigidbody>().isKinematic = true;
        half.GetComponent<Rigidbody>().useGravity = true;
    }

    private Plane GetPlane(GameObject go)
    {
        Vector3 pt1 = Vector3.right * cut_factor * part_num + transform.localRotation * new Vector3(0, 0, 0);
        Vector3 pt2 =Vector3.right * cut_factor * part_num + transform.localRotation * new Vector3(0, 1, 0);
        Vector3 pt3 = Vector3.right * cut_factor * part_num + transform.localRotation * new Vector3(0.5f, 0, -0.5f);

        Plane rv = new Plane();
        rv.Set3Points(pt1, pt2, pt3);
        return rv;
    }

    private Mesh CloneMesh(Plane p, Mesh oMesh, bool halve)
    {
        Mesh cMesh = new Mesh();
        cMesh.name = "slicedMesh";
        Vector3[] vertices = oMesh.vertices;

        for (int i = 0; i < vertices.Length; i++)
        {
            bool side = p.GetSide(vertices[i]);

            if (side == halve)// && Mathf.Abs(p.GetDistanceToPoint(vertices[i]))>2f)
            {
                print(p.GetDistanceToPoint(vertices[i]));
                vertices[i] = p.ClosestPointOnPlane(vertices[i]);
            }
        }

        cMesh.vertices = vertices;
        cMesh.triangles = oMesh.triangles;
        cMesh.normals = oMesh.normals;
        cMesh.uv = oMesh.uv;
        return cMesh;
    }*/


}
