using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows;

namespace TWPoster
{
    public class MainProcess
    {
        private TimeSpan tiempoEspera = TimeSpan.FromMinutes(60);

        private static MainProcess _instance = new MainProcess();

        public static MainProcess Instance
        {
            get
            {
                return _instance;
            }
        }

        private Timer timer;

        public MainProcess()
        {

        }

        public void Start()
        {
            timer = new Timer(timer_callBack);
            timer.Change(0, 0);
        }

        private void timer_callBack(object state)
        {
            try
            {
                string nextPhrase = PhrasesManager.ObtainNextPhrase();
                DrawText(nextPhrase, new Font("Arial", 34), Color.Red, Color.Black);
                Jarvis.sendTweet(nextPhrase);
            }
            catch (Exception ex)
            {
                File.WriteAllText("log_process.err", ex.Message);
                MessageBox.Show("Error a la hora de obtener la nueva frase.");
            }
            finally
            {
                timer.Change(tiempoEspera, TimeSpan.Zero);
            }
        }

        private void DrawText(String text, Font font, Color textColor, Color backColor)
        {
            //first, create a dummy bitmap just to get a graphics object
            System.Drawing.Image img = new Bitmap(1, 1);
            Graphics drawing = Graphics.FromImage(img);

            //measure the string to see how big the image needs to be
            SizeF textSize = drawing.MeasureString(text, font);

            //free up the dummy image and old graphics object
            img.Dispose();
            drawing.Dispose();

            //create a new image of the right size
            img = new Bitmap(500, 500);

            drawing = Graphics.FromImage(img);

            //paint the background
            drawing.Clear(backColor);

            //create a brush for the text
            Brush textBrush = new SolidBrush(textColor);

            text = "PRIMER LINEA\nSEGUNDA LINEA";
            drawing.DrawString(text, font, textBrush, 250, 250);

            drawing.Save();

            textBrush.Dispose();
            drawing.Dispose();

            img.Save("salida.png", System.Drawing.Imaging.ImageFormat.Png);
        }
    }
}
