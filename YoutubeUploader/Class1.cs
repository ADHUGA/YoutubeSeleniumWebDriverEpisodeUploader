//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.Interactions;
//using OpenQA.Selenium.Support.UI;




//namespace YoutubeUploader
//{
//    public partial class Form1 : Form
//    {
//        /*TO-DO
//         * Display if Signed In or NOT
//         * Display Current Time
//         * PICK TIME To Upload
//         * 
//         * 
//         * Upload Video First
//         * Then Go to Recent videos. And do the duplicate thing
//         * Sek9Magix avc-aac mp4-internet hd 1080p 59.94 fps[0].mp4
//         * NO HYPENS OR UNDERSCORES IN TITLE of uplading video
//         * */


//        public Form1()
//        {
//            InitializeComponent();
//            dateTimePicker1.Format = DateTimePickerFormat.Custom; //Lets me set to whatever format
//            dateTimePicker1.CustomFormat = "MMMM d, yyyy HH:mm "; //Lets me use this specific Format
//            dateTimePicker1.Value = DateTime.Now.AddHours(1); //Sets Current Value to Today
//            dateTimePicker1.MinDate = DateTime.Now; //Makes Minimum Value also to Today




//        }



//        public string VideoLocation;
//        public string ThumbnailLocation;
//        public string[] VideoNames;
//        public string FirstVideoName;

//        private void Form1_Load(object sender, EventArgs e)
//        {

//        }





//        private void button1_Click(object sender, EventArgs e)
//        {
//            TimeZoneInfo estTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
//            DateTime selectedDateTime = dateTimePicker1.Value;
//            DateTime estDateTime = TimeZoneInfo.ConvertTime(selectedDateTime, estTimeZone);
//            DateTime changingEstDateTime = estDateTime;
//            int dumbcounter = 0;
//            int reallydumbcounter = 1;



//            ChromeOptions options = new ChromeOptions();
//            options.AddArgument("user-data-dir=C:\\Users\\drewh\\AppData\\Local\\Google\\Chrome\\User Data");
//            options.AddArgument("--disable-popup-blocking");

//            IWebDriver driver = new ChromeDriver(options);
//            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
//            driver.Navigate().GoToUrl("https://www.youtube.com"); //Goes to the website
//            System.Threading.Thread.Sleep(1800);

//            wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));

//            driver.FindElement(By.CssSelector("#button > #button > .ytd-topbar-menu-button-renderer")).Click(); //Clicks on the Upload ICON
//            {
//                var element = driver.FindElement(By.CssSelector("#button > #button > .ytd-topbar-menu-button-renderer"));
//                Actions builder = new Actions(driver);
//                builder.MoveToElement(element).Perform();
//            }
//            wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete")); //Clicks on the Upload Video
//            {
//                var element = driver.FindElement(By.TagName("body"));
//                Actions builder = new Actions(driver);
//                builder.MoveToElement(element, 0, 0).Perform();
//            }
//            IWebElement element1 = driver.FindElement(By.CssSelector(".style-scope:nth-child(1) #endpoint #label"));
//            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
//            jsExecutor.ExecuteScript("arguments[0].click();", element1);

//            element1 = driver.FindElement(By.CssSelector("#select-files-button > .label")); //Clicks on the button on the second page that brings up the file explorer.
//            element1.Click();



//            System.Threading.Thread.Sleep(4000);


//            foreach (string VideoName in VideoNames)
//            {
//                System.Threading.Thread.Sleep(2500);
//                SendKeys.SendWait(VideoLocation);
//                System.Threading.Thread.Sleep(2500);
//                SendKeys.SendWait("{ENTER}");
//                System.Threading.Thread.Sleep(2500);
//                SendKeys.SendWait(VideoName);
//                System.Threading.Thread.Sleep(2500);
//                SendKeys.SendWait("{ENTER}");
//                //URL is highlighted?

//                IWebElement bodyElement = driver.FindElement(By.TagName("body"));
//                bodyElement.Click();

