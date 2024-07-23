using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRGrabInteractableTwoAttach : XRGrabInteractable //XRGrabInteractable을 확장하여 코드 작성할 수 있음
{
    public Transform leftAttachTransform;
    public Transform rightAttachTransform;

    public override Transform GetAttachTransform(IXRInteractor interactor)
    {
        Debug.Log("GetAttachTransform");

        Transform i_attachTransform = null;
        if (interactor.transform.CompareTag("Left Hand")) //interactor와 interactable과 혼동 조심
                                                          //Left Hand라는 태그를 가지고 있는 interactableObject의 transform이 감지되면
        {
            i_attachTransform = leftAttachTransform; //attachTransform = leftAttachTransform이된다.
        }
        else if (interactor.transform.CompareTag("Right Hand"))
        {
            i_attachTransform = rightAttachTransform;

        }

        return i_attachTransform != null ? i_attachTransform : base.GetAttachTransform(interactor);
        //i_attachTransform이 값을 받으면 왼손과 오른손을 구분해서 attachpoint 출력
    }
}