using System;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class MobSpawn : MonoBehaviourPunCallbacks
{
    public GameObject mobBox;
    public GameObject mobSpawnArea;
    private PhotonView p_photonView;

    private void Start()
    {
        p_photonView = GetComponent<PhotonView>();
    }

    public void Create()
    {
        p_photonView.RPC("RPC_Create", RpcTarget.AllBuffered);
    }

    [PunRPC]
    private void RPC_Create()
    {
        int countChild = gameObject.transform.childCount;
        int randomChild = UnityEngine.Random.Range(0, countChild);
        var randomCharacter = mobBox.transform.GetChild(randomChild);
        randomCharacter.transform.position = mobSpawnArea.transform.position;
        int spacePosition = randomCharacter.name.LastIndexOf(' ');
        string childName = randomCharacter.name.Substring(0, spacePosition);
        var childObject = randomCharacter.transform.Find(childName);
       // randomCharacter.GetComponent<PhotonView>();
        childObject.GetComponent<SkinnedMeshRenderer>().enabled = true;
    }


}