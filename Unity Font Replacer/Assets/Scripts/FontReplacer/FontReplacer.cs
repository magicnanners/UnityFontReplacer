using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace FontReplacer
{

    [ExecuteInEditMode]
    public class FontReplacer : MonoBehaviour
    {

        public Font replacementFont;

        private int ignoreCount;
        private int replacedCount;

        public void ReplaceAllInScene()
        {
            if (replacementFont == null)
            {
                Debug.LogError("Error, no replacement font selected.");
            }
            else
            {
                Text[] sceneTexts = FindObjectsOfType<Text>();
                for (int i = 0; i < sceneTexts.Length; i++)
                {
                    bool test = GetComponent<FontReplacementIgnore>();
                    if (test == true)
                    {
                        //Do Nothing
                        ignoreCount++;
                    }
                    else
                    {
                        sceneTexts[i].font = replacementFont;
                        replacedCount++;
                    }
                }
                RefreshTexts(sceneTexts[0]);
                Debug.Log("Replaced " + replacedCount + " fonts in scene. Ignored " + ignoreCount + ".");
                ResetCounts();
            }
        }

        public void ReplaceAllChildren()
        {
            if (replacementFont == null)
            {
                Debug.LogError("Error, no replacement font selected.");
            }
            else
            {
                Text[] sceneTexts = GetComponentsInChildren<Text>();
                for (int i = 0; i < sceneTexts.Length; i++)
                {
                    bool test = GetComponent<FontReplacementIgnore>();
                    if (test == true)
                    {
                        //Do Nothing
                        ignoreCount++;
                    }
                    else
                    {
                        sceneTexts[i].font = replacementFont;
                        replacedCount++;
                    }
                }
                RefreshTexts(sceneTexts[0]);
                Debug.Log("Replaced " + replacedCount + " fonts in scene. Ignored " + ignoreCount + ".");
                ResetCounts();
            }
        }

        void ResetCounts()
        {
            replacedCount = 0;
            ignoreCount = 0;
        }

        void RefreshTexts(Text randomText)
        {
            Text refreshText = Instantiate<Text>(randomText);
            DestroyImmediate(refreshText.gameObject);
        }
    }
}
