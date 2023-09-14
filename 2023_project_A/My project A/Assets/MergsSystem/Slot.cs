using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public enum SLOTSTATE                       // ���� ���°�
    {
        EMPTY,
        FULL
    }

    public int id;
    public Item itemObject;                     //������ ������ ���� (Ŀ���� CLass)
    public SLOTSTATE state = SLOTSTATE.EMPTY;    // ���°� �����Ѱ� ������ EMPTY �Է�


      public void ChangeStateTo(SLOTSTATE targetState)//�ش� ������ ���°��� ��ȯ �����ִ� �Լ�
    {
        state = targetState;
    }
    public void ItemGrabbed()                                               //������RayCast�� ���ؼ� �������� �������
    {
        Destroy(itemObject.gameObject);                                     //�������� �������� ����
        ChangeStateTo(SLOTSTATE.EMPTY);                                     //������ �� ����(State)
    }
    public void CreateItem(int id)
    {
        string itemPath = "Prefabs/Item_" + id.ToString("000"); //������ ������ ���
        var itemGo = (GameObject)Instantiate(Resources.Load (itemPath));//������ ��ο� �ִ� ������

        itemGo.transform.SetParent(this.transform);         //Slot ������Ʈ ������ ����
        itemGo.transform.localPosition = Vector3.zero;      //��Ŀ ��ġ�� Vecter3(0,0,0)
        itemGo.transform.localScale = Vector3.one;          //���� scale�� Vecter3(1,1,1)

        itemObject = itemGo.GetComponent<Item>();           //������ ���� ������Ʈ�� Item Class��
        itemObject.lnit(id, this);                          //�Լ��� ���� �� �Է�

        ChangeStateTo(SLOTSTATE.FULL);                  //�����ؼ� ������ ������ ���ִ�.
    }
}
