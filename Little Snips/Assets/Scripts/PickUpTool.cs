using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpTool : MonoBehaviour
{
    public GameObject player;
    public GameObject handL;
    private Animator anim;
    public Transform holdPosL1;
    public Transform holdPosL2;
    public Transform holdPosL3;
    //public float throwForce = 500f; //force at which the object is thrown at
    public float pickUpRange = 20f; //how far the player can pickup the object from
    //private float rotationSensitivity = 1f; //how fast/slow the object is rotated in relation to mouse movement
    private GameObject heldTool; //object which we pick up
    private Rigidbody heldToolRb; //rigidbody of object we pick up
    public bool canDropL = true; //this is needed so we don't throw/drop object when rotating the object
    private int LayerNumber; //layer index
    //private bool objectScaleDownReady = true;
    public GameObject tool1;
    public GameObject tool2;
    public GameObject tool3;
    public bool readyToPickUpTool1 = false;
    public bool readyToPickUpTool2 = false;
    public bool readyToPickUpTool3 = false;
    public bool holdingTool1 = false;
    public bool holdingTool2 = false;
    public bool holdingTool3 = false;

    void Start()
    {
        //LayerNumber = LayerMask.NameToLayer("holdLayer"); //if your holdLayer is named differently make sure to change this ""
        //mouseLookScript = player.GetComponent<MouseLookScript>();
        anim = handL.GetComponent<Animator>();
    }

    void Update()
    {
        //perform raycast to check if player is looking at object within pickuprange
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange))
        {
            if (heldTool == null) //if currently not holding anything
            {
                //make sure pickup tag is attached
                if (hit.transform.gameObject.name == "ToolSlot1")
                {
                    readyToPickUpTool1 = true;

                    if (Input.GetMouseButtonDown(0)) //Left mouse click
                    {
                        //pass in object hit into the PickUpObject function
                        PickUpTool1(hit.transform.gameObject);
                    }
                }

                //make sure pickup tag is attached
                else if (hit.transform.gameObject.name == "ToolSlot2")
                {
                    readyToPickUpTool2 = true;

                    if (Input.GetMouseButtonDown(0)) //Left mouse click
                    {
                        //pass in object hit into the PickUpObject function
                        PickUpTool2(hit.transform.gameObject);
                    }
                }

                //make sure pickup tag is attached
                else if (hit.transform.gameObject.name == "ToolSlot3")
                {
                    readyToPickUpTool3 = true;

                    if (Input.GetMouseButtonDown(0)) //Left mouse click
                    {
                        //pass in object hit into the PickUpObject function
                        PickUpTool3(hit.transform.gameObject);
                    }
                }

                else
                {
                    readyToPickUpTool1 = false;
                    readyToPickUpTool2 = false;
                    readyToPickUpTool3 = false;
                }
            }
            
            else
            {
                readyToPickUpTool1 = false;
                readyToPickUpTool2 = false;
                readyToPickUpTool3 = false;
            }
        }

        if (heldTool != null) //if player is holding object
        {
            heldTool.layer = LayerMask.NameToLayer("Ignore Raycast"); //change tool layer to avoid raycast issues
            
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

    void PickUpTool1(GameObject pickUpObj)
    {
        if (pickUpObj.GetComponent<Rigidbody>()) //make sure the object has a RigidBody
        {
            holdingTool1 = true;
            canDropL = true;
            anim.SetTrigger("CloseHandL");
            //heldTool = pickUpObj; //assign heldObj to the object that was hit by the raycast (no longer == null)
            heldTool = tool1; //assign heldObj to the object that was hit by the raycast (no longer == null)
            heldToolRb = tool1.GetComponent<Rigidbody>(); //assign Rigidbody
            heldToolRb.isKinematic = true;
            heldToolRb.transform.parent = holdPosL1.transform; //parent object to holdposition
            //heldObj.layer = LayerNumber; //change the object layer to the holdLayer
            //make sure object doesnt collide with player, it can cause weird bugs
            Physics.IgnoreCollision(heldTool.GetComponent<Collider>(), player.GetComponent<Collider>(), true);
        }
    }

    void PickUpTool2(GameObject pickUpObj)
    {
        if (pickUpObj.GetComponent<Rigidbody>()) //make sure the object has a RigidBody
        {
            holdingTool2 = true;
            canDropL = true;
            anim.SetTrigger("CloseHandL");
            //heldTool = pickUpObj; //assign heldObj to the object that was hit by the raycast (no longer == null)
            heldTool = tool2; //assign heldObj to the object that was hit by the raycast (no longer == null)
            heldToolRb = tool2.GetComponent<Rigidbody>(); //assign Rigidbody
            heldToolRb.isKinematic = true;
            heldToolRb.transform.parent = holdPosL2.transform; //parent object to holdposition
            //heldObj.layer = LayerNumber; //change the object layer to the holdLayer
            //make sure object doesnt collide with player, it can cause weird bugs
            Physics.IgnoreCollision(heldTool.GetComponent<Collider>(), player.GetComponent<Collider>(), true);
        }
    }

    void PickUpTool3(GameObject pickUpObj)
    {
        if (pickUpObj.GetComponent<Rigidbody>()) //make sure the object has a RigidBody
        {
            holdingTool3 = true;
            canDropL = true;
            anim.SetTrigger("CloseHandL");
            //heldTool = pickUpObj; //assign heldObj to the object that was hit by the raycast (no longer == null)
            heldTool = tool3; //assign heldObj to the object that was hit by the raycast (no longer == null)
            heldToolRb = tool3.GetComponent<Rigidbody>(); //assign Rigidbody
            heldToolRb.isKinematic = true;
            heldToolRb.transform.parent = holdPosL3.transform; //parent object to holdposition
            //heldObj.layer = LayerNumber; //change the object layer to the holdLayer
            //make sure object doesnt collide with player, it can cause weird bugs
            Physics.IgnoreCollision(heldTool.GetComponent<Collider>(), player.GetComponent<Collider>(), true);
        }
    }

    void DropObject()
    {
        if (this.GetComponent<HandPosition>().lookingAt == true)
        {
            holdingTool1 = false;
            holdingTool2 = false;
            holdingTool3 = false;
            //re-enable collision with player
            Physics.IgnoreCollision(heldTool.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
            //heldObj.layer = 0; //object assigned back to default layer
            heldToolRb.isKinematic = false;
            heldTool.transform.parent = null; //unparent object
            heldTool = null; //undefine game object
            //objectScaleDownReady = true;
            //ScaleObjectUp();
            anim.SetTrigger("OpenHandL");
        }
    }

    void MoveObject()
    {
        if (holdingTool1 == true)
        {
            //keep object position the same as the holdPosition position
            heldTool.transform.position = holdPosL1.transform.position;
            heldTool.transform.rotation = holdPosL1.transform.rotation;
        }

        if (holdingTool2 == true)
        {
            //keep object position the same as the holdPosition position
            heldTool.transform.position = holdPosL2.transform.position;
            heldTool.transform.rotation = holdPosL1.transform.rotation;
        }

        if (holdingTool3 == true)
        {
            //keep object position the same as the holdPosition position
            heldTool.transform.position = holdPosL3.transform.position;
            heldTool.transform.rotation = holdPosL1.transform.rotation;
        }
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
