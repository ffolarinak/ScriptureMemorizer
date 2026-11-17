
using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        string[] words = text.Split(' ');

        foreach (string word in words)
        {
            _words.Add(new Word(word));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();

        for (int i = 0; i < numberToHide; i++)
        {
            List<Word> visibleWords = _words
                .Where(word => !word.IsHidden())
                .ToList();

            if (visibleWords.Count == 0)
            {
                break;
            }

            int index = random.Next(visibleWords.Count);

            visibleWords[index].Hide();
        }
    }

    public void ShowRandomWord()
    {
        List<Word> hiddenWords = _words
            .Where(word => word.IsHidden())
            .ToList();

        if (hiddenWords.Count == 0)
        {
            return;
        }

        Random random = new Random();
        int index = random.Next(hiddenWords.Count);

        hiddenWords[index].Show();
    }

    public string GetDisplayText()
    {
        List<string> displayWords = new List<string>();

        foreach (Word word in _words)
        {
            displayWords.Add(word.GetDisplayText());
        }

        return $"{_reference.GetDisplayText()} {string.Join(" ", displayWords)}";
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }

        return true;
    }
}
