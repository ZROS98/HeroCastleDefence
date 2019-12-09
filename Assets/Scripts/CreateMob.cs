using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;
using UnityNightPool;

public class CreateMob : MonoBehaviour
{
    private PoolObject _poolObject;
    private PhotonView _photonView;
    public string testString;
    public Text textField;
    private void Start()
    {
          //_photonView = GetComponent<PhotonView>();
          testString = PhotonNetwork.LocalPlayer.NickName;
    }  
    
    private void Update()
    {
        textField.text = testString;
    }
    public void Spawn()
    {
        RPC_CreateMob();
        _photonView = PhotonView.Get(this);
        if(!_photonView.IsMine) return;
        _photonView.RPC("ReturnPoolObject", RpcTarget.All);
    }

    [PunRPC]
    private PoolObject ReturnPoolObject()
    {
        return _poolObject;
    }
    public void ReturnToPool()
    {
        //if(!_photonView.IsMine) return;
        _photonView.RPC("ReturnReturnedPoolObject", RpcTarget.All);
    }

    [PunRPC]
    private PoolObject ReturnReturnedPoolObject()
    {
        PoolManager.ReturnPool();
        return _poolObject;
    }
    
    [PunRPC]
    void RPC_CreateMob()
    {
        _poolObject = PoolManager.Get(1);
        testString = "OK";
    }

    [PunRPC]
    void RPC_ReturnMobToPool()
    { 
        PoolManager.ReturnPool();
        testString = "000";
    }

//    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
//    {
//        if (stream.IsWriting)
//        {
//            stream.SendNext(testString);
//            Debug.Log("writing");
//        }
//        else
//        {
//            testString = (string) stream.ReceiveNext();
//            
//            Debug.Log("reading");
//        }
//    }

}
