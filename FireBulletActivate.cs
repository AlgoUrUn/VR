using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction;
using UnityEngine.XR.Interaction.Toolkit;

public class FireBulletActivate : MonoBehaviour
{
    public GameObject bullet; //object �������� ������Ʈ �޾���
    public Transform spawnPoint;//��ġ �� ��ġ�� �޾��� 
    public float firespeed = 20;
    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        //���� ������Ʈ�� ������Ʈ ���� XR Grab Interactable�� grabbable ������ �Ҵ� (����ó�� �̿��ϱ� ����)
        grabbable.activated.AddListener(FireBullet); 
        //grabbable ���� activated �̺�Ʈ�� Firebullet�̶�� �Լ��� �߰��Ͽ�, Ʈ���� ��ư�� ������ Firebullet �Լ��� ����ǰԲ� ����
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FireBullet(ActivateEventArgs arg)
    {
        GameObject spawnedBullet = Instantiate(bullet); //�Ѿ��� ����
        spawnedBullet.transform.position = spawnPoint.position;//�Ѿ��� ��������Ʈ ����
        spawnedBullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * firespeed; //��������Ʈ�� �� �������� firespeed��ŭ �̵�
        Destroy(spawnedBullet, 5); //5�� �ڿ� �ı�
    }
}
