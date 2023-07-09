using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

[System.Serializable]
public class StatSystem
{
    private long cash;

    private int gold;

    private int xp;

    private int level;

    private List<int> lvl;

    private List<float> lvlProgress;

    private DateTime dateTime;

    public StatSystem() 
    {
        cash = 0;

        gold = 0;

        xp = 0;

        level = 1;

        lvl = new List<int>() { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        lvlProgress = new List<float>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };  

        dateTime = DateTime.Now;
    }

    public StatSystem(StatSystem statSystem)
    {
        cash = statSystem.cash;

        gold = statSystem.gold;

        xp = statSystem.xp;

        level = statSystem.level;

        lvl = new List<int>(statSystem.lvl);

        lvlProgress = new List<float>(statSystem.lvlProgress);

        dateTime = statSystem.dateTime;
    }

    public long GetCash()
    {
        return this.cash;
    }

    public void SetCash(long cash)
    {
        this.cash = cash;
    }

    public int GetGold()
    {
        return this.gold;
    }

    public void SetGold(int gold)
    {
        this.gold = gold;
    }

    public int GetXp()
    {
        return this.xp;
    }

    public void SetXp(int xp)
    {
        this.xp = xp;
    }

    public int GetLevel()
    {
        return this.level;
    }

    public void SetLevel(int level)
    {
        this.level = level;
    }

    public int GetLvl(int index)
    {
        return this.lvl[index];
    }

    public void SetLvl(int index, int lvl)
    {
        this.lvl[index] = lvl;
    }
    
    public float GetLvlProgress(int index)
    {
        return this.lvlProgress[index];
    }

    public void SetLvlProgress(int index, float progress)
    {
        this.lvlProgress[index] = progress;
    }

    public DateTime GetDT()
    {
        return this.dateTime;
    }

    public void SetDT(DateTime dateTime)
    {
        this.dateTime = dateTime;
    }
}
