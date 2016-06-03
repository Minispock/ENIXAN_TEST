using UnityEngine;


public class Square : MonoBehaviour
{

    public int X { get; set; }
    public int Z { get; set; }

    private GameObject treePrefab;
    private GameObject rock001Prefab;
    private GameObject rock002Prefab;

    private void Awake()
    {
        treePrefab = Resources.Load<GameObject>("Tree001");
        rock001Prefab = Resources.Load<GameObject>("Rock001");
        rock002Prefab = Resources.Load<GameObject>("Rock002");
    }

    void Start()
    {
        CreateObstacles();
    }

    private void CreateTree()
    {
        GameObject tree = Instantiate(treePrefab, transform.position, Quaternion.identity) as GameObject;
        tree.transform.SetParent(transform);
        tree.transform.localScale += new Vector3(0.0F, Random.Range(-0.3F, 0.0F), 0);
    }

    private void CreateObstacles()
    {
        bool result0 = X == 0 || X == Map.Width - 1 || Z == 0 || Z == Map.Length - 1;
        bool result1 = (X == 1 || X == Map.Width - 2 || Z == 1 || Z == Map.Length - 2) && Random.value > 0.35F;
        bool result2 = (X == 2 || X == Map.Width - 3 || Z == 2 || Z == Map.Length - 3) && Random.value > 0.8F;

        GameObject prefab = null;

        if (result0 || result1) prefab = treePrefab;
        else if (result2) prefab = Choose(treePrefab, rock001Prefab, rock002Prefab);
        else return;

        GameObject obstacle = Instantiate(prefab, transform.position, Quaternion.identity) as GameObject;
        obstacle.transform.SetParent(transform);
        obstacle.transform.localScale += new Vector3(0.0F, Random.Range(-0.3F, 0.0F), 0);
        obstacle.transform.Rotate(obstacle.transform.up, Random.Range(-180, 180));
    }

    private T Choose<T>(params T[] items)
    {
        return items[Random.Range(0, items.Length)];
    }
}



