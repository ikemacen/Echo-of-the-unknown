using UnityEngine;

public class exitClick : MonoBehaviour
{
    public GameObject controls;

    void Start()
    {
        //controls = gameObject.GetComponent<GameObject>();
    }
    void Update()
    {
        if(Input.GetButtonDown("Interact"))
        {
            controls.SetActive(false);
        }
    }
}
