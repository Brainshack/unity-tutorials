﻿using System;

 namespace Tutorials.DialogSystem.Scripts
{
    [Serializable]
    public class DialogSegment
    {

        public string DialogText;

        public string Answer1;

        public string Answer2;

        public string Answer3;

        public string Answer4;

        public int SegmentAfterAnswer1 = -1;
        public int SegmentAfterAnswer2 = -1;
        public int SegmentAfterAnswer3 = -1;
        public int SegmentAfterAnswer4 = -1;
    }
}