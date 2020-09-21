using System.Collections.Generic;
using UnityEngine;

namespace Tutorials.DialogSystem.Scripts
{
    [CreateAssetMenu(fileName = "New Dialog", menuName = "Dialog Part 2/Dialog", order = 0)]
    public class Dialog : ScriptableObject
    {

        public List<DialogSegment> segments;

    }
}