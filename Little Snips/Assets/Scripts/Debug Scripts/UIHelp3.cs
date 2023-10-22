using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHelp3 : MonoBehaviour
{
    private Text helpText;
    public GameObject MainCamera;

    // Start is called before the first frame update
    void Start()
    {
        helpText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MainCamera.GetComponent<PickUpTool>().holdingTool1 == true)
        {
            helpText.text = "holdingTool1 = True";
        }

        if (MainCamera.GetComponent<PickUpTool>().holdingTool1 != true)
        {
            helpText.text = "holdingTool1 = False";
        }
    }
}