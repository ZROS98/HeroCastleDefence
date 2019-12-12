using System;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class CreateMob : MonoBehaviour
{
    public GameObject mobBox;
    public GameObject mobSpawnArea;
    public void Create()
    {
        int countChild = gameObject.transform.childCount;
        int randomChild = UnityEngine.Random.Range(0, countChild);
        var randomCharacter = mobBox.transform.GetChild(randomChild);
        randomCharacter.transform.position = mobSpawnArea.transform.position;
        int spacePosition = randomCharacter.name.LastIndexOf(' ');
        string childName = randomCharacter.name.Substring(0, spacePosition);
        var childObject = randomCharacter.transform.Find(childName);
        childObject.GetComponent<SkinnedMeshRenderer>().enabled = true;

    }
}