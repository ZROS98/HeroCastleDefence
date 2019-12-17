using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobArray : MonoBehaviour
{
    public GameObject[] mobNinjaArray, mobWomanArray;

    private void Start()
    {
        mobNinjaArray = GameObject.FindGameObjectsWithTag("MobNinja");
        mobWomanArray = GameObject.FindGameObjectsWithTag("MobWoman");
    }
}
