using UnityEngine;
using Photon.Pun;

public class SyncAllObjects : MonoBehaviour
{
    void Start()
    {
        // 하이어라키의 모든 오브젝트 가져오기
        foreach (Transform child in transform)
        {
            if (child.GetComponent<PhotonView>() == null)
            {
                // PhotonView 추가
                PhotonView photonView = child.gameObject.AddComponent<PhotonView>();

                // TransformView 추가 및 설정
                PhotonTransformView transformView = child.gameObject.AddComponent<PhotonTransformView>();
                photonView.ObservedComponents = new System.Collections.Generic.List<Component> { transformView };

                // 동기화 옵션 설정
                transformView.m_SynchronizePosition = true;
                transformView.m_SynchronizeRotation = true;
                transformView.m_SynchronizeScale = true;
            }
        }
    }
}
