using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickUpTool : MonoBehaviour
{
    public GameObject player;
    public GameObject handL;
    private Animator anim;
    public Transform holdPosL1;
    public Transform holdPosL2;
    public Transform holdPosL3;
    public Transform toolRestPlace1;
    public Transform toolRestPlace2;
    public Transform toolRestPlace3;
    public float pickUpRange = 20f; //how far the player can pickup the object from
    private GameObject heldTool; //object which we pick up
    private Rigidbody heldToolRb; //rigidbody of object we pick up
    private int LayerNumber; //layer index
    public GameObject tool1;
    public GameObject tool2;
    public GameObject tool3;
    public bool readyToPickUpTool1 = false;
    public bool readyToPickUpTool2 = false;
    public bool readyToPickUpTool3 = false;
    public bool readyToDropTool1 = false;
    public bool readyToDropTool2 = false;
    public bool readyToDropTool3 = false;
    public bool holdingTool1 = false;
    public bool holdingTool2 = false;
    public bool holdingTool3 = false;
    public bool holdingAnyTool = false;

    void Start()
    {
        //LayerNumber = LayerMask.NameToLayer("holdLayer"); //if your holdLayer is named differently make sure to change this ""
        //mouseLookScript = player.GetComponent<MouseLookScript>();
        anim = handL.GetComponent<Animator>();

        //Setting All Tools To Their Resting Positions
        tool1.transform.position = toolRestPlace1.transform.position;
        tool1.transform.rotation = toolRestPlace1.transform.rotation;
        tool2.transform.position = toolRestPlace2.transform.position;
        tool2.transform.rotation = toolRestPlace2.transform.rotation;
        tool3.transform.position = toolRestPlace3.transform.position;
        tool3.transform.rotation = toolRestPlace3.transform.rotation;
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
                }

                //make sure pickup tag is attached
                else if (hit.transform.gameObject.name == "ToolSlot2")
                {
                    readyToPickUpTool2 = true;
                }

                //make sure pickup tag is attached
                else if (hit.transform.gameObject.name == "ToolSlot3")
                {
                    readyToPickUpTool3 = true;
                }

                else
                {
                    readyToPickUpTool1 = false;
                    readyToPickUpTool2 = false;
                    readyToPickUpTool3 = false;
                    anim.SetBool("GrabHandL", false);
                }
            }
            
            else
            {
                readyToPickUpTool1 = false;
                readyToPickUpTool2 = false;
                readyToPickUpTool3 = false;
                anim.SetBool("GrabHandL", false);
            }

            if (heldTool != null) //if currently holding a tool...
            {
                //make sure pickup tag is attached
                if (hit.transform.gameObject.name == "ToolSlot1") //...and looking at tool slot 1...
                {
                    if (holdingTool1 == true) //...and holding Tool 1
                    {
                        readyToDropTool1 = true;
                    }
                }

                //make sure pickup tag is attached
                else if (hit.transform.gameObject.name == "ToolSlot2") //...and looking at tool slot 2...
                {
                    if (holdingTool2 == true)  //...and holding Tool 2
                    {
                        readyToDropTool2 = true;
                    }
                }

                //make sure pickup tag is attached
                else if (hit.transform.gameObject.name == "ToolSlot3") //...and looking at tool slot 3...
                {
                    if (holdingTool3 == true) //...and holding Tool 3
                    {
                        readyToDropTool3 = true;
                    }
                }

                else
                {
                    readyToDropTool1 = false;
                    readyToDropTool2 = false;
                    readyToDropTool3 = false;
                }
            }

            else
            {
                readyToDropTool1 = false;
                readyToDropTool2 = false;
                readyToDropTool3 = false;
            }
        }

        // [ LEFT CLICK - Picking Up and Putting Down Tools ]

        if (readyToPickUpTool1 == true)
        {
            anim.SetBool("GrabHandL", true);

            if (Input.GetMouseButtonDown(0)) //Left mouse click
            {
                //pass in object hit into the PickUpObject function
                PickUpTool1(hit.transform.gameObject);
            }
        }

        if (readyToDropTool1 == true)
        {
            if (Input.GetMouseButtonDown(0)) //Left mouse click
            {
                holdingTool1 = false;
                DropTool1();
            }
        }

        if (readyToPickUpTool2 == true)
        {
            anim.SetBool("GrabHandL", true);

            if (Input.GetMouseButtonDown(0)) //Left mouse click
            {
                //pass in object hit into the PickUpObject function
                PickUpTool2(hit.transform.gameObject);
            }
        }

        if (readyToDropTool2 == true)
        {
            if (Input.GetMouseButtonDown(0)) //Left mouse click
            {
                holdingTool2 = false;
                DropTool2();
            }
        }

        if (readyToPickUpTool3 == true)
        {
            anim.SetBool("GrabHandL", true);

            if (Input.GetMouseButtonDown(0)) //Left mouse click
            {
                //pass in object hit into the PickUpObject function
                PickUpTool3(hit.transform.gameObject);
            }
        }

        if (readyToDropTool3 == true)
        {
            if (Input.GetMouseButtonDown(0)) //Left mouse click
            {
                holdingTool3 = false;
                DropTool3();
            }
        }

        //else
        //{
        //    anim.SetBool("GrabHandL", false);
        //}

        if (heldTool != null) //if player is holding a tool
        {
            holdingAnyTool = true;

            if (readyToDropTool1 == false)
            {
                heldTool.layer = LayerMask.NameToLayer("Ignore Raycast"); //change tool layer to avoid raycast issues
                MoveObject(); //keep object position at holdPosL
            }
        }

        if (heldTool == null) //if player isn't holding a tool
        {
            holdingAnyTool = false;
        }

        // [ SHOW IN DEBUG WHAT RAYCAST IS HITTING ]
        //print(hit.collider.gameObject.name);
    }

    void PickUpTool1(GameObject pickUpObj)
    {
        if (pickUpObj.GetComponent<Rigidbody>()) //make sure the object has a RigidBody
        {
            holdingTool1 = true;
            anim.SetTrigger("CloseHandL");
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
            anim.SetTrigger("CloseHandL");
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
            anim.SetTrigger("CloseHandL");
            heldTool = tool3; //assign heldObj to the object that was hit by the raycast (no longer == null)
            heldToolRb = tool3.GetComponent<Rigidbody>(); //assign Rigidbody
            heldToolRb.isKinematic = true;
            heldToolRb.transform.parent = holdPosL3.transform; //parent object to holdposition
            //heldObj.layer = LayerNumber; //change the object layer to the holdLayer
            //make sure object doesnt collide with player, it can cause weird bugs
            Physics.IgnoreCollision(heldTool.GetComponent<Collider>(), player.GetComponent<Collider>(), true);
        }
    }

    void DropTool1()
    {
        heldToolRb.isKinematic = false;
        heldTool.transform.parent = null; //unparent object
        heldTool = null; //undefine game object
        tool1.transform.position = toolRestPlace1.transform.position;
        tool1.transform.rotation = toolRestPlace1.transform.rotation;
        anim.SetTrigger("OpenHandL");
    }

    void DropTool2()
    {
        heldToolRb.isKinematic = false;
        heldTool.transform.parent = null; //unparent object
        heldTool = null; //undefine game object
        tool2.transform.position = toolRestPlace2.transform.position;
        tool2.transform.rotation = toolRestPlace2.transform.rotation;
        anim.SetTrigger("OpenHandL");
    }

    void DropTool3()
    {
        heldToolRb.isKinematic = false;
        heldTool.transform.parent = null; //unparent object
        heldTool = null; //undefine game object
        tool3.transform.position = toolRestPlace3.transform.position;
        tool3.transform.rotation = toolRestPlace3.transform.rotation;
        anim.SetTrigger("OpenHandL");
    }

    void MoveObject()
    {
        if (holdingTool1 == true)
        {
            //keep object position the same as the holdPosition position
            heldTool.transform.position = holdPosL1.transform.position;
            heldTool.transform.rotation = holdPosL1.transform.rotation;
        }

        else if (holdingTool2 == true)
        {
            //keep object position the same as the holdPosition position
            heldTool.transform.position = holdPosL2.transform.position;
            heldTool.transform.rotation = holdPosL2.transform.rotation;
        }

        else if (holdingTool3 == true)
        {
            //keep object position the same as the holdPosition position
            heldTool.transform.position = holdPosL3.transform.position;
            heldTool.transform.rotation = holdPosL3.transform.rotation;
        }
    }
}
