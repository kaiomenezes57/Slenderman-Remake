using System.Collections;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace SlendermanRemake.Dialogue
{
    /// <summary>
    /// Core handler.
    /// </summary>
    public partial class DialogueManager : MonoBehaviour
    {
        [SerializeField] private DialogueData _testDialogue;
        private int _index;

        private void Start()
        {
            StartDialogue(_testDialogue);

            DialogueManager dialogueManager = null;
            
            dialogueManager = FindAnyObjectByType<DialogueManager>();
            dialogueManager = FindFirstObjectByType<DialogueManager>();
            dialogueManager = FindObjectOfType<DialogueManager>();

            Debug.Log($"Founded? {dialogueManager}");
        }

        public void StartDialogue(DialogueData dialogue)
        {
            ResetVisual();
            StartCoroutine(WriteMessageOnScreen(dialogue));
        }
    }

    /// <summary>
    /// Visual handler.
    /// </summary>
    public partial class DialogueManager
    {
        [SerializeField] private GameObject _dialogueBox;
        [SerializeField] private TextMeshProUGUI _textMeshPro;

        private IEnumerator WriteMessageOnScreen(DialogueData dialogue)
        {
            _textMeshPro.text = dialogue.GetNextMessage(_index);
            _textMeshPro.ForceMeshUpdate();

            int totalVisiblesCharacters = _textMeshPro.textInfo.characterCount;
            int counter = 0;

            _dialogueBox.SetActive(true);

            while (true)
            {
                _textMeshPro.maxVisibleCharacters = counter;

                if (counter >= totalVisiblesCharacters)
                {
                    break;
                }

                counter++;
                yield return new WaitForSeconds(0.1f);
            }
            
            _index++;
            yield return new WaitForSeconds(2f);
            CheckNextDialogue(dialogue);
        }

        private void CheckNextDialogue(DialogueData dialogue)
        {
            if (!dialogue.CheckNextDialogueExists(_index))
            {
                ResetVisual();
                return;
            }

            StopAllCoroutines();
            StartCoroutine(WriteMessageOnScreen(dialogue));
        }

        private void ResetVisual()
        {
            _dialogueBox.SetActive(false);
            _textMeshPro.text = null;

            _index = 0;
        }
    }
}
