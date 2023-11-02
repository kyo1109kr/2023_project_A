using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 1.0f; //적 이동속도
    public float speedMod = 1.0f;
    public float timeSinceStart = 0.0f;

    private MonsterPath theParh; //패스정보 값
    private int currentpoint; //패스 위치 커서값
    private bool reachedEnd; //도달 완료검사 bool값

    private bool modEnd = true;


    void Start()
    {
        if(theParh == null)    //시작할때 Path가 없으면
        {
            theParh = FindObjectOfType<MonsterPath>(); //Scene에서 찾는다.
        }
    }

    void Update()
    {
        if(modEnd == false)
        {
            timeSinceStart -= Time.deltaTime;

            if(timeSinceStart <= 0.0f)
            {
                speedMod = 1.0f;
                modEnd = true;
            }
        }


        if (reachedEnd == false)  //도달 완료가 아닐경우
        {
            transform.LookAt(theParh.points[currentpoint]); //지금 위치 커서값을 향해서 본다.

            transform.position = Vector3.MoveTowards(transform.position
                , theParh.points[currentpoint].position, moveSpeed * Time.deltaTime * speedMod);

            //나와 패스 포인트 위치의 거리를 계산해서 0.01 이하일경우 도착
            if(Vector3 .Distance(transform.position, theParh.points[currentpoint].position)<0.01f)
            {
                currentpoint += 1;//다음 위치 커서로 옮기고

                if(currentpoint >= theParh.points.Length)  //다 돌았으면 정지
                {
                    reachedEnd = true;
                }
            }
        }
        
    }

    public void SetMode(float value)
    {
        modEnd = false;
        speedMod = value;
        timeSinceStart = 2.0f;
    }
}
