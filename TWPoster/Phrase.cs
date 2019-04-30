namespace TWPoster
{
    class Phrase
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string ImagePath { get; set; }

        public override string ToString()
        {
            return $"{Id} - {Text}";
        }
    }
}
