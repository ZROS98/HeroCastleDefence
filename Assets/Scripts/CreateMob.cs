using System;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;
using UnityNightPool;

public class CreateMob : MonoBehaviour
{
    private PoolObject _senderPoolObject;
    private PoolObject _targetPoolObject;
    PhotonView pv_senderPoolObject;
    PhotonView pv_targetPoolObject;
    private PhotonView _photonView;
    public string testString;
    public Text textField;
    

    private void Awake()
    {
        PoolManager.Init();
    }

    private void Start()
    {
        pv_senderPoolObject = _senderPoolObject.gameObject.AddComponent(typeof(PhotonView)) as PhotonView;
        pv_targetPoolObject = _targetPoolObject.gameObject.AddComponent(typeof(PhotonView)) as PhotonView;
        testString = PhotonNetwork.LocalPlayer.NickName;
    }
    private void Update()
    {
        textField.text = testString;
    }
    [PunRPC]
    private void ReturnPoolObject(int senderPool, int targetPool)
    {
        // return _poolObject;
        //_senderPoolObject = PhotonView.Find(senderPool).gameObject.GetComponent<PhotonView>();
        // _targetPoolObject = PhotonView.Find(targetPool);
        PhotonView.Find(senderPool);
    }


    public void Spawn()
    {
        СreateMob();
        _photonView = PhotonView.Get(this);
        if(!_photonView.IsMine) return;
        _photonView.RPC("ReturnPoolObject", RpcTarget.All, _senderPoolObject.gameObject.GetPhotonView().ViewID, _targetPoolObject.gameObject.GetPhotonView().ViewID);
    }
    void СreateMob()
    {
        _senderPoolObject = PoolManager.Get(1);
        testString = "OK";
    }




    public void ReturnToPool()
    {
        ReturnMobToPool();
        if (!_photonView.IsMine) return;
        _photonView.RPC("ReturnPoolObject", RpcTarget.All);
    }
    void ReturnMobToPool()
    {
        PoolManager.ReturnPool();
        testString = "000";
    }

}