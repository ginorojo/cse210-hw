using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private ScriptureReference _reference;
    private List<Word> _words;

    public Scripture(ScriptureReference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public bool AllWordsHidden => _words.All(word => word.IsHidden);

    public string DisplayText
    {
        get
        {
            string wordsText = string.Join(" ", _words);
            return $"{_reference}\n{wordsText}";
        }
    }

    public void HideRandomWords()
    {
        Random random = new Random();
        List<Word> visibleWords = _words.Where(word => !word.IsHidden).ToList();

        if (visibleWords.Count == 0)
            return;

        int wordsToHide = Math.Min(2, visibleWords.Count);

        for (int i = 0; i < wordsToHide; i++)
        {
            Word wordToHide = visibleWords[random.Next(visibleWords.Count)];
            wordToHide.Hide();
            visibleWords.Remove(wordToHide);
        }
    }
}
