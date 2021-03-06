// This file has been autogenerated from parsing an Objective-C header file added in Xcode.

using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;

namespace TechDays2013
{
	public partial class WebService : UIViewController
	{

		public WebService (IntPtr handle) : base (handle)
		{
			this.Title = "Web Service";
		}

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            this.btnCalculate.TouchUpInside += btnCalculate_TouchUpInside;
            this.lblResult.Text = "";
        }

        //使用不同的Web Service 進行轉換
        void btnCalculate_TouchUpInside(object sender, EventArgs e)
        {
            this.txttemp.ResignFirstResponder();

            switch (segService.SelectedSegment)
            {
                //使用SOAP
                case 0:
                   var converter1 = new soapconvert.TempConvert();
                   if (segMethod.SelectedSegment == 0)
                   { this.lblResult.Text = converter1.CelsiusToFahrenheit(txttemp.Text); }
                   else
                   { this.lblResult.Text = converter1.FahrenheitToCelsius(txttemp.Text); }
                    break;

                //使用WCF
                case 1:
                    var converter2 = new wcfconvert.WCFTempService();
                   if (segMethod.SelectedSegment == 0)
                   { this.lblResult.Text = converter2.CelsiusToFahrenheit(txttemp.Text); }
                   else
                   { this.lblResult.Text = converter2.FahrenheitToCelsius(txttemp.Text); }
                    break;
                   

                //使用REST with JSON
                case 2:
                    string uri;
                    if (segMethod.SelectedSegment == 0){
                        uri = @"http://restfulconvert.azurewebsites.net/TempConvert.svc/ToF/" + txttemp.Text; }
                    else{
                        uri = @"http://restfulconvert.azurewebsites.net/TempConvert.svc/ToC/" + txttemp.Text; }
                
                    var request = HttpWebRequest.Create(uri);
                    request.Method = "GET";
                    request.ContentType = "application/json";

                    using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                    {
                        using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                        {
                            var content = JObject.Parse(reader.ReadToEnd());
                            if (segMethod.SelectedSegment == 0)
                            {
                                this.lblResult.Text = content["Fahrenheit"].ToString();
                            }
                            else
                            {
                                this.lblResult.Text = content["Celsius"].ToString();
                            }
                        }
                    }
                    break;
            }
            
        }

        
        public override void TouchesBegan(NSSet touches, UIEvent evt)
        {
            base.TouchesBegan(touches, evt);
            this.txttemp.ResignFirstResponder();
        }
       
	}
}
