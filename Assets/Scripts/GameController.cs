using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private StatSystem statSystem;

    [SerializeField] private Text cashText;

    [SerializeField] private List<Text> lvlText;

    [SerializeField] private List<Text> lvlBtnText;

    [SerializeField] private List<Text> lvlLvlText;

    [SerializeField] private List<GameObject> lvlImage;

    private void Start()
    {
        statSystem = new StatSystem(SaveSystem.LoadGame());

        long deltaTime = (long)DateTime.Now.Subtract(statSystem.GetDT()).TotalSeconds;

        long acumulatedCash = GetDeltaCash(deltaTime);

        statSystem.SetCash(statSystem.GetCash() + acumulatedCash);

        SetProgressBars(deltaTime);

        UpdateText();

        InvokeFunctions(deltaTime);
    }
    private void OnApplicationQuit()
    {
        Debug.Log("Quit");

        SaveSystem.SaveGame(statSystem);
    }
    private long GetDeltaCash(long deltaTime)
    {
        long deltaCash = 0;
        
        for (int index = 0; index < 15; index++)
        {
            deltaCash += statSystem.GetLvl(index) * (long)Mathf.Floor(statSystem.GetLvlProgress(index) + deltaTime / GameVariables.lvlTime[index]);
        }

        return deltaCash;
    }
    private void SetProgressBars(long deltaTime)
    {
        for (int index = 0; index < 15; index++)
        {
            if (statSystem.GetLvl(index) != 0)
            {
                statSystem.SetLvlProgress(index, (float)deltaTime % GameVariables.lvlTime[index] / GameVariables.lvlTime[index] + statSystem.GetLvlProgress(index));
            }
        }
    }

    private long GetFormulae(int index)
    {
        return (statSystem.GetLvl(index) + GameVariables.lvlCash[index]) * 3;
    }

    public void UpgradeLvl(int index)
    {
        if (statSystem.GetCash() >= GetFormulae(index) && statSystem.GetLvl(index) < GameVariables.lvlCash[index] * 50)
        {
            statSystem.SetCash(statSystem.GetCash() - GetFormulae(index));

            cashText.text = statSystem.GetCash().ToString();

            statSystem.SetLvl(index, statSystem.GetLvl(index) + GameVariables.lvlCash[index]);

            lvlBtnText[index].text = "Upgrade\n" + GetFormulae(index).ToString();

            if ((long)statSystem.GetLvl(index) / GameVariables.lvlCash[index] == 1)
            {
                InvokeRepeating("UpdateCashLvl" + (index + 1).ToString(), GameVariables.lvlTime[index], GameVariables.lvlTime[index]);

                InvokeRepeating("UpdateProgressLvl" + (index + 1).ToString(), 0f, 0.03f);
            }

            if ((long)statSystem.GetLvl(index) / GameVariables.lvlCash[index] == 50)
            {
                lvlBtnText[index].text = "Max Lvl.";
            }

            lvlText[index].text = statSystem.GetLvl(index).ToString();

            lvlLvlText[index].text = "Lvl." + ((long)statSystem.GetLvl(index) / GameVariables.lvlCash[index]).ToString();
        }
    }

    public void UpdateCashLvl1()
    {
        statSystem.SetCash(statSystem.GetCash() + statSystem.GetLvl(0));

        statSystem.SetLvlProgress(0, 0f);

        cashText.text = statSystem.GetCash().ToString();
    }
    public void UpdateCashLvl2()
    {
        statSystem.SetCash(statSystem.GetCash() + statSystem.GetLvl(1));

        statSystem.SetLvlProgress(1, 0f);

        cashText.text = statSystem.GetCash().ToString();
    }
    public void UpdateCashLvl3()
    {
        statSystem.SetCash(statSystem.GetCash() + statSystem.GetLvl(2));

        statSystem.SetLvlProgress(2, 0f);

        cashText.text = statSystem.GetCash().ToString();
    }
    public void UpdateCashLvl4()
    {
        statSystem.SetCash(statSystem.GetCash() + statSystem.GetLvl(3));

        statSystem.SetLvlProgress(3, 0f);

        cashText.text = statSystem.GetCash().ToString();
    }
    public void UpdateCashLvl5()
    {
        statSystem.SetCash(statSystem.GetCash() + statSystem.GetLvl(4));

        statSystem.SetLvlProgress(4, 0f);

        cashText.text = statSystem.GetCash().ToString();
    }
    public void UpdateCashLvl6()
    {
        statSystem.SetCash(statSystem.GetCash() + statSystem.GetLvl(5));

        statSystem.SetLvlProgress(5, 0f);

        cashText.text = statSystem.GetCash().ToString();
    }
    public void UpdateCashLvl7()
    {
        statSystem.SetCash(statSystem.GetCash() + statSystem.GetLvl(6));

        statSystem.SetLvlProgress(6, 0f);

        cashText.text = statSystem.GetCash().ToString();
    }
    public void UpdateCashLvl8()
    {
        statSystem.SetCash(statSystem.GetCash() + statSystem.GetLvl(7));

        statSystem.SetLvlProgress(7, 0f);

        cashText.text = statSystem.GetCash().ToString();
    }
    public void UpdateCashLvl9()
    {
        statSystem.SetCash(statSystem.GetCash() + statSystem.GetLvl(8));

        statSystem.SetLvlProgress(8, 0f);

        cashText.text = statSystem.GetCash().ToString();
    }
    public void UpdateCashLvl10()
    {
        statSystem.SetCash(statSystem.GetCash() + statSystem.GetLvl(9));

        statSystem.SetLvlProgress(9, 0f);

        cashText.text = statSystem.GetCash().ToString();
    }
    public void UpdateCashLvl11()
    {
        statSystem.SetCash(statSystem.GetCash() + statSystem.GetLvl(10));

        statSystem.SetLvlProgress(10, 0f);

        cashText.text = statSystem.GetCash().ToString();
    }
    public void UpdateCashLvl12()
    {
        statSystem.SetCash(statSystem.GetCash() + statSystem.GetLvl(11));

        statSystem.SetLvlProgress(11, 0f);

        cashText.text = statSystem.GetCash().ToString();
    }
    public void UpdateCashLvl13()
    {
        statSystem.SetCash(statSystem.GetCash() + statSystem.GetLvl(12));

        statSystem.SetLvlProgress(12, 0f);

        cashText.text = statSystem.GetCash().ToString();
    }
    public void UpdateCashLvl14()
    {
        statSystem.SetCash(statSystem.GetCash() + statSystem.GetLvl(13));

        statSystem.SetLvlProgress(13, 0f);

        cashText.text = statSystem.GetCash().ToString();
    }
    public void UpdateCashLvl15()
    {
        statSystem.SetCash(statSystem.GetCash() + statSystem.GetLvl(14));

        statSystem.SetLvlProgress(14, 0f);

        cashText.text = statSystem.GetCash().ToString();
    }

    public void UpdateProgressLvl1()
    {
        if (statSystem.GetLvl(0) > 0)
        {
            if (statSystem.GetLvlProgress(0) >= 1)
            {
                lvlImage[0].transform.localScale = new Vector3(statSystem.GetLvlProgress(0), 1, 1);

                statSystem.SetLvlProgress(0, 0f);

                lvlImage[0].transform.localScale = new Vector3(statSystem.GetLvlProgress(0), 1, 1);
            }
            else
            {
                lvlImage[0].transform.localScale = new Vector3(statSystem.GetLvlProgress(0), 1, 1);

                statSystem.SetLvlProgress(0, (float)(statSystem.GetLvlProgress(0) +(0.03f / (float)GameVariables.lvlTime[0])));
            }
        }
    }
    public void UpdateProgressLvl2()
    {
        if (statSystem.GetLvl(1) > 0)
        {
            if (statSystem.GetLvlProgress(1) >= 1)
            {
                lvlImage[1].transform.localScale = new Vector3(statSystem.GetLvlProgress(1), 1, 1);

                statSystem.SetLvlProgress(1, 0f);

                lvlImage[1].transform.localScale = new Vector3(statSystem.GetLvlProgress(1), 1, 1);
            }
            else
            {
                lvlImage[1].transform.localScale = new Vector3(statSystem.GetLvlProgress(1), 1, 1);

                statSystem.SetLvlProgress(1, (float)(statSystem.GetLvlProgress(1) + (0.03f / (float)GameVariables.lvlTime[1])));
            }
        }
    }
    public void UpdateProgressLvl3()
    {
        if (statSystem.GetLvl(2) > 0)
        {
            if (statSystem.GetLvlProgress(2) >= 1)
            {
                lvlImage[2].transform.localScale = new Vector3(statSystem.GetLvlProgress(2), 1, 1);

                statSystem.SetLvlProgress(2, 0f);

                lvlImage[2].transform.localScale = new Vector3(statSystem.GetLvlProgress(2), 1, 1);
            }
            else
            {
                lvlImage[2].transform.localScale = new Vector3(statSystem.GetLvlProgress(2), 1, 1);

                statSystem.SetLvlProgress(2, (float)(statSystem.GetLvlProgress(2) + (0.03f / (float)GameVariables.lvlTime[2])));

            }
        }
    }
    public void UpdateProgressLvl4()
    {
        if (statSystem.GetLvl(3) > 0)
        {
            if (statSystem.GetLvlProgress(3) >= 1)
            {
                lvlImage[3].transform.localScale = new Vector3(statSystem.GetLvlProgress(3), 1, 1);

                statSystem.SetLvlProgress(3, 0f);

                lvlImage[3].transform.localScale = new Vector3(statSystem.GetLvlProgress(3), 1, 1);
            }
            else
            {
                lvlImage[3].transform.localScale = new Vector3(statSystem.GetLvlProgress(3), 1, 1);

                statSystem.SetLvlProgress(3, (float)(statSystem.GetLvlProgress(3) + (0.03f / (float)GameVariables.lvlTime[3])));
            }
        }
    }

    public void UpdateProgressLvl5()
    {
        if (statSystem.GetLvl(4) > 0)
        {
            if (statSystem.GetLvlProgress(4) >= 1)
            {
                lvlImage[4].transform.localScale = new Vector3(statSystem.GetLvlProgress(4), 1, 1);

                statSystem.SetLvlProgress(4, 0f);

                lvlImage[4].transform.localScale = new Vector3(statSystem.GetLvlProgress(4), 1, 1);
            }
            else
            {
                lvlImage[4].transform.localScale = new Vector3(statSystem.GetLvlProgress(4), 1, 1);

                statSystem.SetLvlProgress(4, (float)(statSystem.GetLvlProgress(4) + (0.03f / (float)GameVariables.lvlTime[4])));
            }
        }
    }
    public void UpdateProgressLvl6()
    {
        if (statSystem.GetLvl(5) > 0)
        {
            if (statSystem.GetLvlProgress(5) >= 1)
            {
                lvlImage[5].transform.localScale = new Vector3(statSystem.GetLvlProgress(5), 1, 1);

                statSystem.SetLvlProgress(5, 0f);

                lvlImage[5].transform.localScale = new Vector3(statSystem.GetLvlProgress(5), 1, 1);
            }
            else
            {
                lvlImage[5].transform.localScale = new Vector3(statSystem.GetLvlProgress(5), 1, 1);

                statSystem.SetLvlProgress(5, (float)(statSystem.GetLvlProgress(5) + (0.03f / (float)GameVariables.lvlTime[5])));
            }
        }
    }
    public void UpdateProgressLvl7()
    {
        if (statSystem.GetLvl(6) > 0)
        {
            if (statSystem.GetLvlProgress(6) >= 1)
            {
                lvlImage[6].transform.localScale = new Vector3(statSystem.GetLvlProgress(6), 1, 1);

                statSystem.SetLvlProgress(6, 0f);

                lvlImage[6].transform.localScale = new Vector3(statSystem.GetLvlProgress(6), 1, 1);
            }
            else
            {
                lvlImage[6].transform.localScale = new Vector3(statSystem.GetLvlProgress(6), 1, 1);

                statSystem.SetLvlProgress(6, (float)(statSystem.GetLvlProgress(6) + (0.03f / (float)GameVariables.lvlTime[6])));
            }
        }
    }
    public void UpdateProgressLvl8()
    {
        if (statSystem.GetLvl(7) > 0)
        {
            if (statSystem.GetLvlProgress(7) >= 1)
            {
                lvlImage[7].transform.localScale = new Vector3(statSystem.GetLvlProgress(7), 1, 1);

                statSystem.SetLvlProgress(7, 0f);

                lvlImage[7].transform.localScale = new Vector3(statSystem.GetLvlProgress(7), 1, 1);
            }
            else
            {
                lvlImage[7].transform.localScale = new Vector3(statSystem.GetLvlProgress(7), 1, 1);

                statSystem.SetLvlProgress(7, (float)(statSystem.GetLvlProgress(7) + (0.03f / (float)GameVariables.lvlTime[7])));
            }
        }
    }
    public void UpdateProgressLvl9()
    {
        if (statSystem.GetLvl(8) > 0)
        {
            if (statSystem.GetLvlProgress(8) >= 1)
            {
                lvlImage[8].transform.localScale = new Vector3(statSystem.GetLvlProgress(8), 1, 1);

                statSystem.SetLvlProgress(8, 0f);

                lvlImage[8].transform.localScale = new Vector3(statSystem.GetLvlProgress(8), 1, 1);
            }
            else
            {
                lvlImage[8].transform.localScale = new Vector3(statSystem.GetLvlProgress(8), 1, 1);

                statSystem.SetLvlProgress(8, (float)(statSystem.GetLvlProgress(8) + (0.03f / (float)GameVariables.lvlTime[8])));
            }
        }
    }
    public void UpdateProgressLvl10()
    {
        if (statSystem.GetLvl(9) > 0)
        {
            if (statSystem.GetLvlProgress(9) >= 1)
            {
                lvlImage[9].transform.localScale = new Vector3(statSystem.GetLvlProgress(9), 1, 1);

                statSystem.SetLvlProgress(9, 0f);

                lvlImage[9].transform.localScale = new Vector3(statSystem.GetLvlProgress(9), 1, 1);
            }
            else
            {
                lvlImage[9].transform.localScale = new Vector3(statSystem.GetLvlProgress(9), 1, 1);

                statSystem.SetLvlProgress(9, (float)(statSystem.GetLvlProgress(9) + (0.03f / (float)GameVariables.lvlTime[9])));
            }
        }
    }
    public void UpdateProgressLvl11()
    {
        if (statSystem.GetLvl(10) > 0)
        {
            if (statSystem.GetLvlProgress(10) >= 1)
            {
                lvlImage[10].transform.localScale = new Vector3(statSystem.GetLvlProgress(10), 1, 1);

                statSystem.SetLvlProgress(10, 0f);

                lvlImage[10].transform.localScale = new Vector3(statSystem.GetLvlProgress(10), 1, 1);
            }
            else
            {
                lvlImage[10].transform.localScale = new Vector3(statSystem.GetLvlProgress(10), 1, 1);

                statSystem.SetLvlProgress(10, (float)(statSystem.GetLvlProgress(10) + (0.03f / (float)GameVariables.lvlTime[10])));
            }
        }
    }
    public void UpdateProgressLvl12()
    {
        if (statSystem.GetLvl(11) > 0)
        {
            if (statSystem.GetLvlProgress(11) >= 1)
            {
                lvlImage[11].transform.localScale = new Vector3(statSystem.GetLvlProgress(11), 1, 1);

                statSystem.SetLvlProgress(11, 0f);

                lvlImage[11].transform.localScale = new Vector3(statSystem.GetLvlProgress(11), 1, 1);
            }
            else
            {
                lvlImage[11].transform.localScale = new Vector3(statSystem.GetLvlProgress(11), 1, 1);

                statSystem.SetLvlProgress(11, (float)(statSystem.GetLvlProgress(11) + (0.03f / (float)GameVariables.lvlTime[11])));
            }
        }
    }
    public void UpdateProgressLvl13()
    {
        if (statSystem.GetLvl(12) > 0)
        {
            if (statSystem.GetLvlProgress(12) >= 1)
            {
                lvlImage[12].transform.localScale = new Vector3(statSystem.GetLvlProgress(12), 1, 1);

                statSystem.SetLvlProgress(12, 0f);

                lvlImage[12].transform.localScale = new Vector3(statSystem.GetLvlProgress(12), 1, 1);
            }
            else
            {
                lvlImage[12].transform.localScale = new Vector3(statSystem.GetLvlProgress(12), 1, 1);

                statSystem.SetLvlProgress(12, (float)(statSystem.GetLvlProgress(12) + (0.03f / (float)GameVariables.lvlTime[12])));
            }
        }
    }
    public void UpdateProgressLvl14()
    {
        if (statSystem.GetLvl(13) > 0)
        {
            if (statSystem.GetLvlProgress(13) >= 1)
            {
                lvlImage[13].transform.localScale = new Vector3(statSystem.GetLvlProgress(13), 1, 1);

                statSystem.SetLvlProgress(13, 0f);

                lvlImage[13].transform.localScale = new Vector3(statSystem.GetLvlProgress(13), 1, 1);
            }
            else
            {
                lvlImage[13].transform.localScale = new Vector3(statSystem.GetLvlProgress(13), 1, 1);

                statSystem.SetLvlProgress(13, (float)(statSystem.GetLvlProgress(13) + (0.03f / (float)GameVariables.lvlTime[13])));
            }
        }
    }
    public void UpdateProgressLvl15()
    {
        if (statSystem.GetLvl(14) > 0)
        {
            if (statSystem.GetLvlProgress(14) >= 1)
            {
                lvlImage[14].transform.localScale = new Vector3(statSystem.GetLvlProgress(14), 1, 1);

                statSystem.SetLvlProgress(14, 0f);

                lvlImage[14].transform.localScale = new Vector3(statSystem.GetLvlProgress(14), 1, 1);
            }
            else
            {
                lvlImage[14].transform.localScale = new Vector3(statSystem.GetLvlProgress(14), 1, 1);

                statSystem.SetLvlProgress(14, (float)(statSystem.GetLvlProgress(14) + (0.03f / (float)GameVariables.lvlTime[14])));
            }
        }
    }

    private void UpdateText()
    {
        cashText.text = statSystem.GetCash().ToString();

        for (int index = 0; index < 15; index++)
        {
            lvlText[index].text = statSystem.GetLvl(index).ToString();

            if ((long)statSystem.GetLvl(index) / GameVariables.lvlCash[index] >= 1)
            {
                lvlBtnText[index].text = "Upgrade\n" + GetFormulae(index).ToString();
            }
            else
            {
                lvlBtnText[index].text = "Buy\n" + GetFormulae(index).ToString();
            }

            if ((long)statSystem.GetLvl(index) / GameVariables.lvlCash[index] == 50)
            {
                lvlBtnText[index].text = "Max Lvl.";
            }

            lvlLvlText[index].text = "Lvl." + ((long)statSystem.GetLvl(index) / GameVariables.lvlCash[index]).ToString();
        }
    }
    private void InvokeFunctions(long deltaTime)
    {
        for (int index = 0; index < 15; index++)
        {
            if (statSystem.GetLvl(index) > 0)
            {
                InvokeRepeating("UpdateCashLvl" + (index + 1).ToString(), GameVariables.lvlTime[index] - ((statSystem.GetLvlProgress(index) + (float)deltaTime) % GameVariables.lvlTime[index]), GameVariables.lvlTime[index]);

                InvokeRepeating("UpdateProgressLvl" + (index + 1).ToString(), 0f, 0.03f);
            }
        }
    }
}
