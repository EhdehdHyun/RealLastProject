using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager 
{
   //Josn변환 클래스 자동프로퍼티 만들기
   public Data_tableLoader Data_TableLoader {get; private set;}
   public skill_Data_TableLoader Skill_Data_TableLoader { get; private set; }

    public void Initialize()
    {
        //호출할 때 생성 시키게 하기 EX) data = new data();
        Data_TableLoader = new Data_tableLoader();
        Skill_Data_TableLoader = new skill_Data_TableLoader();
    }
}
