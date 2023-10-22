using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPosition : MonoBehaviour
{
    public GameObject rightHand;
    public GameObject leftHand;

    //Hands resting positions and rotations
    public Transform handRestPositionR;
    public Transform handRestPositionL;

    //Right hand positions and rotations
    public Transform handObjGrabPosition;
    public Transform boxPlaceHand1;
    public Transform boxPlaceHand2;
    public Transform boxPlaceHand3;
    public Transform handReachPositionR;

    //Left hand positions and rotations
    public Transform handTool1GrabPosition;
    public Transform handTool2GrabPosition;
    public Transform handTool3GrabPosition;
    public Transform handReachPositionL;

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
        RaycastHit hit;
        //Code for putting right hand over a box and for putting left hand over a tool
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, lookAtRange))
        {
            if (GameObject.Find("MainCamera").GetComponent<PickUpObj>().holdingObj == true)
            {
                if (hit.transform.gameObject.tag == "boxLookAt1")
                {
                    LookAtBox1(hit.transform.gameObject);
                    lookingAt = true;
                }

                else if (hit.transform.gameObject.tag == "boxLookAt2")
                {
                    LookAtBox2(hit.transform.gameObject);
                    lookingAt = true;
                }

                else if (hit.transform.gameObject.tag == "boxLookAt3")
                {
                    LookAtBox3(hit.transform.gameObject);
                    lookingAt = true;
                }
            }

            else
            {
                lookingAt = false;
            }
        }

        else
        {
            lookingAt = false;
        }

        if (lookingAt == false)
        {
            rightHand.transform.position = handRestPositionR.transform.position;
            rightHand.transform.rotation = handRestPositionR.transform.rotation;
        }

        //if player is looking at grabbable object and conditions are met to pick that object up
        if (GameObject.Find("MainCamera").GetComponent<PickUpObj>().readyToPickUp == true)
        {
            rightHand.transform.position = handObjGrabPosition.transform.position;
            rightHand.transform.rotation = handObjGrabPosition.transform.rotation;
        }

        //if player is looking at grabbable tool 1 and conditions are met to pick that tool up
        if (GameObject.Find("MainCamera").GetComponent<PickUpTool>().readyToPickUpTool1 == true)
        {
            leftHand.transform.position = handTool1GrabPosition.transform.position;
            leftHand.transform.rotation = handTool1GrabPosition.transform.rotation;
        }

        //if player is looking at grabbable tool 2 and conditions are met to pick that tool up
        if (GameObject.Find("MainCamera").GetComponent<PickUpTool>().readyToPickUpTool2 == true)
        {
            leftHand.transform.position = handTool2GrabPosition.transform.position;
            leftHand.transform.rotation = handTool2GrabPosition.transform.rotation;
        }

        //if player is looking at grabbable tool 3 and conditions are met to pick that tool up
        if (GameObject.Find("MainCamera").GetComponent<PickUpTool>().readyToPickUpTool3 == true)
        {
            leftHand.transform.position = handTool3GrabPosition.transform.position;
            leftHand.transform.rotation = handTool3GrabPosition.transform.rotation;
        }

        //if player is looking at tool slot while holding tool, hand indicates it can be put back
        if (GameObject.Find("MainCamera").GetComponent<PickUpTool>().readyToDropTool1 
            || GameObject.Find("MainCamera").GetComponent<PickUpTool>().readyToDropTool2 
            || GameObject.Find("MainCamera").GetComponent<PickUpTool>().readyToDropTool3 == true)
            {
                leftHand.transform.position = handReachPositionL.transform.position;
                leftHand.transform.rotation = handReachPositionL.transform.rotation;
            }

        //if not looking at any tool slots, put hand back to resting position
        else if (GameObject.Find("MainCamera").GetComponent<PickUpTool>().readyToPickUpTool1 == false
            && GameObject.Find("MainCamera").GetComponent<PickUpTool>().readyToPickUpTool2 == false
            && GameObject.Find("MainCamera").GetComponent<PickUpTool>().readyToPickUpTool3 == false)
            {
                leftHand.transform.position = handRestPositionL.transform.position;
                leftHand.transform.rotation = handRestPositionL.transform.rotation;
            }

        //if player is looking at spawn button and conditions are met to press it
        if (GameObject.Find("MainCamera").GetComponent<PickUpObj>().spawnButtonLook == true)
        {
            rightHand.transform.position = handReachPositionR.transform.position;
            rightHand.transform.rotation = handReachPositionR.transform.rotation;
        }
    }

    void LookAtBox1(GameObject pickUpObj)
    {
        rightHand.transform.position = boxPlaceHand1.transform.position;
        rightHand.transform.rotation = boxPlaceHand1.transform.rotation;
    }

    void LookAtBox2(GameObject pickUpObj)
    {
        rightHand.transform.position = boxPlaceHand2.transform.position;
        rightHand.transform.rotation = boxPlaceHand2.transform.rotation;
    }

    void LookAtBox3(GameObject pickUpObj)
    {
        rightHand.transform.position = boxPlaceHand3.transform.position;
        rightHand.transform.rotation = boxPlaceHand3.transform.rotation;
    }
}
