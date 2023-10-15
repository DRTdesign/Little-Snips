using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpTool : MonoBehaviour
{
    public GameObject player;
    public GameObject handL;
    private Animator anim;
    public Transform holdPosL;
    //public float throwForce = 500f; //force at which the object is thrown at
    public float pickUpRange = 20f; //how far the player can pickup the object from
    //private float rotationSensitivity = 1f; //how fast/slow the object is rotated in relation to mouse movement
    private GameObject heldTool; //object which we pick up
    private Rigidbody heldToolRb; //rigidbody of object we pick up
    public bool canDropL = true; //this is needed so we don't throw/drop object when rotating the object
    private int LayerNumber; //layer index
    //private bool objectScaleDownReady = true;
    public bool readyToPickUpTool1 = false;
    public bool readyToPickUpTool2 = false;
    public bool readyToPickUpTool3 = false;
    public bool holdingTool = false;

    void Start()
    {
        //LayerNumber = LayerMask.NameToLayer("holdLayer"); //if your holdLayer is named differently make sure to change this ""
        //mouseLookScript = player.GetComponent<MouseLookScript>();
        anim = handL.GetComponent<Animator>();
    }

    void Update()
    {
        print(readyToPickUpTool2);

        //perform raycast to check if player is looking at object within pickuprange
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange))
        {
            if (heldTool == null) //if currently not holding anything
            {
                //make sure pickup tag is attached
                if (hit.transform.gameObject.tag == "tool1")
                {
                    readyToPickUpTool1 = true;

                    if (Input.GetMouseButtonDown(0)) //Left mouse click
                    {
                        //pass in object hit into the PickUpObject function
                        PickUpObject(hit.transform.gameObject);
                    }
                }

                //make sure pickup tag is attached
                else if (hit.transform.gameObject.tag == "tool2")
                {
                    readyToPickUpTool2 = true;

                    if (Input.GetMouseButtonDown(0)) //Left mouse click
                    {
                        //pass in object hit into the PickUpObject function
                        PickUpObject(hit.transform.gameObject);
                    }
                }

                //make sure pickup tag is attached
                else if (hit.transform.gameObject.tag == "tool3")
                {
                    readyToPickUpTool3 = true;

                    if (Input.GetMouseButtonDown(0)) //Left mouse click
                    {
                        //pass in object hit into the PickUpObject function
                        PickUpObject(hit.transform.gameObject);
                    }
                }

                else
                {
                    readyToPickUpTool1 = false;
                    readyToPickUpTool2 = false;
                    readyToPickUpTool3 = false;
                }
            }
        }

        else
        {
            readyToPickUpTool1 = false;
            readyToPickUpTool2 = false;
            readyToPickUpTool3 = false;

            //if (canDropL == true)
            //{
            //dropTrigger = true;
            //StopClipping(); //prevents object from clipping through walls
            //DropObject();               
            //}
        }

        if (heldTool != null) //if player is holding object
        {
            heldTool.layer = LayerMask.NameToLayer("Ignore Raycast");
            MoveObject(); //keep object position at holdPosL

            if (Input.GetMouseButtonDown(0) && canDropL == true)
            {
                DropObject();
            }

            //if (objectScaleDownReady == true)
            //{
            //    ScaleObjectDown();
            //}
        }
    }

    void PickUpObject(GameObject pickUpObj)
    {
        if (pickUpObj.GetComponent<Rigidbody>()) //make sure the object has a RigidBody
        {
            holdingTool = true;
            canDropL = true;
            anim.SetTrigger("CloseHandL");
            heldTool = pickUpObj; //assign heldObj to the object that was hit by the raycast (no longer == null)
            heldToolRb = pickUpObj.GetComponent<Rigidbody>(); //assign Rigidbody
            heldToolRb.isKinematic = true;
            heldToolRb.transform.parent = holdPosL.transform; //parent object to holdposition
            //heldObj.layer = LayerNumber; //change the object layer to the holdLayer
            //make sure object doesnt collide with player, it can cause weird bugs
            Physics.IgnoreCollision(heldTool.GetComponent<Collider>(), player.GetComponent<Collider>(), true);
        }
    }

    void DropObject()
    {
        if (this.GetComponent<HandPosition>().lookingAt == true)
        {
            holdingTool = false;
            //re-enable collision with player
            Physics.IgnoreCollision(heldTool.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
            //heldObj.layer = 0; //object assigned back to default layer
            heldToolRb.isKinematic = false;
            heldTool.transform.parent = null; //unparent object
            heldTool = null; //undefine game object
            //objectScaleDownReady = true;
            //ScaleObjectUp();
            anim.SetTrigger("OpenHandR");
        }
    }

    void MoveObject()
    {
        //keep object position the same as the holdPosition position
        heldTool.transform.position = holdPosL.transform.position;
    }

    //void ScaleObjectDown()
    //{
    //    heldObj.transform.localScale = (heldObj.transform.localScale) / 2;
    //    objectScaleDownReady = false;
    //}

    //void ScaleObjectUp()
    //{
    //heldObj.transform.localScale = (heldObj.transform.localScale) * 2;
    //objectScaleDownReady = true;
    //}

    //void StopClipping() //function only called when dropping/throwing
    //{
    //    var clipRange = Vector3.Distance(heldObj.transform.position, transform.position); //distance from holdPos to the camera
    //    //have to use RaycastAll as object blocks raycast in center screen
    //    //RaycastAll returns array of all colliders hit within the cliprange
    //    RaycastHit[] hits;
    //    hits = Physics.RaycastAll(transform.position, transform.TransformDirection(Vector3.forward), clipRange);
    //    //if the array length is greater than 1, meaning it has hit more than just the object we are carrying
    //    if (hits.Length > 1)
    //    {
    //        //change object position to camera position 
    //        heldObj.transform.position = transform.position + new Vector3(0f, -0.5f, 0f); //offset slightly downward to stop object dropping above player 
    //        //if your player is small, change the -0.5f to a smaller number (in magnitude) ie: -0.1f
    //    }
    //}
}
