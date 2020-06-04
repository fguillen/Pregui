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

  public List<GameObject> treeTemplates;
  private List<GameObject> forestElements;


  void Awake(){
    forestElements = new List<GameObject>();
    cellElements = new string[] {"tree", "flower", "nothing", "nothing", "nothing", "nothing"};
    GenerateForest();
  }

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    if(Input.GetKeyDown(KeyCode.Space)) {
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
        switch (cellElements[index])
        {
          case "tree":
            GameObject forestElement = InstantiateTree(x, y);
            forestElements.Add(forestElement);
            break;
        }

      }
    }
  }

  GameObject InstantiateTree(int x, int y){
    int index = (int)Mathf.Round(Random.Range(0, treeTemplates.Count));
    GameObject forestElement = Instantiate(treeTemplates[index], new Vector3(x, y, 0f), gameObject.transform.rotation);

    return forestElement;
  }
}
