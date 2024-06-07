using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using HtmlAgilityPack;

namespace AsciiArtGenerator
{
    public partial class Form1 : Form
    {
        private static readonly Random random = new Random();
        private string currentSearchTerm;

        public Form1()
        {
            InitializeComponent();
            SetDefaultFontSize();

            // Set the initial visibility of the PictureBox to false
            pictureBox.Visible = false;
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Bitmap bitmap = new Bitmap(openFileDialog.FileName);
                    pictureBox.Image = bitmap;
                    GenerateAsciiArt(bitmap);
                }
            }
        }

        private void btnLoadFromUrl_Click(object sender, EventArgs e)
        {
            string url = txtUrl.Text;
            if (Uri.TryCreate(url, UriKind.Absolute, out Uri uriResult) &&
                (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps))
            {
                try
                {
                    using (WebClient webClient = new WebClient())
                    {
                        byte[] imageData = webClient.DownloadData(uriResult);
                        using (var ms = new System.IO.MemoryStream(imageData))
                        {
                            Bitmap bitmap = new Bitmap(ms);
                            pictureBox.Image = bitmap;
                            GenerateAsciiArt(bitmap);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading image from URL: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Invalid URL. Please enter a valid image URL.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRandomize_Click(object sender, EventArgs e)
        {
            try
            {
                
                pictureBox.Visible = false;
                currentSearchTerm = ""; // Clear the current search term
                RandomizeImage();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RandomizeImage()
        {
            // List of additional search terms
            List<string> additionalSearchTerms = new List<string>
    {
                "Drake","Kendrick Lamar","J. Cole","Lil Uzi Vert","Post Malone","Cardi B","Megan Thee Stallion","DaBaby","Future","Kanye West","Chance the Rapper","Young Thug","Lil Baby","Roddy Ricch","Travis Scott","21 Savage","A$AP Rocky","Tyler, The Creator","Juice WRLD","Polo G","Lil Nas X","NLE Choppa","Lil Yachty","Big Sean","Meek Mill","Sheck Wes","Trippie Redd","Denzel Curry","Ski Mask the Slump God","Playboi Carti","Gunna","Wiz Khalifa","XXXTentacion (deceased, but still influential)","A Boogie wit da Hoodie","YoungBoy Never Broke Again","Gucci Mane","Chief Keef","YBN Cordae","Rich the Kid","Kodak Black","Lil Tjay","Blueface","Ty Dolla $ign","2 Chainz","Joey Bada$$","Vince Staples","Migos (group including Quavo, Offset, and Takeoff)","Fetty Wap","Kid Cudi","Schoolboy Q",
                "Tom Hanks","Meryl Streep","Leonardo DiCaprio","Brad Pitt","Angelina Jolie","Jennifer Lawrence","Denzel Washington","Sandra Bullock","Will Smith","Julia Roberts","Johnny Depp","Dwayne Johnson","Scarlett Johansson","Robert Downey Jr.","Tom Cruise","Jennifer Aniston","Charlize Theron","George Clooney","Oprah Winfrey","Morgan Freeman","Nicole Kidman","Matthew McConaughey","Reese Witherspoon","Anne Hathaway","Hugh Jackman","Kate Winslet","Harrison Ford","Ben Affleck","Matt Damon","Mark Wahlberg","Christian Bale","Samuel L. Jackson","Jennifer Lopez","Ryan Reynolds","Emma Watson","Cate Blanchett","Natalie Portman","Jake Gyllenhaal","Anne Hathaway","Bradley Cooper","Jamie Foxx","Amy Adams","Chris Pratt","Gwyneth Paltrow","Keanu Reeves","Halle Berry","Russell Crowe","Liam Neeson","Mila Kunis","Julia Louis-Dreyfus","Tina Fey","Alec Baldwin","Seth Rogen","James Franco","Angelina Jolie","Kristen Stewart","Emma Roberts","Zendaya","Robert Pattinson","Daniel Radcliffe",
                "Abraham Lincoln","George Washington","Martin Luther King Jr.","Albert Einstein","Winston Churchill","Mahatma Gandhi","Cleopatra","Joan of Arc","Julius Caesar","Napoleon Bonaparte","Queen Elizabeth I","Queen Victoria","Alexander the Great","Leonardo da Vinci","Michelangelo","William Shakespeare","Galileo Galilei","Isaac Newton","Charles Darwin","Marie Curie","Thomas Edison","Henry VIII","Elizabeth I","Christopher Columbus","Marco Polo","Genghis Khan","Alexander Hamilton","Benjamin Franklin","Amelia Earhart","Neil Armstrong","Orville and Wilbur Wright","Socrates","Aristotle","Plato","Cleopatra","Ramses II","Queen Nefertiti","Augustus Caesar","Aristotle","Cleopatra","Socrates","Plato","Alexander the Great","Julius Caesar","Queen Elizabeth II","Catherine the Great","Joan of Arc","Leonardo da Vinci","Michelangelo","Vincent van Gogh","Pablo Picasso","William Shakespeare","Ludwig van Beethoven","Wolfgang Amadeus Mozart","Johann Sebastian Bach","Albert Einstein","Isaac Newton","Charles Darwin","Galileo Galilei","Charles Dickens","Mark Twain","Jane Austen","Ernest Hemingway","Virginia Woolf","Emily Dickinson","George Orwell","Frida Kahlo","Rosa Parks","Martin Luther King Jr.","Malcolm X","Mahatma Gandhi","Nelson Mandela","Winston Churchill","Franklin D. Roosevelt","Theodore Roosevelt","Abraham Lincoln","John F. Kennedy","Thomas Jefferson","George Washington","Ronald Reagan","Barack Obama","Donald Trump","Joseph Stalin","Vladimir Lenin","Karl Marx","Che Guevara","Margaret Thatcher","Rosa Parks","Anne Frank","Helen Keller","Marie Antoinette","Joan of Arc","Mary, Queen of Scots","Cleopatra",
                "c#"
            };

            // Combine the additional search terms with "jack nicolson"
            List<string> allSearchTerms = new List<string>(additionalSearchTerms);
            // Randomly select a search term
            currentSearchTerm = allSearchTerms[random.Next(allSearchTerms.Count)];
            if (txtUrl.Text != "")
            {
                currentSearchTerm = txtUrl.Text;
            }


            string url = $"https://images.search.yahoo.com/search/images?p={Uri.EscapeDataString(currentSearchTerm)}";
            //url = $"https://www.bing.com/images/search?q={Uri.EscapeDataString(currentSearchTerm)}";

            HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = null;
            int retries = 0;

            while (retries < 5)
            {
                try
                {
                    doc = web.Load(url);
                    if (doc != null)
                    {
                        var imageNodes = doc.DocumentNode.SelectNodes("//img[@src]")
                            ?.Select(node => node.GetAttributeValue("src", null))
                            .Where(src => !string.IsNullOrEmpty(src) && src.StartsWith("http"))
                            .ToList();

                        if (imageNodes != null && imageNodes.Count > 0)
                        {
                            string randomImageUrl = imageNodes[random.Next(imageNodes.Count)];
                            LoadImageFromUrl(randomImageUrl);
                            return; // Exit the method if an image is found and loaded successfully
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log or handle the exception if necessary
                }

                retries++;
            }

            MessageBox.Show("No images found after 5 attempts.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        private void LoadImageFromUrl(string url)
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    byte[] imageData = webClient.DownloadData(url);
                    using (var ms = new System.IO.MemoryStream(imageData))
                    {
                        Bitmap bitmap = new Bitmap(ms);
                        pictureBox.Image = bitmap;
                        GenerateAsciiArt(bitmap);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading image from URL: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerateAsciiArt(Bitmap image)
        {
            StringBuilder asciiArt = new StringBuilder();
            string grayScale = "@%#*+=-:. ";

            // Adjust font size based on image dimensions
            float fontSize = Math.Max(1, Math.Min(12, Math.Min((float)richTextBoxAsciiArt.Width / image.Width, (float)richTextBoxAsciiArt.Height / image.Height)));

            richTextBoxAsciiArt.Font = new Font("NSimSun", fontSize);

            for (int y = 0; y < image.Height; y += 2)
            {
                for (int x = 0; x < image.Width; x += 1)
                {
                    Color pixelColor = image.GetPixel(x, y);
                    int grayValue = (int)(pixelColor.R * 0.3 + pixelColor.G * 0.59 + pixelColor.B * 0.11);
                    int index = grayValue * (grayScale.Length - 1) / 255;
                    asciiArt.Append(grayScale[index]);
                }
                asciiArt.AppendLine();
            }

            richTextBoxAsciiArt.Text = asciiArt.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveAsciiArt();
        }

        private void SaveAsciiArt()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text Files|*.txt";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    System.IO.File.WriteAllText(saveFileDialog.FileName, richTextBoxAsciiArt.Text);
                }
            }
        }

        private void SetDefaultFontSize()
        {
            richTextBoxAsciiArt.Font = new Font("Courier New", 1.0F);
        }

        private void richTextBoxAsciiArt_Click_1(object sender, EventArgs e)
        {
            string imageUrl = pictureBox.ImageLocation;
            if (!string.IsNullOrEmpty(imageUrl))
            {
                Clipboard.SetText(imageUrl);
                MessageBox.Show($"Font Size: {richTextBoxAsciiArt.Font.Size}\nImage URL: {imageUrl}\nImage URL copied to clipboard.",
                                "Image Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            btnReveal.PerformClick();
        }

        private void btnCopyToClipboard_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(richTextBoxAsciiArt.Text))
            {
                Clipboard.SetText(richTextBoxAsciiArt.Text);
            }
            else
            {
                MessageBox.Show("No ASCII art to copy.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUrl.Text = "";
            richTextBoxAsciiArt.Text = "";
            pictureBox.Visible = false;

        }

        private void btnReveal_Click(object sender, EventArgs e)
        {
            pictureBox.Visible = true;
            // Reveal the search term when clicking the PictureBox
            txtUrl.Text = $"{currentSearchTerm}";
            
        }
    }
}

