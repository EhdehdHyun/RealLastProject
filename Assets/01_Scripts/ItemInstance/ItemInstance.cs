using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInstance
{

    //아이템 정보를 받는 새로운 객체 
    //이유 : 통일화된 아이템이 아닌 각자의 객체를 지닌 아이템으로서 존재해야하기 때문
    //여기서 아이템 정보를 전부 관리 
    //장착, 스택, 기타 등등

    public Data_table data;
    public int quantity;
    public bool equipped;

    public ItemInstance(Data_table itemData, int quantity = 1)
    {
        this.data = itemData;
        this.quantity = quantity;
        this.equipped = false;
    }
}
