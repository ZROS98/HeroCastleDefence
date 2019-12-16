using System.Collections;
using System.Collections.Generic;
using System.IO;
using Photon.Pun;
using UnityEngine;

public class PhotonPlayer : MonoBehaviourPunCallbacks
{
    private PhotonView PV;

    public GameObject myAvatar;
    
    void Start()
    {
        PV = GetComponent<PhotonView>();
        int spawnPicker = Random.Range(0, GameSetup.GS.spawnPoints.Length);
        //if (PV.IsMine)
        //{
            PhotonNetwork.Instantiate(myAvatar.name,
                GameSetup.GS.spawnPoints[spawnPicker].position, GameSetup.GS.spawnPoints[spawnPicker].rotation, 0);
        //}
    }
}
