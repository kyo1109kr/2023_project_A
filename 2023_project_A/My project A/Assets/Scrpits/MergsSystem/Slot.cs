using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public enum SLOTSTATE                       // 슬롯 상태값
    {
        EMPTY,
        FULL
    }

    public int id;
    public Item itemObject;                     //선언한 아이템 정의 (커스텀 CLass)
    public SLOTSTATE state = SLOTSTATE.EMPTY;    // 상태값 선언한것 정의후 EMPTY 입력


      public void ChangeStateTo(SLOTSTATE targetState)//해당 슬롯의 상태값을 변환 시켜주는 함수
    {
        state = targetState;
    }
    public void ItemGrabbed()                                               //유저가RayCast를 통해서 아이템을 잡았을때
    {
        Destroy(itemObject.gameObject);                                     //슬롯위의 아이템을 삭제
        ChangeStateTo(SLOTSTATE.EMPTY);                                     //슬롯은 빈 상태(State)
    }
    public void CreateItem(int id)
    {
        string itemPath = "Prefabs/Item_" + id.ToString("000"); //생성할 아이템 경로
        var itemGo = (GameObject)Instantiate(Resources.Load (itemPath));//아이템 경로에 있는 프리맵

        itemGo.transform.SetParent(this.transform);         //Slot 오브젝트 하위로 설정
        itemGo.transform.localPosition = Vector3.zero;      //로커 위치는 Vecter3(0,0,0)
        itemGo.transform.localScale = Vector3.one;          //로컬 scale은 Vecter3(1,1,1)

        itemObject = itemGo.GetComponent<Item>();           //생성한 게임 오브젝트의 Item Class를
        itemObject.lnit(id, this);                          //함수를 통해 값 입력

        ChangeStateTo(SLOTSTATE.FULL);                  //생성해서 아이템 슬롯이 차있다.
    }
}
