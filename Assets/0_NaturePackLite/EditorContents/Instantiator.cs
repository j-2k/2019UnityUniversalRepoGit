using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviour
{
    public GameObject tree;
    public GameObject grass;
    public GameObject rock;
    public GameObject mushroom;
    public Transform cam;

    void Update()
    {
        
    }

    public void spawnTree()
    {
        Instantiate(tree, cam.position + new Vector3(0, -2, 5), Quaternion.identity);
    }

    public void spawnGrass()
    {
        Instantiate(grass, cam.position + new Vector3(0, -2, 5), Quaternion.identity);
    }

    public void spawnRock()
    {
        Instantiate(rock, cam.position + new Vector3(0, -2, 5), Quaternion.identity);
    }

    public void spawnMushroom()
    {
        Instantiate(mushroom, cam.position + new Vector3(0, -2, 5), Quaternion.identity);
    }
}
