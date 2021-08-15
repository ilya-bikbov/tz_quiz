using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StageDirector : MonoBehaviour
{
    [SerializeField] private FieldGrid grid;
    [SerializeField] private GameGUI gameGUI;
    [SerializeField] private ElementSpawner spawner;
    [SerializeField] private Level[] levels;
    private int levelCount;
    private Level currentLevel;
    
    private void getLevelCount()
    {
        levelCount = levels.Length;
    }

    private bool getNewLevel()
    {
        for (int levelNum = 0; levelNum < levels.Length; ++levelNum)
        {
            if (levels[levelNum].getDoneState == false)
            {
                currentLevel = levels[levelNum];
//  Есть уровень для прохождения
                return true;
            }
        }
//  Уровни закончились, можно перезапускать
        return false;
    }

    private void startLevel()
    {
        grid.SetRowCount(currentLevel.getRowCount);
        grid.SetColCount(currentLevel.getColCount);

        spawner.eraseElements();
        spawner.setElementsTypeToSpawn();
        spawner.drawElements();
    }

    public void setTargetName(string targetName)
    {
        gameGUI.setTargetText(targetName);
    }

    public void setLevelEndedState(bool state)
    {
        currentLevel.setDoneState(true);
        
        if (getNewLevel())
        {
            startLevel();
        }
        else
        {
            setGameEndedState(true);
        }
    }

    public void setGameEndedState(bool state)
    {
        gameGUI.activeRestartButton(true);
    }

    void Awake()
    {
        getLevelCount();
    }
    void Start()
    {
        getNewLevel();
        startLevel();
    }

    void Update()
    {
    }
}
