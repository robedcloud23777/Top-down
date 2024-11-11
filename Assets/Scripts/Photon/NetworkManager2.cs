using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager2 : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab;

    void Start()
    {
        // 플레이어 스폰 위치 계산
        Vector3 spawnPosition = GetPlayerSpawnPosition();
        
        // Photon에서 프리팹 인스턴스화 (Resources 폴더 내 경로 사용)
        PhotonNetwork.Instantiate("Prefabs/Player", spawnPosition, Quaternion.identity);
    }

    Vector3 GetPlayerSpawnPosition()
    {
        float x = Random.Range(-3f, 3f);  // X좌표 범위 설정
        float y = Random.Range(-3f, 3f);  // Y좌표 범위 설정
        return new Vector3(x, y, 0f);  // 2D 게임에서는 z값을 0으로 설정
    }
}