//                System.Threading.Thread.Sleep(3000);
//                element1 = driver.FindElement(By.CssSelector("#reuse-details-button > .label"));  //Clicks on Resuse
//                System.Threading.Thread.Sleep(1800);
//                element1.Click();
//                element1 = driver.FindElement(By.CssSelector("#search-yours")); //Clicks on finding videos with similiar names
//                System.Threading.Thread.Sleep(1800);
//                element1.Click();
//                System.Threading.Thread.Sleep(1800);
//                element1.SendKeys(FirstVideoName); //Types in the BASE Name
//                System.Threading.Thread.Sleep(2000);
//                //element1 = driver.FindElement(By.CssSelector(".card:nth-child(1) .title")); //Clicks on the video to copy from
//                element1 = driver.FindElement(By.XPath("//ytcp-entity-card/div/div[2]"));
//                System.Threading.Thread.Sleep(1800);//Gotten here1
//                element1.Click(); //Some weird shit is going on here. I think it happens if video is still deleting.
//                element1 = driver.FindElement(By.CssSelector("#select-button > .label"));
//                System.Threading.Thread.Sleep(1800);
//                element1.Click();
//                System.Threading.Thread.Sleep(3000);
//                element1 = driver.FindElement(By.CssSelector("#title-textarea > #container > #outer > #child-input > #container-content #textbox"));
//                System.Threading.Thread.Sleep(1800);
//                element1.Click();
//                System.Threading.Thread.Sleep(1800);
//                element1 = driver.FindElement(By.CssSelector("#title-textarea > #container > #outer > #child-input > #container-content #textbox"));
//                element1.Click();
//                System.Threading.Thread.Sleep(1800);
//                element1.SendKeys(OpenQA.Selenium.Keys.Control + "a");  // Select all text
//                System.Threading.Thread.Sleep(1800);
//                element1.SendKeys(OpenQA.Selenium.Keys.Control + "c");
//                string copiedText = Clipboard.GetText(); //Name of previous Youtube titles
//                //MessageBox.Show("The copiedText is " + copiedText);
//                int index = copiedText.IndexOf('#'); //Location of # in the youtube title
//                //MessageBox.Show("The index of # is " + index);
//                string title = copiedText.Substring(0, index + 1); //Base youtube name
//                //MessageBox.Show("The Title is " + title);
//                char currentNumbertext = copiedText[index + 1]; //Gotten here2
//                //MessageBox.Show("The current number TEXT is " + currentNumbertext); //The number is 8 which is correct
//                int currentNumber;
//                int.TryParse(currentNumbertext.ToString(), out currentNumber);
//                //MessageBox.Show("The current number is " + currentNumber); //56????
//                currentNumber++;
//                //MessageBox.Show("After the increment is " + currentNumber);
//                string NewTitle = title + currentNumber;
//                //MessageBox.Show("The New Title i'm setting the video as is " + NewTitle);
//                element1.SendKeys(OpenQA.Selenium.Keys.Control + "a");  // Select all text
//                System.Threading.Thread.Sleep(1800);
//                element1.SendKeys(NewTitle);
//                System.Threading.Thread.Sleep(1800);
//                element1 = driver.FindElement(By.CssSelector(".upload-picker > .remove-default-style")); //CLICKS ON THE THUMBNAIL Gotten here3 Error
//                element1.Click();
//                System.Threading.Thread.Sleep(1800);
//                SendKeys.SendWait(ThumbnailLocation);
//                SendKeys.SendWait("{ENTER}");
//                System.Threading.Thread.Sleep(1800);
//                string specificThumb = currentNumber + ".jpg";
//                System.Threading.Thread.Sleep(1800);
//                SendKeys.SendWait(specificThumb); //Upload Video Thumbnail From Title Explorer
//                System.Threading.Thread.Sleep(1800);
//                SendKeys.SendWait("{ENTER}");
//                System.Threading.Thread.Sleep(1800);
//                element1 = driver.FindElement(By.CssSelector("#step-title-3")); //Goes to the Schedule Tab. These 4 were element1.Fi
//                System.Threading.Thread.Sleep(1800);
//                element1.Click();
//                System.Threading.Thread.Sleep(1800);
//                element1 = driver.FindElement(By.CssSelector("#schedule-radio-button > #radioLabel")); //Clicks on Schedule
//                System.Threading.Thread.Sleep(1800);
//                element1.Click();
//                System.Threading.Thread.Sleep(1800);
//                element1 = driver.FindElement(By.CssSelector("#datepicker-trigger .dropdown-trigger-text")); //The Date has been clicked
//                element1.Click();
//                System.Threading.Thread.Sleep(1800);
//                //element1 = driver.FindElement(By.CssSelector("#input-2 > .style-scope")); //Might need to try by id
//                element1 = driver.FindElement(By.XPath("//form/tp-yt-paper-input/tp-yt-paper-input-container/div[2]/div/iron-input/input"));
//                element1.Click();
//                System.Threading.Thread.Sleep(1800);
//                element1.SendKeys(OpenQA.Selenium.Keys.Control + "a");  // Select all text GOT HERE ERROR
//                System.Threading.Thread.Sleep(1800);
//                element1.SendKeys(changingEstDateTime.ToString("MMMM d, yyyy")); //Set the Date in scheduler
//                System.Threading.Thread.Sleep(1800);
//                //SendKeys.SendWait("{ENTER}");
//                //Alert shows up here

