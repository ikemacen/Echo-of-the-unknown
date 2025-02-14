using UnityEngine;
using TMPro;

public class interactAlert : MonoBehaviour
{
    public GameObject interact;
    public bool alertOn;
    void start()
    {
        interact = gameObject.GetComponent<GameObject>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("entered");
            interact.SetActive(true);
            alertOn = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        interact.SetActive(false);
        alertOn = false;
    }
}
