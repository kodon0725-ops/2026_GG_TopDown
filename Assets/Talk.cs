using UnityEngine;
using UnityEngine.Events;

public class Talk : MonoBehaviour
{
    public DialogueLine[] lines;
    public string choice1;
    public string choice2;
    public UnityEvent onChoice1;
    public UnityEvent onChoice2;
    public GameObject prompt;
    public DialogueBox dialogueBox;
    public void Say()
    {
        dialogueBox.Open(this);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            prompt.SetActive(true);
            dialogueBox.nearTalk = this;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            prompt.SetActive(false);
            dialogueBox.nearTalk = null;
        }
    }
}
