using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartCreate : MonoBehaviourPunCallbacks
{
     public Object[] p_charactersPrefabs;
     [SerializeField] private Transform p_transformMobDefaultSpawnPoint;
     [SerializeField] private Transform p_transformFinalWayPointPoint;


    [System.Obsolete]
    void Start()
    {
        //p_charactersPrefabs = Resources.LoadAll( "", typeof(GameObject));
        foreach (var prefabCharacter in p_charactersPrefabs)
        {
            
            GameObject newObjectCharacter = (GameObject) PhotonNetwork.InstantiateSceneObject(prefabCharacter.name, p_transformMobDefaultSpawnPoint.position,
                p_transformMobDefaultSpawnPoint.rotation);
            
            newObjectCharacter.transform.SetParent(transform);
            int spacePosition = newObjectCharacter.name.LastIndexOf(' ');
            string childName = newObjectCharacter.name.Substring(0, spacePosition);
            var childObject = newObjectCharacter.transform.FindChild(childName);
            childObject.GetComponent<SkinnedMeshRenderer>().enabled = false;

            newObjectCharacter.GetComponent<MobSettings>().transformMobDefaultSpawnPiont = p_transformMobDefaultSpawnPoint;
            newObjectCharacter.GetComponent<MobSettings>().transformFinalWayPoint = p_transformFinalWayPointPoint;        
        }

    }
}
