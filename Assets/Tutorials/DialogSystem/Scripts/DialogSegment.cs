using System;
 using System.Collections.Generic;

 namespace Tutorials.DialogSystem.Scripts
{
    [Serializable]
    public class DialogSegment
    {
        public DialogSegment()
        {
            Answers = new List<string>();
            SegmentAfterAnswer = new List<int>();
        }

        public string DialogText;

        public List<string> Answers;
        
        public List<int> SegmentAfterAnswer;
        
    }
}