using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisionClass : MonoBehaviour
{
    public class QuestProperties
    {
        public string Text;
        public bool skip = false;
        
    }
    public class MisionProperties
    {
        public int MisionID;

        public string MisionTitle;
        public QuestProperties Quest1;
        public QuestProperties Quest2;
        public QuestProperties Quest3;
        public QuestProperties Quest4;
        public QuestProperties Quest5;
        
        public string Descripción;

        public int Numquest;

        public int RewardID;
    }

    static public List<MisionProperties> MisionsLists = new List<MisionProperties>()
    {
        new MisionProperties()
        {
            MisionID = 0,
            MisionTitle = "Tutorial",
            Quest1 = new QuestProperties() {Text = "Usa W para ir recto"},
            Quest2 = new QuestProperties() {Text = "Usa A o D para rotar" },
            Quest3 = new QuestProperties() {Text = "Usa Clic derecho para apuntar" },
            Quest4 = new QuestProperties() {Text = "Usa espacio mientras apuntas para disparar" },
            Quest5 = new QuestProperties() {Text = "-" , skip = true},

            
            
            RewardID = 0,
            Numquest = 4
            
        },
            new MisionProperties()
        {
            MisionID = 1,
            MisionTitle = "Preparación para la Caza",

            Quest1 = new QuestProperties() {Text = "Consigue 3 carne de pescado" },
            Quest2 = new QuestProperties() {Text = "Consigue 1 sangre de arpía" },
            Quest3 = new QuestProperties() {Text = "Craftea un cebo en el mercado" },
            Quest4 = new QuestProperties() {Text = "-", skip = true },
            Quest5 = new QuestProperties() {Text = "-", skip = true },

            RewardID = 0,
            Numquest = 3
        },
          new MisionProperties()
        {
            MisionID = 2,
            MisionTitle = "La Caza",

            Quest1 = new QuestProperties() {Text = "Usa el cebo en el hábitat de La Barrakurnuda" },
            Quest2 = new QuestProperties() {Text = "Acaba con La Barrakurnuda" },
            Quest3 = new QuestProperties() {Text = "-", skip = true},
            Quest4 = new QuestProperties() {Text = "-", skip = true},
            Quest5 = new QuestProperties() {Text = "-", skip = true},

            RewardID = 0,
            Numquest = 2
        },
    };



    static public MisionProperties GetMision(int _id)
    {
        for (int i = 0; i < MisionsLists.Count; i++)
        {
            if (MisionsLists[i].MisionID == _id)
            {
                return MisionsLists[i];
            }
        }  
        return null;
    }
    

}


