using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
using JetBrains.Annotations;

public class ActivateTeleportationRay : MonoBehaviour
{

    public GameObject leftTeleportation; //������Ʈ ���� 
    public GameObject rightTeleportation; //������Ʈ ����

    public InputActionProperty leftActivate; 
    public InputActionProperty rightActivate;

    public InputActionProperty leftCancel;
    public InputActionProperty rightCancel;

    public XRRayInteractor leftRay;
    public XRRayInteractor rightRay;

    // Update is called once per frame
    void Update() 
    {
        bool isLeftRayHovering = leftRay.TryGetHitInfo(out Vector3 leftpos, out Vector3 leftnormal, out int leftNumber, out bool leftvalid);
        bool isRightRayHovering = rightRay.TryGetHitInfo(out Vector3 rightpos, out Vector3 rightnormal, out int rightNumber, out bool rightvalid);
        //ray�� hit�� ����� world position, normal vector,position in linePoints�� �޾Ƽ� ��ü�� ������ true���� �������ִ� �Լ�

        //� ���� ������ teleportation�� Ȱ��ȭ ��Ű�� ��ɾ�
        leftTeleportation.SetActive(!isLeftRayHovering && leftCancel.action.ReadValue<float>() == 0 && leftActivate.action.ReadValue<float>() > 0.1f); ;
        //leftray�� ���մ� ���°� �ƴϰ� ���� �׷� ��ư�� �Է°��� 0�̰� ���� Ʈ���� ��ư�� ���� 0.1f���� ũ�ٸ� ���� �ڷ���Ʈ ���� Ȱ��ȭ
        rightTeleportation.SetActive(!isRightRayHovering && rightCancel.action.ReadValue<float>() == 0 && rightActivate.action.ReadValue<float>() > 0.1f);
    }
}
