using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHelp1 : MonoBehaviour
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
        if (ScriptHolder.GetComponent<HandPosition>().handIsResting == true)
        {
            helpText.text = "handIsResting = true";
        }

        if (ScriptHolder.GetComponent<HandPosition>().handIsResting != true)
        {
            helpText.text = "handIsResting = false";
        }
    }
}