//                if (dumbcounter == 0)
//                {
//                    SendKeys.SendWait("{ENTER}"); //Submitting the date
//                    System.Threading.Thread.Sleep(3000);
//                    IAlert confirm = driver.SwitchTo().Alert(); //Answering Alert
//                    confirm.Dismiss();
//                    System.Threading.Thread.Sleep(1800);
//                    dumbcounter++;
//                }
//                else
//                {
//                    SendKeys.SendWait("{ENTER}"); //Submitting the date
//                    System.Threading.Thread.Sleep(3000);
//                }

//                //try
//                //{
//                //    SendKeys.SendWait("{ENTER}");
//                //    System.Threading.Thread.Sleep(3000);
//                //    IAlert confirm = driver.SwitchTo().Alert();
//                //    confirm.Dismiss();

//                //}

//                //catch (Exception ex)
//                //{

//                //}




//                //This works for 1 iteration
//                element1 = driver.FindElement(By.CssSelector("#input-2 > .style-scope")); //Reclicking of the date?
//                element1.Click();




















//                SendKeys.SendWait("{ENTER}");

//                //element1 = driver.FindElement(By.XPath("//form/tp-yt-paper-input/tp-yt-paper-input-container/div[2]/div/iron-input/input"));
//                //element1 = driver.FindElement(By.XPath("//iron-input[@id='input-2']/input"));
//                //element1.Click();
//                //SendKeys.SendWait("{ENTER}");
//                System.Threading.Thread.Sleep(1800);
//                //element1 = driver.FindElement(By.CssSelector("#input-1 > .style-scope"));
//                //element1 = driver.FindElement(By.XPath("=//iron-input/input"));
//                //element1.Click();

//                //Need to click on TIME NOT CLICKIN ON TIME FIX IZT
//                //element1 = driver.FindElement(By.XPath("//iron-input[@id='input-2']/input"));

//                //string dateClicker = "#input-" + reallydumbcounter + " > .style-scope";
//                //element1 = driver.FindElement(By.CssSelector(dateClicker));
//                //element1.Click();
//                //reallydumbcounter++;
//                //reallydumbcounter++;








//                //What i had before
//                element1 = driver.FindElement(By.CssSelector("#input-1 > .style-scope"));
//                element1.Click();








