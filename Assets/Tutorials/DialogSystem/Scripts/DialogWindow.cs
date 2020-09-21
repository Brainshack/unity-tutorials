using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tutorials.DialogSystem.Scripts
{
    public class DialogWindow : MonoBehaviour
    {
        public TMP_Text dialogText;

        public List<Button> OptionButtons;

        public Dialog activeDialog;

        public GameObject buttonPrefab;

        public Transform buttonParent;

        private int segmentIndex = 0;

        void Start()
        {
            UpdateDialog(activeDialog.segments[segmentIndex]);
        }

        public void AnswerClicked(int answerIndex)
        {
            segmentIndex = activeDialog.segments[segmentIndex].SegmentAfterAnswer[answerIndex];
            
            if (segmentIndex < 0)
            {
                gameObject.SetActive(false);
                segmentIndex = 0;
            }
            else
            {
                UpdateDialog(activeDialog.segments[segmentIndex]);
            }
        }

        private void UpdateDialog(DialogSegment newSegment)
        {
            dialogText.text = newSegment.DialogText;
            int answerIndex = 0;
            foreach (Transform child in buttonParent) {
                Destroy(child.gameObject);
            }
            foreach (var answer in newSegment.Answers)
            {
                var btn = Instantiate(buttonPrefab, buttonParent);
                btn.GetComponentInChildren<Text>().text = answer;

                var index = answerIndex;
                btn.GetComponentInChildren<Button>().onClick.AddListener((() =>
                        {
                            AnswerClicked(index);
                        }));

                answerIndex++;
            }
        }
    }
}