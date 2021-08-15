using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementSpawner : MonoBehaviour
{
    [SerializeField] private Element element;
    [SerializeField] private ElementsArray[] types;
    [SerializeField] private FieldGrid grid;
    [SerializeField] private StageDirector stageDirector;
    
    private string currentTypeName = "";
    private List<string> values;
    private List<Sprite> images;
    private int targetNum;
    private List<Element> currentElements;

    public void setElementsTypeToSpawn()
    {
        string newTypeName = "";
        int newTypeNum = 0;
//  Выбор типа "карточек"
        while (currentTypeName == newTypeName)
        {
            newTypeNum = Random.Range(0, types.Length);
            newTypeName = types[newTypeNum].getTypeName;
        }
        currentTypeName = newTypeName;
//  Получаем партию случайных "карточек" одного типа        
        List<ElementData> newElements = types[newTypeNum].getRandomElements(grid.rowCount * grid.colCount);
        for (int elementNum = 0; elementNum < newElements.Count; ++elementNum)
        {
            values.Add(newElements[elementNum].getValue);
            images.Add(newElements[elementNum].getImage);
        }
//  Выбираем цель
        targetNum = Random.Range(0, newElements.Count);
    }

    public void drawElements()
    {
        Vector3 startPos = new Vector3(grid.getStartCoords.x, grid.getStartCoords.y, grid.getStartCoords.z);

        for (int i = 0, elementsCounter = 0; i < grid.colCount; ++i)
        {
            for (int j = 0; j < grid.rowCount; ++j, ++elementsCounter)
            {
                Element tmpElement;
                tmpElement = Instantiate(element) as Element;
                tmpElement.setElement(values[values.Count-1], images[images.Count-1]);
                values.RemoveAt(values.Count-1);
                images.RemoveAt(images.Count-1);
                float posX = (grid.getOffsetX * i) + startPos.x;
                float posY = -(grid.getOffsetY * j) + startPos.y;
                tmpElement.transform.position = new Vector3(posX, posY, startPos.z);
//  Прокидываем сигналы карточки с объектами сцены
                tmpElement.targetNameSetted.AddListener(stageDirector.setTargetName);
                tmpElement.targetFounded.AddListener(stageDirector.setLevelEndedState);
//  Если нашли порядковый номер цели, сообщяем об этом карточке
                if (targetNum == elementsCounter)
                {
                    tmpElement.setTargetState(true);
                }
                currentElements.Add(tmpElement);
            }
        }
    }
    public void eraseElements()
    {
        for (int elementNum = 0; elementNum < currentElements.Count; ++elementNum)
        {
            Element aboutToDestroyElement = currentElements[elementNum];
            Destroy(aboutToDestroyElement.gameObject);
        }
        currentElements.Clear();  
    }

    void Awake() 
    {
        values = new List<string>();
        images = new List<Sprite>();
        currentElements = new List<Element>();
    }

    void Start()
    {
    }

    void Update()
    {  
    }
}