//                //SendKeys.SendWait("{ENTER}");
//                System.Threading.Thread.Sleep(1800);
//                element1.SendKeys(OpenQA.Selenium.Keys.Control + "a");
//                System.Threading.Thread.Sleep(1800);// Select all text
//                element1.SendKeys(changingEstDateTime.ToString("HH:mm")); //Set the Time in Scheduler
//                System.Threading.Thread.Sleep(1800);
//                SendKeys.SendWait("{ENTER}");
//                System.Threading.Thread.Sleep(1800);
//                if (radioButton1.Checked)
//                {
//                    changingEstDateTime = changingEstDateTime.AddDays(1);
//                }
//                if (radioButton2.Checked)
//                {
//                    changingEstDateTime = changingEstDateTime.AddDays(7);
//                }
//                element1 = driver.FindElement(By.CssSelector("#done-button > .label"));//Done with video
//                element1.Click();
//                System.Threading.Thread.Sleep(2500);
//                element1 = driver.FindElement(By.CssSelector("#close-button > .label")); //Close out of needlesss prompt
//                element1.Click();
//                System.Threading.Thread.Sleep(2500);
//                //driver.Navigate().Refresh();





//                System.Threading.Thread.Sleep(4000);













//                //This works with NO NAVIGATION!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
//                System.Threading.Thread.Sleep(5000);
//                element1 = driver.FindElement(By.CssSelector(".label:nth-child(3)")); //This shit isn't gonna work
//                element1.Click();
//                System.Threading.Thread.Sleep(2500);
//                element1 = driver.FindElement(By.CssSelector("#text-item-0 .item-text"));
//                element1.Click();
//                System.Threading.Thread.Sleep(2500);
//                element1 = driver.FindElement(By.CssSelector("#burst"));
//                element1.Click();
//                System.Threading.Thread.Sleep(2500);






//                //break;
//            }



//            //driver.Quit();
//        }

//        private void label1_Click(object sender, EventArgs e)
//        {

//        }

//        private void button6_Click_1(object sender, EventArgs e)
//        {
//            using (var dialog = new FolderBrowserDialog())
//            {
//                DialogResult result = dialog.ShowDialog();
//                if (result == DialogResult.OK)
//                {
//                    string selectedPath = dialog.SelectedPath;
//                    VideoLocation = selectedPath; //ie E:\Videos\Test
//                    //MessageBox.Show("Selected location - " + VideoLocation + " - that has all your video files.");
//                    label1.Text = "Current Folder is : " + selectedPath;
//                    // Do something with the selected folder path
//                }
//            }

//            try
//            {
//                VideoNames = Directory.GetFiles(VideoLocation, "*.mp4");
//            }
//            catch
//            {
//                MessageBox.Show("Error: Can't be Null");
//            }

//            //VideoLocation = @"E:\Videos\Test";
//            //VideoNames = Directory.GetFiles(VideoLocation, "*.mp4");


//            //path = System.IO.Path.Combine(Location, "Highlights");
//        }

//        private void button2_Click(object sender, EventArgs e)
//        {
//            using (var dialog = new FolderBrowserDialog())
//            {
//                DialogResult result = dialog.ShowDialog();
//                if (result == DialogResult.OK)
//                {
//                    string selectedPath = dialog.SelectedPath;
//                    ThumbnailLocation = selectedPath; //ie E:\Videos\Test
//                    //MessageBox.Show("Selected location - " + ThumbnailLocation + " - that has all your video files.");
//                    label2.Text = "Current Folder is : " + selectedPath;
//                    // Do something with the selected folder path
//                }
//            }

//            //ThumbnailLocation = @"C:\Users\drewh\Videos\Thumbnails\Sekiro\JPEG";


//        }

//        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
//        {

//        }

//        private void label3_Click(object sender, EventArgs e)
//        {

//        }

//        private void label5_Click(object sender, EventArgs e)
//        {

//        }

//        private void textBox1_TextChanged(object sender, EventArgs e)
//        {
//            string userInput = textBox1.Text;
//            FirstVideoName = textBox1.Text;
//        }

//        private void textBox1_LostFocus(object sender, EventArgs e) //Look at this one
//        {
//            if (string.IsNullOrWhiteSpace(textBox1.Text))
//            {
//                textBox1.Text = "Example 'Overwatch Highlight #'"; // Replace with your example text
//                textBox1.ForeColor = SystemColors.GrayText; // Change the text color to indicate example text
//            }
//        }

//        private void radioButton1_CheckedChanged(object sender, EventArgs e)
//        {

//        }
//    }
//}
