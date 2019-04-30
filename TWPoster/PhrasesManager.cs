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
        public static List<Phrase> Phrases { get; set; }

        const string phrasesLatestIdFile = "latestPhraseId.json";
        const string phrasesFile = "phrases.json";

        static bool saveNewPhrase(string content, string imagePath)
        {
            try
            {
                if (!File.Exists(phrasesFile))
                    File.Create(phrasesFile).Close();

                List<Phrase> phrases = obtainAllPhrases();

                Phrase p1 = new Phrase
                {
                    ImagePath = imagePath,
                    Text = content,
                    Id = obtainMaxId() + 1
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

        static List<Phrase> obtainAllPhrases()
        {
            if (File.Exists(phrasesFile))
            {
                // Reads all the text from phrases file..
                string content = File.ReadAllText(phrasesFile);

                // Obtains phrases.
                List<Phrase> phrases = JsonConvert.DeserializeObject<List<Phrase>>(content);

                return phrases;
            }
            else
            {
                return new List<Phrase>();
            }
        }

        static int obtainMaxId()
        {
            var phrases = obtainAllPhrases();

            int maxId = 0;

            foreach (var item in phrases)
                if (item.Id > maxId)
                    maxId = item.Id;

            return maxId;
        }

        static string obtainNextPhrase()
        {
            if (!File.Exists("phrases.json"))
                File.Create("phrases.json").Close();


            using (StreamReader reader = new StreamReader(phrasesLatestIdFile))
            {
                string content = reader.ReadToEnd();
                List<Phrase> phrases = JsonConvert.DeserializeObject<List<Phrase>>(content);
                phrases.OrderBy(x => x.Id);

                MessageBox.Show(phrases.Count.ToString());
            }


            return "";
        }

        static int obtainLatestPhraseId()
        {

            // If the file that we use to know the id of the latest showed phrase doesn't exist.
            // Creates it.
            if (!File.Exists(phrasesLatestIdFile))
            {
                File.WriteAllText(phrasesLatestIdFile, "0");
                File.Create(phrasesLatestIdFile).Close();
            }

            int retorno = 0;
            int.TryParse(File.ReadAllText(phrasesLatestIdFile), out retorno);

            return retorno;
        }
    }

}
