using System.IO;
using System.Diagnostics;
using Scrabble.Utility;


namespace Scrabble.Verification
{
    public class WordChecker
    {
        NetSpell.SpellChecker.Dictionary.WordDictionary oDict;
        NetSpell.SpellChecker.Spelling oSpell;

        public WordChecker()
        {
            oDict = new NetSpell.SpellChecker.Dictionary.WordDictionary();
            oDict.DictionaryFile = "en-US.dic";
            oDict.Initialize();
            oSpell = new NetSpell.SpellChecker.Spelling();
            oSpell.Dictionary = oDict;
        }

        public bool CheckWord(string word)
        {
           return oSpell.TestWord(word);
        }


    }
}