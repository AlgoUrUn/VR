using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;


//platform rigidbody의 is kinematic 체크 필수
public class MovingPlatform : MonoBehaviour
{
    public float speed;
    public Transform p1; //시작 지점
    public Transform p2; //끝 지점
    public Rigidbody rb; //플랫폼 바디
    public GameObject Player;

    private Vector3 targetPosition;
    void Start()
    {
        targetPosition = p1.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 direction = (targetPosition - rb.position).normalized;
        rb.MovePosition(rb.position + speed * direction * Time.fixedDeltaTime); 

        if(Vector3.Distance(rb.position, targetPosition) < 0.05f)
        {
            if(targetPosition == p1.position)
            {
                targetPosition = p2.position;
            }
            else
            {
                targetPosition = p1.position;
            }
        }
    }

    //collider에 캐릭터가 올라가면 플레이어의 위치의 부모를 플랫폼으로 설정 해주는 코드
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            Debug.Log("Player entered platform trigger");
            Player.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
        {
            Debug.Log("Player exited platform trigger");
            Player.transform.SetParent(null);
        }
    }

}
