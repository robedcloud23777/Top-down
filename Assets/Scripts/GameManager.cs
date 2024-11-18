using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;

public class GameManager : MonoBehaviourPunCallbacks
{
    public GameObject scanObject;
    public bool isAciton;

    void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true; // 씬 자동 동기화 활성화
        CreatePlayer(); // 플레이어가 입장 시 자동으로 Player 오브젝트를 생성
    }

    public void Action(GameObject scanObj)
    {
        scanObject = scanObj;
        ObjectData objectData = scanObj.GetComponent<ObjectData>();
    }

    Vector3 GetPlayerSpawnPosition()
    {
        float x = Random.Range(-3f, 3f);  // X좌표 범위 설정
        float y = Random.Range(-3f, 3f);  // Y좌표 범위 설정
        return new Vector3(x, y, 0f);  // 2D 게임에서는 z값을 0으로 설정
    }

    private void CreatePlayer()
    {
        // 플레이어 스폰 위치 계산
        Vector3 spawnPosition = GetPlayerSpawnPosition();

        // Photon에서 프리팹 인스턴스화 (Resources 폴더 내 경로 사용)
        PhotonNetwork.Instantiate("Player", spawnPosition, Quaternion.identity);
    }
}
