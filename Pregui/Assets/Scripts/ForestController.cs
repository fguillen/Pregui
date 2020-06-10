using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestController : MonoBehaviour
{
  public Transform limitNorth;
  public Transform limitEast;
  public Transform limitSouth;
  public Transform limitWest;

  private string[] cellElements;

  public List<GameObject> forestElementTemplates;
  private List<GameObject> forestElements;

  public GameObject noTreesArea;


  void Awake(){
    forestElements = new List<GameObject>();
    cellElements = new string[] {"tree", "flower", "flower", "flower", "nothing", "nothing"};
    GenerateForest();
  }

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    if(Input.GetKeyDown(KeyCode.R)) {
      DeleteForest();
      GenerateForest();
    }
  }

  void DeleteForest(){
    for (int i = forestElements.Count - 1; i >= 0; i--) {
      Destroy(forestElements[i]);
      forestElements.RemoveAt(i);
    }
  }

  void GenerateForest(){
    int xMin = (int)limitWest.position.x;
    int xMax = (int)limitEast.position.x;
    int yMin = (int)limitNorth.position.y;
    int yMax = (int)limitSouth.position.y;

    for(int x = xMin; x < xMax; x++) {
      for(int y = yMin; y < yMax; y++) {
        var index = (int)Mathf.Round(Random.Range(0, cellElements.Length));
        float noise = Random.Range(-5, 5) / 10f;
        switch (cellElements[index])
        {
          case "tree":
            float xFinal = (float)x + noise;
            float yFinal = (float)y + noise;

            if(!PointIsIntoTheNoTreesArea(x, y)) {
              GameObject forestElement = InstantiateForestElement(xFinal, yFinal);
              forestElements.Add(forestElement);
            }

            break;
        }

      }
    }
  }

  GameObject InstantiateForestElement(float x, float y){
    int index = (int)Mathf.Round(Random.Range(0, forestElementTemplates.Count));
    GameObject forestElement = Instantiate(forestElementTemplates[index], new Vector3(x, y, 0f), gameObject.transform.rotation);

    return forestElement;
  }

  bool PointIsIntoTheNoTreesArea(float x, float y) {
    return noTreesArea.transform.GetComponent<BoxCollider2D>().bounds.Contains(new Vector2(x, y));
  }
}
