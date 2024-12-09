using UnityEngine;
using Photon.Pun;

public class SyncAllObjects : MonoBehaviour
{
    void Start()
    {
        // ���̾��Ű�� ��� ������Ʈ ��������
        foreach (Transform child in transform)
        {
            if (child.GetComponent<PhotonView>() == null)
            {
                // PhotonView �߰�
                PhotonView photonView = child.gameObject.AddComponent<PhotonView>();

                // TransformView �߰� �� ����
                PhotonTransformView transformView = child.gameObject.AddComponent<PhotonTransformView>();
                photonView.ObservedComponents = new System.Collections.Generic.List<Component> { transformView };

                // ����ȭ �ɼ� ����
                transformView.m_SynchronizePosition = true;
                transformView.m_SynchronizeRotation = true;
                transformView.m_SynchronizeScale = true;
            }
        }
    }
}
