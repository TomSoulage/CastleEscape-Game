using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{    
    private void Awake()
    {
      GameObject.FindGameObjectWithTag("MainPlayer").transform.position = transform.position;  
      
    }
}
