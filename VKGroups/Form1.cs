using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using System.Threading.Tasks;
using System.IO;
namespace VKGroups

{
    public partial class Form1 : Form
    {
        IWebDriver Browser;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

                        
            Browser = new OpenQA.Selenium.Chrome.ChromeDriver();
            Browser.Manage().Window.Maximize();
            Browser.Navigate().GoToUrl("https://vk.com");                               
            IWebElement login = Browser.FindElement(By.Id("index_email"));
            login.SendKeys("*");
            IWebElement password = Browser.FindElement(By.Id("index_pass"));
            password.SendKeys("* " + OpenQA.Selenium.Keys.Enter);                       
            System.Threading.Thread.Sleep(3000);                                    
            Browser.Navigate().GoToUrl("https://vk.com/bigmarketcrimea");
            while (true)
            {
                Point:
                try
                {
                    System.Threading.Thread.Sleep(3000);
                    IWebElement Post = Browser.FindElement(By.XPath("//*[text()='только что']"));
                    Post.Click();
                }
                catch (NoSuchElementException)
                {
                    System.Threading.Thread.Sleep(10000);
                    Browser.Navigate().Refresh();
                    goto Point;
                }
                System.Threading.Thread.Sleep(5000);

                string PostNumber = Browser.Url;
                System.Threading.Thread.Sleep(1000);
                string PostNumberCut = PostNumber.Remove(0, 46);

                string s1;
                string s2 = "Falbum";


                int k = 1;
                Browser.Navigate().GoToUrl("https://vk.com/bigmarketcrimea?w=wall-104414442_" + PostNumberCut);
                System.Threading.Thread.Sleep(5000);
                string Trigger = "";
                int i = 0;
                try
                {
                    Trigger = Browser.FindElement(By.CssSelector("#wpt-104414442_" + PostNumberCut + " > div.wall_post_text")).Text;
                    //  IWebElement link = Browser.FindElement(By.CssSelector("#wpt-104414442_" + post_string + " > div.wall_signed > a "));
                    System.Threading.Thread.Sleep(3000);
                    IWebElement Photo = Browser.FindElement(By.CssSelector("#wpt-104414442_" + PostNumberCut + " > div.page_post_sized_full_thumb.page_post_sized_full_thumb_first > div > a"));
                    Photo.Click();

                    while (true)
                    {
                        try
                        {

                            System.Threading.Thread.Sleep(3000);

                            IWebElement SaveBtn = Browser.FindElement(By.CssSelector("#pv_save_to_me"));
                            SaveBtn.Click();
                            System.Threading.Thread.Sleep(3000);
                            IWebElement PhotoFull = Browser.FindElement(By.CssSelector("#pv_photo"));
                            PhotoFull.Click();
                            i++;
                            s1 = Browser.Url;
                            bool b = s1.Contains(s2);
                            if (b == true)
                            {
                                goto marker2;
                            }
                        }
                        catch (NoSuchElementException)
                        {
                            goto Point2;
                        }
                        finally
                        {

                        }
                    }
                    Point2:
                    marker2:
                    System.Threading.Thread.Sleep(3000);
                    k = i;
                    Browser.Navigate().GoToUrl("https://vk.com/bigmarketcrimea?w=wall-104414442_" + PostNumberCut);
                    IWebElement Link = Browser.FindElement(By.CssSelector("#wpt-104414442_" + PostNumberCut + " > div.wall_signed > a "));
                    System.Threading.Thread.Sleep(3000);
                    Link.Click();
                }
                catch (NoSuchElementException)
                {

                    goto Point;


                }
                finally
                {
                    if (Trigger == "")
                    {

                        goto point;
                    }
                    System.Threading.Thread.Sleep(3000);
                    string CrntURL = Browser.Url;
                    Browser.Navigate().GoToUrl("https://vk.com/public198570678");
                    System.Threading.Thread.Sleep(3000);
                    IWebElement Test = Browser.FindElement(By.Id("post_field"));
                    Test.SendKeys(Trigger + "\n\n");
                    Test.SendKeys(CrntURL);
                    for (int j = 0; j < i; j++)
                    {
                        IWebElement PickPhoto = Browser.FindElement(By.CssSelector("#page_add_media > div.media_selector.clear_fix > a.ms_item.ms_item_photo._type_photo"));
                        PickPhoto.Click();
                        System.Threading.Thread.Sleep(3000);

                        IWebElement Photo = Browser.FindElement(By.XPath("/html/body/div[6]/div[1]/div[2]/div/div[2]/div/div[2]/div[3]/a[" + k + "]"));
                        Photo.Click();
                        k--;

                    }


                    IWebElement Click = Browser.FindElement(By.Id("send_post"));
                    Click.Click();

                    point:
                    System.Threading.Thread.Sleep(3000);
                    File.WriteAllText("C:/save.txt", PostNumberCut);

                }

            }

        }
    }
}
