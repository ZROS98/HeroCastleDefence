using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCreate : MonoBehaviour
{
     private Object[] p_charactersPrefabs;
     [SerializeField] private Transform p_mobDefoltSpawnPoint;

    [System.Obsolete]
    void Start()
    {
        p_charactersPrefabs = Resources.LoadAll("Characters", typeof(GameObject));
        foreach (var prefabCharacter in p_charactersPrefabs)
        {
            GameObject newObjectCharacter = (GameObject) Instantiate(prefabCharacter, p_mobDefoltSpawnPoint.position,
                p_mobDefoltSpawnPoint.rotation);
            newObjectCharacter.transform.SetParent(transform);
            int spacePosition = newObjectCharacter.name.LastIndexOf(' ');
            string childName = newObjectCharacter.name.Substring(0, spacePosition);
            var childObject = newObjectCharacter.transform.FindChild(childName);
            childObject.GetComponent<SkinnedMeshRenderer>().enabled = false;
        }

    }
}
