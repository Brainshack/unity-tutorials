using System.Collections.Generic;
using UnityEngine;

namespace Tutorials.Dialog_System.Part_1.Scripts
{
    [CreateAssetMenu(fileName = "New Dialog", menuName = "Dialog/Dialog", order = 0)]
    public class Dialog : ScriptableObject
    {

        public List<DialogSegment> segments;

    }
}