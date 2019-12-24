using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartCreate : MonoBehaviourPunCallbacks
{
    public Object[] p_charactersPrefabs;
    [SerializeField] private Transform p_transformMobDefaultSpawnPoint;
    private Transform p_transformFinalWayPointPoint;

    [System.Obsolete]
    void Start()
    {
        
        foreach (var prefabCharacter in p_charactersPrefabs)
        {
            int spacePosition = prefabCharacter.name.LastIndexOf(' ');
            string childName = prefabCharacter.name.Substring(0, spacePosition);

            GameObject newObjectCharacter = (GameObject) PhotonNetwork.InstantiateSceneObject(prefabCharacter.name, p_transformMobDefaultSpawnPoint.position, Quaternion.identity );

            newObjectCharacter.transform.SetParent(transform);
            var childObject = newObjectCharacter.transform.FindChild(childName);
            childObject.GetComponent<SkinnedMeshRenderer>().enabled = false;
        }
    }
}
