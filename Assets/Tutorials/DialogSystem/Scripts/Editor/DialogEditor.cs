using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Tutorials.DialogSystem.Scripts.Editor
{
    [CustomEditor(typeof(Dialog))]
    public class DialogEditor : UnityEditor.Editor
    {
        private Dialog _dialog;
        private List<bool> _showSegments;

        public void OnEnable()
        {
            _dialog = target as Dialog;
            _showSegments = new List<bool>();
            for (int i = 0; i < _dialog.segments.Count; i++)
            {
                _showSegments.Add(false);
            }
        }

        public override void OnInspectorGUI()
        {
            for (int i = 0; i < _dialog.segments.Count; i++)
            {
                var segment = _dialog.segments[i];
                var show = _showSegments[i];
                _showSegments[i] = EditorGUILayout.Foldout(show, segment.DialogText); 
                
                
                if (_showSegments[i])
                {
                    GUILayout.Label("Dialog Text");
                    segment.DialogText = AnswerText(segment.DialogText);

                    for (int answerIndex = 0; answerIndex < segment.Answers.Count; answerIndex++)
                    {
                        
                        segment.SegmentAfterAnswer[answerIndex] = SegmentSelection(segment.SegmentAfterAnswer[answerIndex], $"Answer {answerIndex+1} => ");
                        segment.Answers[answerIndex] = AnswerText(segment.Answers[answerIndex]);
                        if (GUILayout.Button("Delete Choice"))
                        {
                            segment.Answers.RemoveAt(i);
                            segment.SegmentAfterAnswer.RemoveAt(i);
                        }
                    }

                    if (GUILayout.Button("Add Choice"))
                    {
                        segment.Answers.Add("New Choice");
                        segment.SegmentAfterAnswer.Add(-1);
                    }
                    
                    if (GUILayout.Button("Remove Segment"))
                    {
                        _dialog.segments.Remove(segment);
                        _showSegments.RemoveAt(i);
                    }
                }
                _dialog.segments[i] = segment;
            }
            
            
            if (GUILayout.Button("Add Dialog Segment"))
            {
                _dialog.segments.Add(new DialogSegment() {DialogText = "New Dialog Segment Text"});
                _showSegments.Add(false);
            }
        }

        private int SegmentSelection(int selected, string label)
        {
            List<string> options = new List<string>(_dialog.segments.Count);
            
            foreach (var s in _dialog.segments)
            {
                options.Add(s.DialogText);
            }

            selected = EditorGUILayout.Popup(label, selected, options.ToArray());
            return selected;
        }

        private string AnswerText(string input)
        {
            return GUILayout.TextArea(input, new GUILayoutOption[]
            {
                GUILayout.MinHeight(50)
            });
        }
    }
}