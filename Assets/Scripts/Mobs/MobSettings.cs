using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSettings : MonoBehaviour
{
    public Transform transformMobDefaultSpawnPiont;
    public Transform transformFinalWayPoint;
    public bool isDefault;
    void Update()
    {
        isDefault = gameObject.transform.position == transformMobDefaultSpawnPiont.position ? true : false;
    }
}
