using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction;
using UnityEngine.XR.Interaction.Toolkit;

public class FireBulletActivate : MonoBehaviour
{
    public GameObject bullet; //object 설정으로 오브젝트 받아줌
    public Transform spawnPoint;//위치 값 위치값 받아줌 
    public float firespeed = 20;
    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        //현재 오브젝트의 컴포넌트 내의 XR Grab Interactable을 grabbable 변수에 할당 (변수처럼 이용하기 위함)
        grabbable.activated.AddListener(FireBullet); 
        //grabbable 안의 activated 이벤트에 Firebullet이라는 함수를 추가하여, 트리거 버튼을 누르면 Firebullet 함수가 실행되게끔 만듦
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FireBullet(ActivateEventArgs arg)
    {
        GameObject spawnedBullet = Instantiate(bullet); //총알을 생성
        spawnedBullet.transform.position = spawnPoint.position;//총알의 스폰포인트 지정
        spawnedBullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * firespeed; //스폰포인트의 앞 방향으로 firespeed만큼 이동
        Destroy(spawnedBullet, 5); //5초 뒤에 파괴
    }
}
