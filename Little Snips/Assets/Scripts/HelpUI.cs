using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class helpUI : MonoBehaviour
{
    private Text helpText;
    public GameObject MainCamera;

    // Start is called before the first frame update
    void Start()
    {
        helpText = GetComponent<Text>();
        MainCamera = GetComponent<PickUpScript>();
    }

    // Update is called once per frame
    void Update()
    {
        helpText.text = "boop";
        helpText.text = MainCamera.PickUpScript.readyToPickUp;
        //helpText.text = GameObject.Find("MainCamera").GetComponent<PickUpScript>().readyToPickUp;
        //helpText.text = GameObject.Find("MainCamera").GetComponent<HandPosition>().lookingAt;
    }
}
