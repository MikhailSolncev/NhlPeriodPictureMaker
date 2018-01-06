using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Windows.Media.Imaging;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace SecondPeriodPictureMaker
{
    class DataManager : Model
    {
        private static Model mInstance;
        private DataManager() { }

        public static Model getInstance()
        {
            if (mInstance == null) mInstance = new DataManager();

            return mInstance;
        }

        public List<Game> lookForSchedule(DateTime date)
        {
            List<Game> result = new List<Game>();

            // http://www.nhl.com/ice/ru/schedulebyday.htm?date=01/04/2017

            //Uri uri = new Uri("http://www.nhl.com/ice/ru/schedulebyday.htm?date=" + String.Format("{0:d}/{0:m}/{0:y}", date));
            Uri uri = new Uri("http://www.nhl.com/ice/ru/schedulebyday.htm?date=" 
                + date.ToString("MM") + "/"
                + date.ToString("dd") + "/"
                + date.ToString("yyyy"));
            string html = new WebClient().DownloadString(uri);

            int posTable = html.IndexOf("<table class=\"data schedTbl\">");
            while (posTable > 0) // if we found table
            {
                html = html.Substring(posTable); // start with it

                int posBody = html.IndexOf("<tbody>");
                int posEndTable= html.IndexOf("</table>");

                if (posBody < posEndTable) // if body starts earlier then table ends
                {
                    html = html.Substring(posBody); // starts with body

                    int posStartLine = html.IndexOf("<tr>"); // for each line
                    while (posStartLine > 0)
                    {
                        html = html.Substring(posStartLine);

                        int posTeam = html.IndexOf("<td class=\"team\">");
                        if (posTeam > 0) // if we found first team
                        {
                            Game game = new Game();

                            html = html.Substring(posTeam + 10);
                            int posRel = html.IndexOf("rel=\"");
                            Team guest = new Team();
                            guest.Name = html.Substring(posRel + 5, 3);

                            posTeam = html.IndexOf("<td class=\"team\">");
                            html = html.Substring(posTeam + 10);
                            posRel = html.IndexOf("rel=\"");
                            Team host = new Team();
                            host.Name = html.Substring(posRel + 5, 3);

                            game.TeamGuest = guest;
                            game.TeamHost = host;

                            result.Add(game);
                        }

                        html = html.Substring(5);
                        posStartLine = html.IndexOf("<tr>");
                    }

                }

                html = html.Substring(5);
                posTable = html.IndexOf("<table class=\"data schedTbl\">");
            }
            return result;
        }

        public Bitmap resizeLogo(string filename)
        {
            Bitmap image = (Bitmap)Image.FromFile(filename);
            return ResizeImage(image, 30);
        }

        public void saveImageToFile(Bitmap image, string filename)
        {
            //FileStream stream = new FileStream(filename, FileMode.Create);
            //PngBitmapEncoder encoder = new PngBitmapEncoder();
            //encoder.Interlace = PngInterlaceOption.On;
            //encoder.Frames.Add(BitmapFrame.Create(image));
            //encoder.Save(stream);

            image.Save(filename, ImageFormat.Png);
        }

        private static Bitmap ResizeImage(Image image, int percent)
        {
            int newHeight = image.Height * percent / 100;
            int newWidth = image.Width * percent / 100;

            return ResizeImage(image, newWidth, newHeight);
        }

        private static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        public void changeGuestColor(Bitmap result, Color guestColor)
        {
            Color colorBlack = Color.FromArgb(0x00000000);
            for (int x = 0; x < result.Width; x++)
            {
                for (int y = 0; y < result.Height; y++)
                {
                    if (result.GetPixel(x, y) == Color.Red)
                    {
                        result.SetPixel(x, y, guestColor);
                    }
                }
            }
        }
    }
}
