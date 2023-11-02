using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 1.0f; //�� �̵��ӵ�
    public float speedMod = 1.0f;
    public float timeSinceStart = 0.0f;

    private MonsterPath theParh; //�н����� ��
    private int currentpoint; //�н� ��ġ Ŀ����
    private bool reachedEnd; //���� �Ϸ�˻� bool��

    private bool modEnd = true;


    void Start()
    {
        if(theParh == null)    //�����Ҷ� Path�� ������
        {
            theParh = FindObjectOfType<MonsterPath>(); //Scene���� ã�´�.
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


        if (reachedEnd == false)  //���� �Ϸᰡ �ƴҰ��
        {
            transform.LookAt(theParh.points[currentpoint]); //���� ��ġ Ŀ������ ���ؼ� ����.

            transform.position = Vector3.MoveTowards(transform.position
                , theParh.points[currentpoint].position, moveSpeed * Time.deltaTime * speedMod);

            //���� �н� ����Ʈ ��ġ�� �Ÿ��� ����ؼ� 0.01 �����ϰ�� ����
            if(Vector3 .Distance(transform.position, theParh.points[currentpoint].position)<0.01f)
            {
                currentpoint += 1;//���� ��ġ Ŀ���� �ű��

                if(currentpoint >= theParh.points.Length)  //�� �������� ����
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
