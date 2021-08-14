using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    public GameObject product;
    public Transform InstantiatePos;
    // Start is called before the first frame update
    private void Start()
    {
        create();
    }

    public void create()
    {
        GameObject clone = Instantiate(product,transform);
        clone.transform.position = InstantiatePos.position;
    }
}
