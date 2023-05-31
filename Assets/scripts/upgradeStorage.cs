using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgradeStorage : MonoBehaviour
{
    public GameObject chest;
    public GameObject backpack;

    public int maxChest = 6;
    public int maxBackpack = 3;
    public int chestNum = 0;
    public int backpackNum = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        chestNum = chest.transform.childCount;
        backpackNum = backpack.transform.childCount;
    }
}
