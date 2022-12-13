using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float HealthCasco;
    public float HealthVela;

    public Vector3 viento;

    public float bulletDamage;



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
        if (QuestCheck[4] == true)
        {
            CompleteMision();
           
        }
        UpdateMisionUI();

       
    }

    public void SetMisionUI(int _id)
    {   
        MisionTitle.text = MisionClass.GetMision(_id).MisionTitle;
        Quest1.text = MisionClass.GetMision(_id).Quest1.Text;
        Quest2.text = MisionClass.GetMision(_id).Quest2.Text;
        Quest3.text = MisionClass.GetMision(_id).Quest3.Text;
        Quest4.text = MisionClass.GetMision(_id).Quest4.Text;
        Quest5.text = MisionClass.GetMision(_id).Quest5.Text;
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

        for (int i = 0; i < QuestList.Count; i++)
        {
            if (ActualQuest.text.Contains("-"))
            {
                CompleteQuest(i, i);
            }
            
        }

        ActualQuest.fontStyle = FontStyle.Bold;
        ActualQuest.color = new Color(0, 0, 0, 255);

       
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
        MisionID++;
        for (int i = 0; i < QuestCheck.Count; i++)
        {
            QuestCheck[i] = false;
        }
        SetMisionUI(MisionID);
    }
}
