using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    public List<GameObject> Trees = new List<GameObject>();

    private int GroundLenght=250;
    void Start()
    {
        Invoke("TreeSpawn", 0);
    }
    public void TreeSpawn()
    {
        for(int i = 0;i<=2000;i++)
        {
            int PosX = Random.Range(-GroundLenght, GroundLenght);
            int PosZ = Random.Range(-GroundLenght, GroundLenght);
            int RandomTree = Random.Range(0, Trees.Count);
            Instantiate<GameObject>(Trees[RandomTree], new Vector3(PosX,0,PosZ), Quaternion.identity);
        }       
    }
}
