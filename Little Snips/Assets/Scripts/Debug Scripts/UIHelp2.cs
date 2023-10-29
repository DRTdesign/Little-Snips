using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHelp2 : MonoBehaviour
{
    private Text helpText;
    public GameObject ScriptHolder;

    // Start is called before the first frame update
    void Start()
    {
        helpText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ScriptHolder.GetComponent<PickUpObj>().readyToPickUp == true)
        {
            helpText.text = "readyToPickUp = true";
        }

        if (ScriptHolder.GetComponent<PickUpObj>().readyToPickUp != true)
        {
            helpText.text = "readyToPickUp = false";
        }
    }
}