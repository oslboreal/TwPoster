namespace TWPoster
{
    class Phrase
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string ImagePath { get; set; }

        public Phrase(int Id, string Text, string ImagePath)
        {
            this.Id = Id;
            this.Text = Text;
            this.ImagePath = ImagePath;
        }

        public override string ToString()
        {
            return $"{Id} - {Text}";
        }
    }
}
