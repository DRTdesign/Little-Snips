using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    private GameObject ObjectSpawner;

    void Start()
    {
        ObjectSpawner = GameObject.Find("ObjectSpawner");
    }

    void OnTriggerEnter(Collider other)
    {
        //BOX 1
        if (this.gameObject.name == "Box 1 Inside")
        {
            if (other.gameObject.name == "Body Part 1(Clone)")
            {
                Destroy(other.gameObject);
                ScoreTracker.scoreAmount += ScoreTracker.scoreAdd;
                ObjectSpawner.GetComponent<SpawnObject>().fireObjectSpawn();
            }
        }

        if (this.gameObject.name == "Box 1 Inside")
        {
            if (other.gameObject.name != "Body Part 1(Clone)")
            {
                Destroy(other.gameObject);
                ScoreTracker.scoreAmount -= ScoreTracker.scoreSubtract;
                ObjectSpawner.GetComponent<SpawnObject>().fireObjectSpawn();
            }
        }

        //BOX 2
        if (this.gameObject.name == "Box 2 Inside")
        {
            if (other.gameObject.name == "Body Part 2(Clone)")
            {
                Destroy(other.gameObject);
                ScoreTracker.scoreAmount += ScoreTracker.scoreAdd;
                ObjectSpawner.GetComponent<SpawnObject>().fireObjectSpawn();
            }
        }

        if (this.gameObject.name == "Box 2 Inside")
        {
            if (other.gameObject.name != "Body Part 2(Clone)")
            {
                Destroy(other.gameObject);
                ScoreTracker.scoreAmount -= ScoreTracker.scoreSubtract;
                ObjectSpawner.GetComponent<SpawnObject>().fireObjectSpawn();
            }
        }

        //BOX 3
        if (this.gameObject.name == "Box 3 Inside")
        {
            if (other.gameObject.name == "Body Part 3(Clone)")
            {
                Destroy(other.gameObject);
                ScoreTracker.scoreAmount += ScoreTracker.scoreAdd;
                ObjectSpawner.GetComponent<SpawnObject>().fireObjectSpawn();
            }
        }

        if (this.gameObject.name == "Box 3 Inside")
        {
            if (other.gameObject.name != "Body Part 3(Clone)")
            {
                Destroy(other.gameObject);
                ScoreTracker.scoreAmount -= ScoreTracker.scoreSubtract;
                ObjectSpawner.GetComponent<SpawnObject>().fireObjectSpawn();
            }
        }
    }
}
