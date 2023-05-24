using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float HealthCasco;
    public float HealthVela;

    public Vector3 viento;

    public float bulletDamage;

    public int NumMisiones;

    public List<int> Inventory;


    //UI
    public GameObject misionPanel;

    public Text MisionTitle;
    
    public Text Quest1;
    public Text Quest2;
    public Text Quest3;
    public Text Quest4;
    public Text Quest5;



    public int MisionID;


    


    public List<Text> QuestList;
    public List<bool> QuestCheck;
    public Text ActualQuest;
    
    void Start()
    {

        QuestList.Add(Quest1);
        QuestList.Add(Quest2);
        QuestList.Add(Quest3);
        QuestList.Add(Quest4);
        QuestList.Add(Quest5);

        for (int i = 0; i < QuestCheck.Count; i++)
        {
            QuestCheck[i] = false;
        }

        SetMisionUI(MisionID);
    }

   
    void Update()
    {
        
        UpdateMisionUI();
        
       
    
        if(MisionID == 1)
        {
            int _temp =0;
            for (int i = 0; i < Inventory.Count; i++)
            {
                if (Inventory[i] == 2)
                {
                    CompleteQuest(1, 1);
                }
                if (Inventory[i] == 1)
                {
                    _temp++;

                }
                if(_temp >= 3)
                {
                    CompleteQuest(1, 0);
                    
                }
                
            }
        }
    }

    public void SetMisionUI(int _id)
    {
        _id++;
        MisionTitle.text = MisionClass.GetMision(_id).MisionTitle;  
        Quest1.text = MisionClass.GetMision(_id).Quest1.Text;
        Quest2.text = MisionClass.GetMision(_id).Quest2.Text;
        Quest3.text = MisionClass.GetMision(_id).Quest3.Text;
        Quest4.text = MisionClass.GetMision(_id).Quest4.Text;
        Quest5.text = MisionClass.GetMision(_id).Quest5.Text;
        NumMisiones = MisionClass.GetMision(_id).Numquest;
        print(_id);
        MisionID = _id;

        for (int i = 0; i < QuestCheck.Count; i++)
        {
            QuestCheck[i] = false;
            QuestList[i].transform.GetChild(1).gameObject.SetActive(false);
        }

       // UpdateMisionUI();
    }
   

    public void UpdateMisionUI()
    {
        print("entra");

        if (ActualQuest != null)
        {
            ActualQuest.fontStyle = FontStyle.Bold;
            ActualQuest.color = new Color(0, 0, 0, 255);
            if (ActualQuest.text.Contains("-"))
            {
                CompleteMision();
            }
        }
           
        for (int i = 0; i < QuestCheck.Count; i++)
        {
            if (QuestCheck[i] == false)
            {
                ActualQuest = QuestList[i];
                
                return;
            }
            else if (QuestCheck[i] == true)
            {
                QuestList[i].transform.GetChild(1).gameObject.SetActive(true);
               
            }
        }
        
        
      

       
    }
    public void CompleteQuest(int _misionid, int _questid)
    {

        if (MisionID == _misionid && QuestCheck[_questid] == false)
        {
            QuestCheck[_questid] = true;
        }
        // UpdateMisionUI(); 
    }
    public void CompleteMision()
    {

        SetMisionUI(MisionID);
        for (int i = 0; i < QuestCheck.Count; i++)
        {
            QuestCheck[i] = false;
        }
        Quest1.fontStyle=FontStyle.Normal;
        Quest1.color = Color.gray;
        Quest2.fontStyle = FontStyle.Normal;
        Quest2.color = Color.gray;
        Quest3.fontStyle=FontStyle.Normal;
        Quest3.color = Color.gray;
        Quest4.fontStyle=FontStyle.Normal;
        Quest4.color = Color.gray;
        Quest5.fontStyle=FontStyle.Normal;
        Quest5.color = Color.gray;

    }
}
