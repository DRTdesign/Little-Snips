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
        if (ScriptHolder.GetComponent<PickUpTool>().readyToPickUpTool2 == true)
        {
            helpText.text = "readyToPickUpTool2 = true";
        }

        if (ScriptHolder.GetComponent<PickUpTool>().readyToPickUpTool2 != true)
        {
            helpText.text = "readyToPickUpTool2 = false";
        }
    }
}