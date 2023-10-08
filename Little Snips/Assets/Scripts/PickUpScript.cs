using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    public GameObject player;
    public GameObject handR;
    private Animator anim;
    public Transform holdPosR;
    public Transform holdPosL;
    public float throwForce = 500f; //force at which the object is thrown at
    public float pickUpRange = 20f; //how far the player can pickup the object from
    //private float rotationSensitivity = 1f; //how fast/slow the object is rotated in relation to mouse movement
    private GameObject heldObj; //object which we pick up
    private Rigidbody heldObjRb; //rigidbody of object we pick up
    public bool canDrop = true; //this is needed so we don't throw/drop object when rotating the object
    private int LayerNumber; //layer index
    //private bool objectScaleDownReady = true;
    public bool readyToPickUp = false;
    public bool holdingObj = false;
    public bool spawnButtonLook = false;

    void Start()
    {
        //LayerNumber = LayerMask.NameToLayer("holdLayer"); //if your holdLayer is named differently make sure to change this ""
        //mouseLookScript = player.GetComponent<MouseLookScript>();
        anim = handR.GetComponent<Animator>();
    }

    void Update()
    {
        //perform raycast to check if player is looking at object within pickuprange
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange))
        {
            if (heldObj == null) //if currently not holding anything
            {
                //make sure pickup tag is attached
                if (hit.transform.gameObject.tag == "canPickUp")
                {
                    readyToPickUp = true;

                    if (Input.GetMouseButtonDown(0)) //Left mouse click
                    {
                        //pass in object hit into the PickUpObject function
                        PickUpObject(hit.transform.gameObject);
                    }
                }

                else
                {
                    readyToPickUp = false;
                }
            }

            //IF LOOKING AT SPAWN BUTTON  (FOR "SPAWN OBJECT" SCRIPT)
            if (hit.transform.gameObject.tag == "spawner")
            {
                spawnButtonLook = true;
            }
            else
            {
                spawnButtonLook = false;
            }
        }

        else
        {
            readyToPickUp = false;

            if (canDrop == true)
            {
                    //dropTrigger = true;
                    //StopClipping(); //prevents object from clipping through walls
                    //DropObject();               
            }
        }

        if (heldObj != null) //if player is holding object
        {
            heldObj.layer = LayerMask.NameToLayer("Ignore Raycast");
            MoveObject(); //keep object position at holdPosR

            if (Input.GetMouseButtonDown(0) && canDrop == true)
            {
                DropObject();
            }

            //RotateObject();
            //if (Input.GetMouseButtonDown(1) && canDrop == true) //Right click to throw
            //{
            //    StopClipping();
            //    //ThrowObject(); << TO TURN OBJECT THORWING BACK ON
            //}

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
            holdingObj = true;
            canDrop = true;
            //handR.GetComponent<Animator>();
            anim.SetTrigger("CloseHandR");
            heldObj = pickUpObj; //assign heldObj to the object that was hit by the raycast (no longer == null)
            heldObjRb = pickUpObj.GetComponent<Rigidbody>(); //assign Rigidbody
            heldObjRb.isKinematic = true;
            heldObjRb.transform.parent = holdPosR.transform; //parent object to holdposition
            //heldObj.layer = LayerNumber; //change the object layer to the holdLayer
            //make sure object doesnt collide with player, it can cause weird bugs
            Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), true);
        }
    }

    void DropObject()
    {
        if (this.GetComponent<HandPosition>().lookingAt == true)
        {
            holdingObj = false;
            //re-enable collision with player
            Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
            //heldObj.layer = 0; //object assigned back to default layer
            heldObjRb.isKinematic = false;
            heldObj.transform.parent = null; //unparent object
            heldObj = null; //undefine game object
            //objectScaleDownReady = true;
            //ScaleObjectUp();
            anim.SetTrigger("OpenHandR");
        }
    }

    void MoveObject()
    {
        //keep object position the same as the holdPosition position
        heldObj.transform.position = holdPosR.transform.position;
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

    //void RotateObject()
    //{
    //    if (Input.GetKey(KeyCode.R))//hold R key to rotate, change this to whatever key you want
    //    {
    //        canDrop = false; //make sure throwing can't occur during rotating

    //        //disable player being able to look around
    //        //mouseLookScript.verticalSensitivity = 0f;
    //        //mouseLookScript.lateralSensitivity = 0f;

    //        float XaxisRotation = Input.GetAxis("Mouse X") * rotationSensitivity;
    //        float YaxisRotation = Input.GetAxis("Mouse Y") * rotationSensitivity;
    //        //rotate the object depending on mouse X-Y Axis
    //        heldObj.transform.Rotate(Vector3.down, XaxisRotation);
    //        heldObj.transform.Rotate(Vector3.right, YaxisRotation);
    //    }
    //    else
    //    {
    //        //re-enable player being able to look around
    //        //mouseLookScript.verticalSensitivity = originalvalue;
    //        //mouseLookScript.lateralSensitivity = originalvalue;
    //        canDrop = true;
    //    }
    //}

    //void ThrowObject()
    //{
    //    //same as drop function, but add force to object before undefining it
    //    Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
    //    //heldObj.layer = 0;
    //    heldObjRb.isKinematic = false;
    //    heldObj.transform.parent = null;
    //    heldObjRb.AddForce(transform.forward * throwForce);
    //    heldObj = null;
    //    objectScaleDownReady = true;
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
