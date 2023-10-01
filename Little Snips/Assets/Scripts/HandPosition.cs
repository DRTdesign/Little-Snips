using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPosition : MonoBehaviour
{
    public GameObject rightHand;
    public GameObject leftHand;
    public Transform handRestPositionR;
    public Transform handRestRotationR;
    public Transform handRestPositionL;
    public Transform handRestRotationL;
    public Transform handGrabPositionR;
    public Transform handGrabRotationR;
    public Transform handGrabPositionL;
    public Transform handGrabRotationL;
    public Transform boxPlaceHand1;
    public Transform boxPlaceHand2;
    public Transform boxPlaceHand3;
    public float lookAtRange = 5f; //how far the player can pickup the object from
    public bool lookingAt;

    // Start is called before the first frame update
    void Start()
    {
        lookingAt = false;
    }

    // Update is called once per frame
    void Update()
    {
        //print (lookingAt);

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, lookAtRange))
        {
            if (hit.transform.gameObject.tag == "boxLookAt1")
            {
                LookAtObject1(hit.transform.gameObject);
                lookingAt = true;
            }

            else if (hit.transform.gameObject.tag == "boxLookAt2")
            {
                LookAtObject2(hit.transform.gameObject);
                lookingAt = true;
            }

            else if (hit.transform.gameObject.tag == "boxLookAt3")
            {
                LookAtObject3(hit.transform.gameObject);
                lookingAt = true;
            }

            //if inside the Raycast if statement, only the last box in the list works
            //if outside the Raycast if statement, all boxes work but the hand doesn't return properly
                //because it's casting a ray and hitting any object (within range)
            else
            {
                lookingAt = false;
            }
        }

        if (lookingAt == false)
        {
            rightHand.transform.position = handRestPositionR.transform.position;
            rightHand.transform.rotation = handRestPositionR.transform.rotation;
        }


        if (GameObject.Find("MainCamera").GetComponent<PickUpScript>().readyToPickUp == true)
        {
            rightHand.transform.position = handGrabPositionR.transform.position;
            rightHand.transform.rotation = handGrabPositionR.transform.rotation;
        }
    }

    void LookAtObject1(GameObject pickUpObj)
    {
        rightHand.transform.position = boxPlaceHand1.transform.position;
        rightHand.transform.rotation = boxPlaceHand1.transform.rotation;
    }

    void LookAtObject2(GameObject pickUpObj)
    {
        rightHand.transform.position = boxPlaceHand2.transform.position;
        rightHand.transform.rotation = boxPlaceHand2.transform.rotation;
    }

    void LookAtObject3(GameObject pickUpObj)
    {
        rightHand.transform.position = boxPlaceHand3.transform.position;
        rightHand.transform.rotation = boxPlaceHand3.transform.rotation;
    }
}
