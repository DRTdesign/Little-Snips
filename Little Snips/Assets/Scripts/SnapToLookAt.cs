using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject rightHand;
    public GameObject leftHand;
    public Transform handRestPositionR;
    public Transform handRestPositionL;
    public Transform handRestRotationR;
    public Transform handRestRotationL;
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
        if (lookingAt == false)
        {
            rightHand.transform.position = handRestPositionR.transform.position;
            rightHand.transform.rotation = handRestPositionR.transform.rotation;
        }

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, lookAtRange) 
            && hit.transform.gameObject.tag == "boxLookAt1")
        {
            LookAtObject1(hit.transform.gameObject);
            lookingAt = true;
        }

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, lookAtRange)
            && hit.transform.gameObject.tag == "boxLookAt2")
        {
            LookAtObject2(hit.transform.gameObject);
            lookingAt = true;
        }

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, lookAtRange)
            && hit.transform.gameObject.tag == "boxLookAt3")
        {
            LookAtObject3(hit.transform.gameObject);
            lookingAt = true;
        }

        else
        {
            lookingAt = false;
        }
    }

    void LookAtObject1(GameObject pickUpObj)
    {
        rightHand.transform.position = boxPlaceHand1.transform.position;
        rightHand.transform.rotation = boxPlaceHand1.transform.rotation;
        //rightHand.transform.eulerAngles = new Vector3(0, 120, 0);
    }

    void LookAtObject2(GameObject pickUpObj)
    {
        rightHand.transform.position = boxPlaceHand2.transform.position;
        rightHand.transform.rotation = boxPlaceHand2.transform.rotation;
        //rightHand.transform.eulerAngles = new Vector3(0, 120, 0);
    }

    void LookAtObject3(GameObject pickUpObj)
    {
        rightHand.transform.position = boxPlaceHand3.transform.position;
        rightHand.transform.rotation = boxPlaceHand3.transform.rotation;
        //rightHand.transform.eulerAngles = new Vector3(0, 120, 0);
    }
}
