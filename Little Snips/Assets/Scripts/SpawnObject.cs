using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject objectToSpawn1, objectToSpawn2, objectToSpawn3;
    private bool spawn = true;
    public static int ObjectSpawnPicker;

    // Start is called before the first frame update
    void Start()
    {
        fireObjectSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        //print(spawn);

        if (Input.GetKeyDown(KeyCode.R))
        {
            fireObjectSpawn();
        }

        if(spawn==true)
        {
            if (ObjectSpawnPicker == 1)
            {
                Instantiate(objectToSpawn1, new Vector3(0,2,5), transform.rotation);
                spawn = false;
            }
        }


        if (spawn == true)
        {
            if (ObjectSpawnPicker == 2)
            {
                Instantiate(objectToSpawn2, new Vector3(0, 2, 5), transform.rotation);
                spawn = false;
            }
        }

        if (spawn == true)
        {
            if (ObjectSpawnPicker == 3)
            {
                Instantiate(objectToSpawn3, new Vector3(0, 2, 5), transform.rotation);
                spawn = false;
            }
        }
    }

    public void fireObjectSpawn()
    {
        spawn = true;
        ObjectSpawnPicker = Random.Range(1, 4);
    }
}
