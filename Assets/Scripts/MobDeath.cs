using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobDeath : MonoBehaviour
{
    public HeroInfo heroInfo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision other)
    {
        if (GameObject.FindWithTag("Sword").GetComponent<Collider>() == other.collider)
        {
            if (!heroInfo.isHeated){
                Debug.Log("Heated"+ heroInfo.isHeated);
            }
            heroInfo.isHeated = true;
        }
        
    }
}
