using UnityEngine;

public class doorInteract : MonoBehaviour
{
    public GameObject Door;
    public Animator doorOpener;
    public GameObject Key;
    bool inRange;
    bool isDoorOpen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        doorOpener = GetComponent<Animator>();
        isDoorOpen = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("player can open");
            inRange = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        inRange = false;

    }
    // Update is called once per frame
    void Update()
    {
        if(inRange && Input.GetButtonDown("Interact"))
        {
            doorOpener.SetTrigger("openDoor");
            Debug.Log("Animation Playing");
            Key.SetActive(true);
        }
    }
}
