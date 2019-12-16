using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class ReturnMob : MonoBehaviourPunCallbacks
{
   public GameObject mobBox;
   [SerializeField] private Transform p_mobDefoltSpawnPoint;
   public void Return()
   {
      int countChild = gameObject.transform.childCount;
      int randomChild = UnityEngine.Random.Range(0, countChild);
      var randomCharacter = mobBox.transform.GetChild(randomChild);
      randomCharacter.transform.position = p_mobDefoltSpawnPoint.transform.position;
      int spacePosition = randomCharacter.name.LastIndexOf(' ');
      string childName = randomCharacter.name.Substring(0, spacePosition);
      var childObject = randomCharacter.transform.Find(childName);
      childObject.GetComponent<SkinnedMeshRenderer>().enabled = false;
   }
}
