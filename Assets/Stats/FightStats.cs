using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightStats
{
    private int attack;
    private int defence;

    public int[] attackCofWithLvl;
    public int[] defenceCofWithLvl;
    public FightStats(int attack, int defence)
    {
        this.attack = attack;
        this.defence = defence;

        attackCofWithLvl = FillCof();
        defenceCofWithLvl = FillCof();
    }

    public int Attack { get => attack; set => attack = value; }
    public int Defence { get => defence; set => defence = value; }

    private int[] FillCof() 
    {
        int[] cof = new int[Global.MAX_LVL];

        for (int i = 0; i < Global.MAX_LVL; i++)
        {
            cof[i] = i;
        }

        return cof;
    }
}
