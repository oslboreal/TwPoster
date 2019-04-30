using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TWPoster
{
    static class PhrasesManager
    {
        public static List<Phrase> Phrases
        {
            get
            {
                return ObtainAllPhrases();
            }
        }

        const string phrasesLatestIdFile = "latestPhraseId.json";
        const string phrasesFile = "phrases.json";

        static PhrasesManager()
        {

        }

        public static bool SaveNewPhrase(string content, string imagePath)
        {
            try
            {
                if (!File.Exists(phrasesFile))
                    File.Create(phrasesFile).Close();

                List<Phrase> phrases = ObtainAllPhrases();

                Phrase p1 = new Phrase
                {
                    ImagePath = imagePath,
                    Text = content,
                    Id = ObtainMaxId() + 1
                };

                phrases.Add(p1);

                // Serializes the collection.
                string json = JsonConvert.SerializeObject(phrases, Formatting.Indented);

                File.WriteAllText(phrasesFile, json);

                return true;
            }
            catch (Exception)
            {
                // TODO : LOG.
                return false;
            }
        }

        static List<Phrase> ObtainAllPhrases()
        {
            if (File.Exists(phrasesFile))
            {
                // Reads all the text from phrases file..
                string content = File.ReadAllText(phrasesFile);

                // Obtains phrases.
                List<Phrase> phrases = JsonConvert.DeserializeObject<List<Phrase>>(content);

                if (phrases == null)
                    phrases = new List<Phrase>();

                return phrases;
            }
            else
            {
                return new List<Phrase>();
            }
        }

        static int ObtainMaxId()
        {
            var phrases = ObtainAllPhrases();

            int maxId = 0;

            foreach (var item in phrases)
                if (item.Id > maxId)
                    maxId = item.Id;

            return maxId;
        }

        static public string ObtainNextPhrase()
        {
            Phrase found = null;

            if (!File.Exists(phrasesFile))
                File.WriteAllText(phrasesFile, "[]");

            // Gets the next id and fetch all the phrases.
            int nextId = GetNextId();
            var phrases = ObtainAllPhrases();

            // Look up for a phrase.
            foreach (var item in phrases)
                if (item.Id == nextId)
                    found = item;

            // If the phrase ain't here
            if (found == null)
            {
                // Look up for a phrase.
                foreach (var item in phrases)
                    if (item.Id == 1)
                        found = item;

                // The collection haven't phrases.
                if(found == null)
                    return null;

                // Restar the next id.
                SetNextId(2);
            }

            return found.ToString();
        }

        static private void SetNextId(int id)
        {
            if (!File.Exists(phrasesLatestIdFile))
                File.WriteAllText(phrasesLatestIdFile, "0");
            else
                File.WriteAllText(phrasesLatestIdFile, id.ToString());
        }

        static private int GetNextId()
        {
            int retorno = 0;

            // If the file that we use to know the id of the latest showed phrase doesn't exist.
            // Creates it.
            if (!File.Exists(phrasesLatestIdFile))
                File.WriteAllText(phrasesLatestIdFile, retorno.ToString());

            int.TryParse(File.ReadAllText(phrasesLatestIdFile), out retorno);

            return retorno;
        }
    }

}
