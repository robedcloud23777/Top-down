using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager2 : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab;

    void Start()
    {
        // �÷��̾� ���� ��ġ ���
        Vector3 spawnPosition = GetPlayerSpawnPosition();
        
        // Photon���� ������ �ν��Ͻ�ȭ (Resources ���� �� ��� ���)
        PhotonNetwork.Instantiate("Prefabs/Player", spawnPosition, Quaternion.identity);
    }

    Vector3 GetPlayerSpawnPosition()
    {
        float x = Random.Range(-3f, 3f);  // X��ǥ ���� ����
        float y = Random.Range(-3f, 3f);  // Y��ǥ ���� ����
        return new Vector3(x, y, 0f);  // 2D ���ӿ����� z���� 0���� ����
    }
}
