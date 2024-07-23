using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
using JetBrains.Annotations;

public class ActivateTeleportationRay : MonoBehaviour
{

    public GameObject leftTeleportation; //오브젝트 지정 
    public GameObject rightTeleportation; //오브젝트 지정

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
        //ray가 hit이 생기면 world position, normal vector,position in linePoints을 받아서 물체에 맞으면 true값을 리턴해주는 함수

        //어떤 값을 받으면 teleportation을 활성화 시키는 명령어
        leftTeleportation.SetActive(!isLeftRayHovering && leftCancel.action.ReadValue<float>() == 0 && leftActivate.action.ReadValue<float>() > 0.1f); ;
        //leftray가 떠잇는 상태가 아니고 왼쪽 그랩 버튼의 입력값이 0이고 왼쪽 트리거 버튼의 값이 0.1f보다 크다면 왼쪽 텔레포트 광선 활성화
        rightTeleportation.SetActive(!isRightRayHovering && rightCancel.action.ReadValue<float>() == 0 && rightActivate.action.ReadValue<float>() > 0.1f);
    }
}
