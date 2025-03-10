using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class NetworkPlayer : NetworkBehaviour
{
    public MoveCapsule movecapsule;
    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();

        movecapsule.enabled = IsOwner;

    }
}