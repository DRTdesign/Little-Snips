using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHelp2 : MonoBehaviour
{
    private Text helpText;
    public GameObject MainCamera;
    //turn these bools off and on to show text without clashes
    //private bool ReadyToPickUp = false;
    private bool CanDrop = true;
    //private bool LookingAt = false;

    // Start is called before the first frame update
    void Start()
    {
        helpText = GetComponent<Text>();
        //MainCamera = GetComponent<PickUpScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //helpText.text = "boop";

        if (CanDrop == true)
        {
            if (MainCamera.GetComponent<PickUpObj>().canDropR == true)
            {
                helpText.text = "CanDrop = True";
            }

            if (MainCamera.GetComponent<PickUpObj>().canDropR != true)
            {
                helpText.text = "CanDrop = False";
            }
        }

        //if (CanDrop == true)
        //{
        //    if (MainCamera.GetComponent<PickUpScript>().dropTrigger == true)
        //    {
        //        helpText.text = "dropTrigger = True";
        //    }

        //    if (MainCamera.GetComponent<PickUpScript>().dropTrigger != true)
        //    {
        //        helpText.text = "dropTrigger = False";
        //    }
        //}
    }
}