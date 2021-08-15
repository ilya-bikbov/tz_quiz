using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using DG.Tweening;

[System.Serializable]
public class TargetNameSetted : UnityEvent<string>
{
}
[System.Serializable]
public class TargetFounded : UnityEvent<bool>
{
}

public class Element : MonoBehaviour
{
    private string value = "";
    private bool isTarget = false;

    [SerializeField] private ElementSpawner spawner;
    [SerializeField] private Sprite image;
    
    public UnityEvent targetClicked;
    public TargetNameSetted targetNameSetted;
    public TargetFounded targetFounded;

    public string getValue
    {
        get {return value;}
    }

    public bool isTargetState
    {
        get {return isTarget;}
    }
    public void setElement(string newValue, Sprite newImage)
    {
        value = newValue;
        GetComponent<SpriteRenderer>().sprite = newImage;
    }
    public void setTargetState(bool state)
    {
        isTarget = state;
        if (isTarget == true)
        {
           targetNameSetted.Invoke(value);
        }
    } 

    public void OnMouseDown() 
    {
        if (isTarget == true) 
        {
            StartCoroutine(goNext());
            GetComponent<BoxCollider>().enabled = false;
        }
    }
    void Start()
    {
        if (targetNameSetted == null)
            targetNameSetted = new TargetNameSetted();
        if (targetFounded == null)
            targetFounded = new TargetFounded();
    }

    void Update()
    {
    }

    IEnumerator goNext()
    {
        targetClicked.Invoke();
        yield return new WaitForSeconds(1);
        targetFounded.Invoke(true);
    }
}

