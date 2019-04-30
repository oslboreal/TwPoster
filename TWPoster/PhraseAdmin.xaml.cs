using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TWPoster
{
    /// <summary>
    /// Interaction logic for PhraseAdmin.xaml
    /// </summary>
    public partial class PhraseAdmin : Window
    {
        /// <summary>
        /// Constructor method.
        /// </summary>
        public PhraseAdmin()
        {
            InitializeComponent();
            LoadPhrases();
        }
        
        /// <summary>
        /// This method add a new phrase to the collection.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Boton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox.Text))
                if (!(textBox.Text.Length > 280))
                    PhrasesManager.SaveNewPhrase(textBox.Text, string.Empty);
                else
                    MessageBox.Show("Cantidad maxima de caracteres superada - Max characters count exceded..");
            else
                MessageBox.Show("Debe rellenar el campo de la frase - You must fill the field to add a phrase.");

            LoadPhrases();
        }

        /// <summary>
        /// Method that load all the phrases from the json file.
        /// </summary>
        private void LoadPhrases()
        {
            var item = new ListBoxItem();
            listBox.ItemsSource = PhrasesManager.Phrases; ;
        }
    }
}
