using UnityEngine;
public class Door : MonoBehaviour
{
    public Transform target;
    public GameObject prompt;
    public DialogueBox dialogueBox;
    public int needKeys = 0;
    public Talk lockedTalk;
    private Transform player;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.transform;
            prompt.SetActive(true);
            dialogueBox.nearDoor = this;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            prompt.SetActive(false);
            dialogueBox.nearDoor = null;
        }
    }
    public void Use()
    {
        Inventory inventory = player.GetComponent<Inventory>();
        if (inventory.keys >= needKeys)
        {
            player.position = target.position;
        }
        else { lockedTalk.Say(); }
    }
}

