using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public const Item NO_ITEM = null;
    public Item choosedItem = NO_ITEM;

    int barlength = 150;

    //get stats after init
    public Stats stats;
    public StatInit statInit;

    public FightStatsInit fightStats;
    public ExpInit exp;

    public Texture2D progressBarEmpty;
    public Texture2D progressBarFull;

    public InventoryInit item;

    bool isInventoryOpen = false;
    int chooseItemIndex = 0;

    private void Start()
    {
        stats = statInit.stats;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            isInventoryOpen = !isInventoryOpen;
        }   
    }
    private void OnGUI()
    {
        DrawStatBar(stats.Age, 0);
        DrawStatBar(stats.Health, 1);
        DrawStatBar(stats.Hunger, 2);
        DrawStatBar(stats.Sleep, 3);
        DrawStatBar(stats.Happiness, 4);
        DrawExpBar(5);
        DrawFightStatBar(fightStats.fightStats.Attack, 6, "attack");
        DrawFightStatBar(fightStats.fightStats.Defence, 7, "defence");
        if (isInventoryOpen)
        {
            DrawItemsBar();

            ItemChose();

            //test
        }
        else 
        {
            choosedItem = NO_ITEM;
        }
    }
    void DrawStatBar(StatsField statsField, int order)
    {
        int step = 32;

        GUI.BeginGroup(new Rect(0, step * order, barlength, 32));
        GUI.Box(new Rect(0, 0, barlength, 32), progressBarEmpty);
        GUI.BeginGroup(new Rect(0, 0, statsField.value / 100 * barlength, 32));
        GUI.Box(new Rect(0, 0, barlength, 32), progressBarFull);
        GUI.EndGroup();
        GUI.EndGroup();
        GUI.Label(new Rect(0, step * order, barlength, 32), statsField.name + "/" + ((int)statsField.value).ToString() + "/" + statsField.duration + " " 
                                                            + statsField.tempDuration + "/" + statsField.buffTime);
    }

    void DrawFightStatBar(int fightStats, int order, string statName) 
    {
        int step = 32;

        GUI.BeginGroup(new Rect(0, step * order, barlength, 32));
        GUI.Box(new Rect(0, 0, barlength, 32), progressBarEmpty);
        GUI.BeginGroup(new Rect(0, 0, fightStats / 1000 * barlength, 32));
        GUI.Box(new Rect(0, 0, barlength, 32), progressBarFull);
        GUI.EndGroup();
        GUI.EndGroup();
        GUI.Label(new Rect(0, step * order, barlength, 32), statName + " " + fightStats);
    }

    void DrawExpBar(int order)
    {
        int step = 32;

        GUI.BeginGroup(new Rect(0, step * order, barlength, 32));
        GUI.Box(new Rect(0, 0, barlength, 32), progressBarEmpty);
        float exp_progressBar = (((float)(exp.exp.Current_exp - exp.exp.lvllt[exp.exp.Lvl]) / exp.exp.lvllt[exp.exp.Lvl + 1]));
        GUI.BeginGroup(new Rect(0, 0, exp_progressBar * barlength, 32));
        GUI.Box(new Rect(0, 0, barlength, 32), progressBarFull);
        GUI.EndGroup();
        GUI.EndGroup();
        GUI.Label(new Rect(0, step * order, barlength, 32), "exp " + exp.exp.Current_exp.ToString() + " / " + exp.exp.lvllt[exp.exp.Lvl + 1].ToString() + " lvl " + exp.exp.Lvl);
    }

    void DrawItemsBar() 
    {
        GUI.Label(new Rect(Screen.width - barlength / 2, 0, barlength, 32), "gold ");

        int idx = 1;
        foreach (InventoryCell item in item.inventory)
        {
            GUI.Label(new Rect(Screen.width - barlength, idx * 20, barlength, 32), item.item.itemName + " " +  item.count);
            idx++;
        }
    }

    private Item ItemChose() 
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            choosedItem = item.inventory[0].item;
        }
        //return chooseItemIndex;
        return choosedItem;
    }
}
