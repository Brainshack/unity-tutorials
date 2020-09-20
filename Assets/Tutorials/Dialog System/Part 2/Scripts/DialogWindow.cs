using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Part2
{
    public class DialogWindow : MonoBehaviour
    {
        public TMP_Text dialogText;

        public Button Option1Button;
        public Button Option2Button;
        public Button Option3Button;
        public Button Option4Button;

        public Dialog activeDialog;
    
        private int segmentIndex = 0;
    
        void Start()
        {
            UpdateDialog(activeDialog.segments[segmentIndex]);   
        }

        public void AnswerClicked(int answerIndex)
        {
            switch (answerIndex)
            {    
                case  0:
                    segmentIndex = activeDialog.segments[segmentIndex].SegmentAfterAnswer1;
                    break;
                case  1:
                    segmentIndex = activeDialog.segments[segmentIndex].SegmentAfterAnswer2;
                    break;
                case  2:
                    segmentIndex = activeDialog.segments[segmentIndex].SegmentAfterAnswer3;
                    break;
                case  3:
                    segmentIndex = activeDialog.segments[segmentIndex].SegmentAfterAnswer4;
                    break;
            }

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
            Option1Button.GetComponentInChildren<Text>().text = newSegment.Answer1;
            Option2Button.GetComponentInChildren<Text>().text = newSegment.Answer2;
            Option3Button.GetComponentInChildren<Text>().text = newSegment.Answer3;
            Option4Button.GetComponentInChildren<Text>().text = newSegment.Answer4;
        }
    }
}