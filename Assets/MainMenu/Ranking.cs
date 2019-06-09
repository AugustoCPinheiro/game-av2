using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranking : MonoBehaviour
{

    private Transform entryContainer;
    private Transform entryTemplate;
    private List<HighScoreEntry> highScoreEntryList;
    private List<Transform> highScoreEntryTransformList;

    private void Awake()
    {
        entryContainer = transform.Find("highScoreEntryContainer");
        entryTemplate = transform.Find("highScoreEntryTemplate");
        entryTemplate.gameObject.SetActive(false);

        highScoreEntryList = new List<HighScoreEntry>()
        {
            new HighScoreEntry{score = 1234, name = "Ricardo"},
            new HighScoreEntry{score = 1234, name = "Augusto"},
            new HighScoreEntry{score = 1234, name = "Berg"},
            new HighScoreEntry{score = 1234, name = "Vinicius"},
            new HighScoreEntry{score = 1234, name = "Alef"},
        };

        highScoreEntryTransformList = new List<Transform>();

        foreach(HighScoreEntry highScoreEntry in highScoreEntryList)
        {
            CreateHighScoreEntryTransform(highScoreEntry, entryContainer, highScoreEntryTransformList);
        }
    }

    private void CreateHighScoreEntryTransform(HighScoreEntry highScoreEntry, Transform container, List<Transform> transformList)
    {
        float templateheight = 20f;

        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateheight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        string rank = (transformList.Count + 1) + "º";
        string score = highScoreEntry.score + "";
        string name = highScoreEntry.name;

        entryTransform.Find("posText").GetComponent<TextEditor>().text = rank;
        entryTransform.Find("scoreText").GetComponent<TextEditor>().text = score;
        entryTransform.Find("nameText").GetComponent<TextEditor>().text = name;

        transformList.Add(entryTransform);
    }

    private class HighScoreEntry
    {
        public int score;
        public string name;
    }
}
