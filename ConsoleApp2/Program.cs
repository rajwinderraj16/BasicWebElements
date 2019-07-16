using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {

                           // Registeration page on demo.automation


            IWebDriver driver = new ChromeDriver();
            //Navigated to the Website
            driver.Navigate().GoToUrl("http://demo.automationtesting.in/Register.html");

            //Store the xapth of the Textfield in "firstname" 
            Thread.Sleep(2000);
            IWebElement firstname = driver.FindElement(By.XPath("//input[@placeholder='First Name']"));

            //Enter the  FirstName in Textfield with "sendkeys"
            firstname.SendKeys("Rajwinder");

            //How TO delete the value in the Textfiled with "Clear" method
            firstname.Clear();

            //Send the new value in the Textfield
            firstname.SendKeys("ABCD");

            //How to delete the value in the Textfield with "Backspace Keys" clear method
            Thread.Sleep(2000);
            for (int i = 0; i <=9; i++)
            {
                firstname.SendKeys(Keys.Backspace);
            }

            //How to retrieve the value in the Textfiled with the help of "GetAttribute"
            String value = driver.FindElement(By.XPath("//input[@placeholder='First Name']")).GetAttribute("value");
            Console.WriteLine(value);

            //Store the xapth of the Textfield in "lasttname" element
            IWebElement lastname = driver.FindElement(By.XPath("//input[@placeholder='Last Name']"));

            //Enter the  LastName in Textfield with "sendkeys"
            lastname.SendKeys("kaur");

            //Deleting the existing value in the last field name Textbox
            lastname.Clear();

            //Sending the new value in the lastname Textfield
            lastname.SendKeys("EFGH");


            //Alternative option with IJavaScriptexcecuter
            Thread.Sleep(2000);
            IWebElement sendfirstname = driver.FindElement(By.XPath("//input[@placeholder='First Name']"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].value='Raj'", sendfirstname);

            Thread.Sleep(2000);
            //Sending LastName with IJavaexcecutor
            IWebElement sendlastname = driver.FindElement(By.XPath("//input[@placeholder='Last Name']"));
            js.ExecuteScript("arguments[0].value='Mehra'", sendlastname);


            // IWebElement:TextArea
            //Store the xapth of the TextArea in "txtarea" element
            Thread.Sleep(2000);
            IWebElement txtarea = driver.FindElement(By.XPath("//textarea[@class='form-control ng-pristine ng-valid ng-touched']"));

            //Enter the text in textarea with "sendkeys"
            txtarea.SendKeys("Hi am Rajwinder, am very passionate about automation testing");

            //Enter the Email in the textfield with"sendkeys"
            driver.FindElement(By.XPath("//input[@type='email']")).SendKeys("rajjashan87@gmail.com");

            //Enter the  Phone number in the textfield with "sendskeys"
            driver.FindElement(By.XPath("//input[@type='tel']")).SendKeys("123123");

            //WebElement: Radio button handling :To check if the radio button is diplayed or not:
            Boolean status = driver.FindElement(By.XPath("//label[1]//input[1]")).Displayed;
            Console.WriteLine(status);

            //To check if the radio button is Selected or not:
            Boolean isselect = driver.FindElement(By.XPath("//input[@type='radio' and @value='FeMale']")).Selected;
            Console.WriteLine(isselect);

            //To check if the radio button is Enabled or not:
            Boolean isenable = driver.FindElement(By.XPath("//input[@type='radio' and @value='FeMale']")).Enabled;
            Console.WriteLine(isenable);

            //To select the radio button:
            driver.FindElement(By.XPath("//input[@type='radio' and @value='FeMale']")).Click();

            //Count number of radio buttons on web page
            IList<IWebElement> list = driver.FindElements(By.XPath("//input[@type='radio']"));
            Console.WriteLine("The number of radio buttons are " + list.Count);

            //How to print the name of all the present radio buttons
            Thread.Sleep(2000);
            for (int i = 0; i <= list.Count; i++)
            {

                String sValue = list.ElementAt(i).GetAttribute("value");
                Console.WriteLine("The values are" + sValue);

                //And if you want to select any particular value from all value use "IF Statement"
                if (sValue.Equals("Male"))
                {
                    list.ElementAt(i).Click();
                    break;
                }
               
                //Senario: Check if any radio button is selected by default and if yes  then select the other radio button

                // First create a boolean value variable to hold the "True/false "value of all the radio buttons
                Boolean bValue = false;

                // This statement will return True, in case of first Radio button is selected
                bValue = list.ElementAt(0).Selected;

                // This will check that if the bValue is True means if the first radio button is selected
                if (bValue == true)
                {
                    // This will select Second radio button, if the first radio button is selected by default
                    list.ElementAt(1).Click();
                }
                else
                {
                    // If the first radio button is not selected by default, the first will be selected
                    list.ElementAt(0).Click();

                }
                   
                //WebElement:Checkbox:To select a particular checkbox with "Xpath"
                     try
                     {
                         driver.FindElement(By.XPath("//input[@id='checkbox2']")).Click();

                     }
                     catch (Exception e)
                     {

                         Console.WriteLine(e);
                     }

                     //Deselect the selected check box
                     var val = driver.FindElement(By.XPath("//input[@id='checkbox2']"));
                     Thread.Sleep(2000);
                     if (val.Selected)
                     {
                         val.Click(); //select again to deselect it
                     }
                     else
                     {
                         return;
                     }

                     //To check the total number of all check boxes on webpage

                     IList<IWebElement> AllCheck = driver.FindElements(By.XPath("//input[@type='checkbox']"));

                     for (int k = 0; k <= AllCheck.Count; k++)   //AllCheck.count will give the total number of checkboxes
                     {
                         String checkValue = AllCheck.ElementAt(k).GetAttribute("value"); // This will give us the value of all checkboxes
                         Console.WriteLine(checkValue);
                         AllCheck.ElementAt(k).Click();  //To select all the checboxes

                         if (checkValue.Equals("Hockey")) //To select a particular checkbox
                         {
                             AllCheck.ElementAt(k).Click();
                         }

             //To enter the Language in textfield
              driver.FindElement(By.XPath("//div[@id='msdd']")).SendKeys("English");


             //WebElement:Dropdown: Check the existence of dropdown
             Boolean state = driver.FindElement(By.XPath("//select[@id='Skills']")).Displayed;

             Console.WriteLine(state);

             //Select a particular option in the dropdown
             driver.FindElement(By.XPath("//option[contains(text(),'Adobe Photoshop')]")).Click();

             //Count the number of total dropdown available on the webpage
                    IList<IWebElement> num = driver.FindElements(By.XPath("//select[@type='text']"));
                    int number = num.Count();
                    Console.WriteLine(number);

             //Count the number of options available in particular dropdown
                     IList<IWebElement> opt = driver.FindElements(By.XPath("//select[@id='Skills']//option"));
                    int option = opt.Count;
                    Console.WriteLine(option);

                    //To print all the names of the options available in dropdown

                    for (int b = 0; b <= opt.Count; b++)
                    {
                        String sname = opt.ElementAt(b).GetAttribute("value");
                        Console.WriteLine(sname);

                        if (sname == "Art Design")
                        {
                            opt.ElementAt(b).Click();
                        }
                    }

                    
             // Select the country with "xpatha "
                    driver.FindElement(By.XPath("//select[@id='countries']//option[contains(text(),'Australia')]")).Click();
                    
                    //Select the Date of Birth by "value" from the drop down
                    var sel = driver.FindElement(By.XPath("//select[@id='yearbox']"));
                    SelectElement year = new SelectElement(sel);
                    year.SelectByValue("1987");

                    //Select the Month by "index" from the drop down
                    var mon = driver.FindElement(By.XPath("//select[@placeholder='Month']"));
                    SelectElement month = new SelectElement(mon);
                    month.SelectByText("September");


                    //Select the Month by "Day" from the drop down
                    var day = driver.FindElement(By.XPath("//select[@id='daybox']"));
                    SelectElement Day = new SelectElement(day);
                    Day.SelectByIndex(6);

                    
                    //Enter the Password with "Sendkeys"
                    driver.FindElement(By.XPath("//input[@id='firstpassword']")).SendKeys("123123");

                    //Enter the ConfirmPassword with "Sendkeys"
                    driver.FindElement(By.XPath("//input[@id='secondpassword']")).SendKeys("123123");

                    //WebElement:Button: to check the existence of button on webpage
                    bool btn1 = driver.FindElement(By.XPath("//button[@id='submitbtn']")).Displayed;
                    Console.WriteLine(btn1);

                    bool btn2 = driver.FindElement(By.XPath("//button[@id='submitbtn']")).Enabled;
                    Console.WriteLine(btn2);

                    bool btn3 = driver.FindElement(By.XPath("//button[@id='submitbtn']")).Selected;
                    Console.WriteLine(btn3);

                    //Click on the button
                    driver.FindElement(By.XPath("//button[@id='submitbtn']")).Click();



                }

            }
        }
    }
}








