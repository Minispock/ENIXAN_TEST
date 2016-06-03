using UnityEngine;


public class ShopButton : MonoBehaviour {

    public void ShButton()
    {
        gameObject.SetActive(!gameObject.activeInHierarchy);
    }        
}
