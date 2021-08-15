using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldGrid : MonoBehaviour
{
    private float startX;
    private float startY;
    private float z;
    private int gridRows = 1;
    private int gridCols = 3;
    private float offsetX = 5f;
    private float offsetY = 4.5f;
    private Vector3 currentStartCoords;

    private float paddingX = 3f;
    private float paddingY = 3f;

    public int rowCount
    {
        get {return gridRows;}
    }
    public int colCount
    {
        get {return gridCols;}
    }
    public float getOffsetX
    {
        get {return offsetX;}
    }
    public float getOffsetY
    {
        get {return offsetY;}
    }
    public void SetRowCount(int count)
    {
        gridRows = count;
    }
    public void SetColCount(int count)
    {
        gridCols = count;
    }

    public Vector3 getStartCoords
    {
        get {return currentStartCoords;}
    }

    void Awake() 
    {
        startX = Camera.main.ScreenToWorldPoint(Vector3.zero).x + paddingX;
        startY = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)).y - paddingY;
        currentStartCoords = new Vector3(startX, startY, z);
    }

    void Start()
    {
        
    }

    void Update()
    {
    }
}
