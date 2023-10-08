using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHelp3 : MonoBehaviour
{
    private Text helpText;
    public GameObject MainCamera;
    //turn these bools off and on to show text without clashes
    //private bool ReadyToPickUp = false;
    //private bool CanDrop = false;
    private bool LookingAt = true;

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

        if (LookingAt == true)
        {
            if (MainCamera.GetComponent<HandPosition>().lookingAt == true)
            {
                helpText.text = "LookingAt = True";
            }

            if (MainCamera.GetComponent<HandPosition>().lookingAt != true)
            {
                helpText.text = "LookingAt = False";
            }
        }
    }
}