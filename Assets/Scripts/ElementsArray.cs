using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementData
{
    public ElementData(string val, Sprite img)
    {
        value = val;
        image = img;
    }

    public string getValue
    {
        get {return value;}
    }

    public Sprite getImage
    {
        get {return image;}
    }

    private string value;
    private Sprite image;
}

public class ElementsArray : MonoBehaviour
{
    [SerializeField] private string typeName;
    [SerializeField] private string[] values;
    [SerializeField] private Sprite[] images;

    private List<ElementData> elements;
    private List<ElementData> elementsBackup;

    public string getTypeName
    {
        get {return typeName;}
    }
    
    public List<ElementData> getRandomElements(int count)
    {
        List<int> indexesToDelete = new List<int>();
        List<ElementData> newElements = new List<ElementData>();
// Если неповторяющиеся элементы кончились - перезаполняем массив карточек
        if (elements.Count < count)
        {
            elements.Clear();
            elements.AddRange(elementsBackup);
        }
        for (int elementNum = 0; elementNum < count; ++elementNum)
        {
            int randomIndex = -1; 
            do
            {
                randomIndex = Random.Range(0, elements.Count);
            } while (indexesToDelete.Contains(randomIndex));
            indexesToDelete.Add(randomIndex);

            newElements.Add(elements[randomIndex]);
        }
        for (int elementToDeleteNum = 0; elementToDeleteNum < indexesToDelete.Count; ++elementToDeleteNum)
        {
            indexesToDelete.RemoveAt(elementToDeleteNum);
        }
        return newElements;
    }

    void Awake()
    {
        elements = new List<ElementData>();
        for (int elementNum = 0; elementNum < values.Length; ++elementNum)
        {
            ElementData newElement = new ElementData(values[elementNum], images[elementNum]);
            elements.Add(newElement);
        }
        elementsBackup = new List<ElementData>(elements);
    }

    void Start()
    {
    }
    void Update()
    {
    }
}
