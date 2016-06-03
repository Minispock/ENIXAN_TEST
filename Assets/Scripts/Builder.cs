using UnityEngine;


public class Builder : MonoBehaviour
{

    private Transform item;
    public bool IsBuilding { get { return item != null; } }
    

   
    void Update()
    {

        if (IsBuilding) MoveItem();

    }

    public void Create(GameObject prefab)
    {
        GameObject itemObj = Instantiate(prefab);
        item = itemObj.transform;
    }

    private void MoveItem()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit)) //return bool
        {
            if (hit.collider.GetComponent<Square>())
            {
                Transform square = hit.collider.transform;
                item.position = square.position;

                if (Input.GetMouseButtonDown(0)) PlaceItem(square);
            }
        }
    }

    private void PlaceItem(Transform place)
    {
        Building itemBuilding = item.GetComponent<Building>();

        Collider[] obstacles = Physics.OverlapBox(place.position, new Vector3(itemBuilding.Width * 0.95F, 2, itemBuilding.Length * 0.95F) * 0.5F);
        
        foreach (Collider obstacle in obstacles)
        {
            if (obstacle.GetComponent<Building>() && !obstacle.transform.Equals(item))
            {
                return;
            }
        }

        item.SetParent(place);
        item.GetComponent<Building>().OnPlaced();
        item = null;
    }
}
