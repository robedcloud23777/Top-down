using HappyHarvest;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManagerInScene : MonoBehaviourPunCallbacks
{
    private GameObject spawnPoint1;
    private GameObject spawnPoint2;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoint1 = GameObject.Find("SpawnPoint1");
        spawnPoint2 = GameObject.Find("SpawnPoint2");

        PhotonNetwork.AutomaticallySyncScene = true; // 씬 자동 동기화 활성화
        CreatePlayer(); // 플레이어가 입장 시 Player 오브젝트를 생성
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreatePlayer()
    {
        // 플레이어 스폰 위치 계산
        Vector3 spawnPosition1 = spawnPoint1.transform.position;
        Vector3 spawnPosition2 = spawnPoint2.transform.position;
        if (PhotonNetwork.IsMasterClient)
        {
            Debug.Log("마스터 입장");
            // Photon에서 프리팹 인스턴스화 (Resources 폴더 내 경로 사용)
            PhotonNetwork.Instantiate("Character", spawnPosition1, Quaternion.identity);
        }
        else
        {
            PhotonNetwork.Instantiate("Character", spawnPosition2, Quaternion.identity);
        }
    }
}
