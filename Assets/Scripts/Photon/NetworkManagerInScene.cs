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

        PhotonNetwork.AutomaticallySyncScene = true; // �� �ڵ� ����ȭ Ȱ��ȭ
        CreatePlayer(); // �÷��̾ ���� �� Player ������Ʈ�� ����
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreatePlayer()
    {
        // �÷��̾� ���� ��ġ ���
        Vector3 spawnPosition1 = spawnPoint1.transform.position;
        Vector3 spawnPosition2 = spawnPoint2.transform.position;
        if (PhotonNetwork.IsMasterClient)
        {
            Debug.Log("������ ����");
            // Photon���� ������ �ν��Ͻ�ȭ (Resources ���� �� ��� ���)
            PhotonNetwork.Instantiate("Character", spawnPosition1, Quaternion.identity);
        }
        else
        {
            PhotonNetwork.Instantiate("Character", spawnPosition2, Quaternion.identity);
        }
    }
}
