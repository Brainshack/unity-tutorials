using System;
 using System.Collections.Generic;
using XNode;

namespace Tutorials.DialogSystem.Scripts
{
    [Serializable]
    public struct Connection {}
    public class DialogSegment: Node
    {
        [Input]
        public Connection input;
        
        public string DialogText;

        [Output(dynamicPortList = true)]
        public List<string> Answers;


        public override object GetValue(NodePort port)
        {
            return null;
        }
    }
}