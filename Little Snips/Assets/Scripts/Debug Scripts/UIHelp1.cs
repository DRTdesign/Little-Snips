using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHelp1 : MonoBehaviour
{
    private Text helpText;
    public GameObject MainCamera;
    //turn these bools off and on to show text without clashes
    private bool ReadyToPickUp = true;
    //private bool CanDrop = false;
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

        if(ReadyToPickUp == true)
        {
            if (MainCamera.GetComponent<PickUpObj>().readyToPickUp == true)
            {
                helpText.text = "ReadyToPickUp = True";
            }

            if (MainCamera.GetComponent<PickUpObj>().readyToPickUp != true)
            {
                helpText.text = "ReadyToPickUp = False";
            }
        }
    }
}