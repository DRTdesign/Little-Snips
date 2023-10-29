using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject objectToSpawn1, objectToSpawn2, objectToSpawn3;
    public GameObject spawnButton;
    public GameObject HandR;
    private bool canSpawn = true;
    public static bool objOnField;
    public static int ObjectSpawnPicker;
    private Animator anim;
    private Animator animHandR;

    // Start is called before the first frame update
    void Start()
    {
        anim = spawnButton.GetComponent<Animator>();
        animHandR = HandR.GetComponent<Animator>();
        //fireObjectSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("MainCamera").GetComponent<PickUpObj>().spawnButtonLook == true)
        {
            if (objOnField == false)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    fireObjectSpawn();
                }
            } 
        }

        if (canSpawn == true)
        {
            if (ObjectSpawnPicker == 1)
            {
                Instantiate(objectToSpawn1, new Vector3(0,2,5), transform.rotation);
                canSpawn = false;
                anim.SetTrigger("SpawnButtonPress");
            }

            if (objOnField == false)
            {

            }
        }


        if (canSpawn == true)
        {
            if (ObjectSpawnPicker == 2)
            {
                Instantiate(objectToSpawn2, new Vector3(0, 2, 5), transform.rotation);
                canSpawn = false;
                anim.SetTrigger("SpawnButtonPress");
            }
        }

        if (canSpawn == true)
        {
            if (ObjectSpawnPicker == 3)
            {
                Instantiate(objectToSpawn3, new Vector3(0, 2, 5), transform.rotation);
                canSpawn = false;
                anim.SetTrigger("SpawnButtonPress");
            }
        }
    }

    public void fireObjectSpawn()
    {
        animHandR.SetTrigger("PointPressHandR");
        animHandR.SetTrigger("PointPressHandR");
        canSpawn = true;
        objOnField = true;
        ObjectSpawnPicker = Random.Range(1, 4);
        anim.SetTrigger("SpawnButtonPress");
    }
}
