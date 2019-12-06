using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
using UnityNightPool;
using Random = UnityEngine.Random;

public class CreateMob : MonoBehaviour,IPunObservable
{
    private PoolObject _poolObject;
    public string testString;
    public Text textField;
    public void Spawn()
    {
        _poolObject = PoolManager.Get(1);
        testString = "OK";
    }

    private void Start()
    {
        testString = PhotonNetwork.LocalPlayer.NickName;
    }

    private void Update()
    {
        textField.text = testString;
    }

    public void ReturnToPool()
    {
        PoolManager.ReturnPool();
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(testString);
            Debug.Log("writing");
        }
        else
        {
            testString = (string) stream.ReceiveNext();
            
            Debug.Log("reading");
        }
    }
}
