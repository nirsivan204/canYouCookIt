using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cookable : MonoBehaviour
{
    public GameObject uncooked;
    public GameObject cooked;
    public GameObject preparedForCooking;
    public GameObject burned;
    private Rigidbody rb;
    private Collider col;
    public bool canBeRemoved;
    [SerializeField] private float neededCookingTime;
    private float timeUntilCooked;
    private bool isCooking = false;
    private bool isCooked = false;
    private bool isBurned = false;
    private float timeToBurn = 3;
    private GameObject currentMesh;

    private void Start()
    {
        timeUntilCooked = neededCookingTime;
        currentMesh = uncooked;
    }
    public void prepareForCooking()
    {
        col = GetComponent<Collider>();
        col.enabled = false;
        if (!isCooked)
        {
            replaceMesh(preparedForCooking);
        }
    }

    private void Update()
    {
        if (isCooking)
        {
            timeUntilCooked -= Time.deltaTime;
            if (timeUntilCooked < 0)
            {
                canBeRemoved = true;
                isCooked = true;
                replaceMesh(cooked);
            }
            if(timeUntilCooked < -timeToBurn)
            {
                startBurn();
            }
        }
    }

    private void startBurn()
    {
        replaceMesh(burned);
    }


    public void startCooking()
    {
        canBeRemoved = false;
        isCooking = true;
    }

    public void stopCooking()
    {
        isCooking = false;
    }

    public bool isCanBeRemoved()
    {
        return canBeRemoved;
    }

    private void replaceMesh(GameObject newMesh)
    {
        currentMesh.SetActive(false);
        newMesh.SetActive(true);
        currentMesh = newMesh;
    }
}
