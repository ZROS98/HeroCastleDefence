using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartCreate : MonoBehaviourPunCallbacks
{
    public Object[] p_charactersPrefabs;
    private Transform p_transformMobDefaultSpawnPoint;
    private Transform p_transformFinalWayPointPoint;
    private Dictionary<string, Dictionary<string, GameObject>> dictionaryRegister;

    [System.Obsolete]
    void Start()
    {
        //p_charactersPrefabs = Resources.LoadAll( "", typeof(GameObject));
        foreach (var prefabCharacter in p_charactersPrefabs)
        {
            int spacePosition = prefabCharacter.name.LastIndexOf(' ');
            string childName = prefabCharacter.name.Substring(0, spacePosition);

            GameObject newObjectCharacter = (GameObject) PhotonNetwork.InstantiateSceneObject(prefabCharacter.name, p_transformMobDefaultSpawnPoint.position,
                p_transformMobDefaultSpawnPoint.rotation);
     //       CreateMobsDictionarys(childName, newObjectCharacter);

            newObjectCharacter.transform.SetParent(transform);
            var childObject = newObjectCharacter.transform.FindChild(childName);
            childObject.GetComponent<SkinnedMeshRenderer>().enabled = false;

//            newObjectCharacter.GetComponent<MobSettings>().transformMobDefaultSpawnPiont = p_transformMobDefaultSpawnPoint;
//            newObjectCharacter.GetComponent<MobSettings>().transformFinalWayPoint = p_transformFinalWayPointPoint;        
        }

    }

    private void CreateMobsDictionarys(string dictionaryName, GameObject mob)
    {
        if (dictionaryRegister.ContainsKey("Dictionary_"+dictionaryName))
        {
            dictionaryRegister["Dictionary_" + dictionaryName].Add(dictionaryName, mob);
        }
        else
        {
            dictionaryRegister.Add("Dictionary_" + dictionaryName, new Dictionary<string, GameObject>());
        }
    }
}
