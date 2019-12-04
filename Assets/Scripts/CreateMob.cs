using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.PlayerLoop;
using UnityNightPool;
using Random = UnityEngine.Random;

public class CreateMob : MonoBehaviour
{
    public void Spawn()
    {
        PoolObject platform = PoolManager.Get(1);
    }

    public void ReturnToPool()
    {
        PoolManager.ReturnPool();
    }

}
