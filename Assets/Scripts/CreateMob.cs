using System;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class CreateMob : MonoBehaviour
{
    public GameObject[] mobsBox;
    public void Create()
    {
        PhotonNetwork.Instantiate("Mob", transform.position, Quaternion.identity);
    }
}