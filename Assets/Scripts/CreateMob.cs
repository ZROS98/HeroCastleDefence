using System;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class CreateMob : MonoBehaviourPunCallbacks
{
    public GameObject mobBox;
    public GameObject mobSpawnArea;
    private PhotonView p_photonView;

    public void Create()
    {
        int countChild = gameObject.transform.childCount;
        int randomChild = UnityEngine.Random.Range(0, countChild);
        var randomCharacter = mobBox.transform.GetChild(randomChild);
        randomCharacter.transform.position = mobSpawnArea.transform.position;
        int spacePosition = randomCharacter.name.LastIndexOf(' ');
        string childName = randomCharacter.name.Substring(0, spacePosition);
        var childObject = randomCharacter.transform.Find(childName);
        randomCharacter.GetComponent<PhotonView>();
        childObject.GetComponent<SkinnedMeshRenderer>().enabled = true;
    }
    
    
}