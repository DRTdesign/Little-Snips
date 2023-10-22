using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject objectToSpawn1, objectToSpawn2, objectToSpawn3;
    public GameObject spawnButton;
    private bool spawn = true;
    public static int ObjectSpawnPicker;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = spawnButton.GetComponent<Animator>();
        //fireObjectSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("MainCamera").GetComponent<PickUpObj>().spawnButtonLook == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                fireObjectSpawn();
            }                        
        }

        if (spawn==true)
        {
            if (ObjectSpawnPicker == 1)
            {
                Instantiate(objectToSpawn1, new Vector3(0.2f,2,5), transform.rotation);
                spawn = false;
                anim.SetTrigger("SpawnButtonPress");
            }
        }


        if (spawn == true)
        {
            if (ObjectSpawnPicker == 2)
            {
                Instantiate(objectToSpawn2, new Vector3(0.2f, 2, 5), transform.rotation);
                spawn = false;
                anim.SetTrigger("SpawnButtonPress");
            }
        }

        if (spawn == true)
        {
            if (ObjectSpawnPicker == 3)
            {
                Instantiate(objectToSpawn3, new Vector3(0.2f, 2, 5), transform.rotation);
                spawn = false;
                anim.SetTrigger("SpawnButtonPress");
            }
        }
    }

    public void fireObjectSpawn()
    {
        spawn = true;
        ObjectSpawnPicker = Random.Range(1, 4);
        anim.SetTrigger("SpawnButtonPress");
    }
}
