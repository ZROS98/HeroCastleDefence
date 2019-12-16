using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSettings : MonoBehaviour
{
    public Transform transformMobDefoltSpawnPiont;
    public bool isDefault;

    void Update()
    {
        isDefault = gameObject.transform.position == transformMobDefoltSpawnPiont.position ? true : false;
    }
}
