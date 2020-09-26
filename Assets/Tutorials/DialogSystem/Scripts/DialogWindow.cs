using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tutorials.DialogSystem.Scripts
{
    public class DialogWindow : MonoBehaviour
    {
        public TMP_Text dialogText;

        public DialogGraph activeDialog;

        public GameObject buttonPrefab;

        public Transform buttonParent;

        private int segmentIndex = 0;

        private DialogSegment activeSegment;

        void Start()
        {
            // Find Start Node
            foreach (DialogSegment node in activeDialog.nodes)
            {
                if (!node.GetInputPort("input").IsConnected)
                {
                    UpdateDialog(node);
                    break;
                }
            }
        }

        public void AnswerClicked(int clickedIndex)
        {
            var port = activeSegment.GetPort("Answers " + clickedIndex);
            if (port.IsConnected)
                UpdateDialog(port.Connection.node as DialogSegment);
            else
                gameObject.SetActive(false);
        }

        private void UpdateDialog(DialogSegment newSegment)
        {
            activeSegment = newSegment;
            dialogText.text = newSegment.DialogText;
            int answerIndex = 0;
            foreach (Transform child in buttonParent)
            {
                Destroy(child.gameObject);
            }

            foreach (var answer in newSegment.Answers)
            {
                var btn = Instantiate(buttonPrefab, buttonParent);
                btn.GetComponentInChildren<Text>().text = answer;

                var index = answerIndex;
                btn.GetComponentInChildren<Button>().onClick.AddListener((() => { AnswerClicked(index); }));

                answerIndex++;
            }
        }
    }
}