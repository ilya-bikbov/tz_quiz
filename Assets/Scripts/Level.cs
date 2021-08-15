using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private int rowCount;
    [SerializeField] private int colCount;
    private bool doneState = false;

    public int getRowCount
    {
        get {return rowCount;}
    }
    public int getColCount
    {
        get {return colCount;}
    }
    public bool getDoneState
    {
        get {return doneState;}
    }
    public void setDoneState(bool state)
    {
        doneState = state;
    }

    void Start()
    {
    }

    void Update()
    {
    }
}
