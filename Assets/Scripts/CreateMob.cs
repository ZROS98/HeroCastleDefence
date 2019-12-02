using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.Networking;
using Random = UnityEngine.Random;

public class CreateMob : MonoBehaviour
{
    private PhotonView _photonView;
    public GameObject prefab;



    public void Spawn()
    {
        Vector3 randomPosition = new Vector3(Random.Range(-5, 0), Random.Range(-5, 5));
        //Instantiate(prefab, randomPosition, Quaternion.identity);
        PhotonNetwork.Instantiate(prefab.name, randomPosition, Quaternion.identity);
    }
}
