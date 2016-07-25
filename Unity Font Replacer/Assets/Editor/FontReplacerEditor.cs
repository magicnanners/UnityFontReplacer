using UnityEngine;
using UnityEditor;

namespace FontReplacer
{

    [CustomEditor(typeof(FontReplacer))]
    public class FontReplacerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            FontReplacer myFontReplacer = (FontReplacer)target;
            if (GUILayout.Button("Replace All In Scene"))
            {
                myFontReplacer.ReplaceAllInScene();
            }
            if (GUILayout.Button("Replace All Children"))
            {
                myFontReplacer.ReplaceAllChildren();
            }
        }
    }
}
