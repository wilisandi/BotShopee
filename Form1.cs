using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;
using Newtonsoft.Json;
using Sopi.Logger;
using static BotShopee.Shopee;

namespace BotShopee
{
    public partial class Form1 : Form
    {
        private Logger _log = new Logger(100u);
        private List<Color> _randomColors = new List<Color> { Color.Red, Color.SkyBlue, Color.Green };
        private Random _r = new Random((int)DateTime.Now.Ticks);
        private bool IsLoggedIn = false;
        private static string CrfToken = "";
        private static string ItemUri = "";
        private static int Step = 0;
        private static CoreWebView2HttpRequestHeaders ItemHeaders = null;
        private Shopee.UserData SopiUser = null;
        private static CoreWebView2 coreWebView = null;
        private ItemDetail selectedItem = null;
        public Form1()
        {
            InitializeComponent();
            this.Resize += new System.EventHandler(this.Form_Resize);
        }
        private void Form_Resize(object sender, EventArgs e)
        {
            webView21.Size = this.ClientSize - new System.Drawing.Size(webView21.Location);
        }

        private void WebForm_Load(object sender, EventArgs e)
        {
        }
        private async void WebView2_CoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            // WebView2 is initialized and ready to use
            if (e.IsSuccess)
            {
                coreWebView = webView21.CoreWebView2;
                webView21.Source = new Uri("https://shopee.co.id/");
                coreWebView.Settings.IsWebMessageEnabled = true;
                coreWebView.Settings.IsScriptEnabled = true;
                coreWebView.Settings.AreDefaultScriptDialogsEnabled = true;
                coreWebView.Settings.IsStatusBarEnabled = true;
                coreWebView.Settings.IsZoomControlEnabled = true;
                coreWebView.Settings.AreBrowserAcceleratorKeysEnabled = true;

                coreWebView.AddWebResourceRequestedFilter("*",
                                              CoreWebView2WebResourceContext.All);
                coreWebView.NavigationCompleted += CoreWebView2_NavigationCompleted;
                coreWebView.SourceChanged += CoreWebView2_SourceChange;
                coreWebView.WebResourceRequested += CoreWebView2_WebResourceRequested;
                coreWebView.WebMessageReceived += WebView2_WebMessageReceived;
                coreWebView.WebResourceResponseReceived += CoreWebView2_WebResourceResponseReceived;
                // Load a URL into the WebView2 control
                AddLog("WebView2 is Ready", Color.Green);
            }
            else
            {
                AddLog("WebView2 initialization failed.", Color.Green);
            }
        }

        private async void CoreWebView2_SourceChange(object sender, CoreWebView2SourceChangedEventArgs e)
        {
            if (coreWebView.Source.Contains("cart?"))
            {
                Step = 2;
                if (isAutobuyRun)
                {
                    AddLog("Adding product to cart", Color.White);
                    ClickElementBySelector($".container button.shopee-button-solid.shopee-button-solid--primary");
                }
            }
            else
            if (coreWebView.Source.Contains("checkout"))
            {
                if (isAutobuyRun)
                {
                    AddLog("Selecting payment", Color.White);
                    //ClickElementBySelector($"button.product-variation[aria-label='Transfer Bank']");
                    //ClickElementBySelector($".bank-transfer-category__body .checkout-bank-transfer-item:nth-child(2) .stardust-radio");
                    //ClickElementBySelector($".stardust-popup-button.stardust-popup-button--main");
                }
            }
        }

        private async void CoreWebView2_WebResourceRequested(object sender, CoreWebView2WebResourceRequestedEventArgs e)
        {
            var headers = e.Request.Headers;
            var content = e.Request.Content;
            if (isAutobuyRun)
            {
                if (e.ResourceContext == CoreWebView2WebResourceContext.Image)
                {
                    e.Response = webView21.CoreWebView2.Environment.CreateWebResourceResponse(null, 200, "Not found", null);
                }
                else
                if (e.ResourceContext == CoreWebView2WebResourceContext.Stylesheet)
                {
                    e.Response = webView21.CoreWebView2.Environment.CreateWebResourceResponse(null, 200, "Not found", null);
                }
                else
                if (e.ResourceContext == CoreWebView2WebResourceContext.Media)
                {
                    e.Response = webView21.CoreWebView2.Environment.CreateWebResourceResponse(null, 200, "Not found", null);
                }
                else
                if (e.ResourceContext == CoreWebView2WebResourceContext.Font)
                {
                    e.Response = webView21.CoreWebView2.Environment.CreateWebResourceResponse(null, 200, "Not found", null);
                }else
                if (e.Request.Uri.Contains("get_notifications"))
                {
                    e.Response = webView21.CoreWebView2.Environment.CreateWebResourceResponse(null, 200, "Not found", null);
                }else
                if (e.Request.Uri.Contains("get_activities"))
                {
                    e.Response = webView21.CoreWebView2.Environment.CreateWebResourceResponse(null, 200, "Not found", null);
                }else
                if (e.Request.Uri.Contains("get_web_experiments"))
                {
                    e.Response = webView21.CoreWebView2.Environment.CreateWebResourceResponse(null, 200, "Not found", null);
                }else
                if (e.Request.Uri.Contains("search_prefills"))
                {
                    e.Response = webView21.CoreWebView2.Environment.CreateWebResourceResponse(null, 200, "Not found", null);
                }
                else
                if (e.Request.Uri.Contains("get_all_sessions"))
                {
                    //e.Response = webView21.CoreWebView2.Environment.CreateWebResourceResponse(null, 200, "Not found", null);
                }
                else
                if (e.Request.Uri.Contains("envelope/?sentry"))
                {
                    e.Response = webView21.CoreWebView2.Environment.CreateWebResourceResponse(null, 200, "Not found", null);
                }
                else
                if (e.Request.Uri.Contains("chat"))
                {
                    e.Response = webView21.CoreWebView2.Environment.CreateWebResourceResponse(null, 200, "Not found", null);
                }
                else
                if (e.Request.Uri.Contains("tr.js"))
                {
                    e.Response = webView21.CoreWebView2.Environment.CreateWebResourceResponse(null, 200, "Not found", null);
                }
            }
            if (e.Request.Uri.Contains("place_order"))
            {
                isAutobuyRun = false;
                isProcess = false;
                buttonBuy.Text = "Start Auto Buy";
                if (timer != null)
                    timer.Stop();
            }
            //if (e.Request.Uri.Contains("get_pc?"))
            //{
            //    if (ItemUri != e.Request.Uri)
            //    {
            //        AddLog("Get detail product...", Color.White);
            //        ItemHeaders = headers;
            //        ItemUri = e.Request.Uri;
            //        LinkProduct.Text = coreWebView.Source;
            //        GetDetailItem();
            //    }
            //}
        }

        public void pencetBeli()
        {
            sinibang:
            if (isAutobuyRun)
            {
                goto sinibang;
            }
        }

        private async void CoreWebView2_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            if (!IsLoggedIn)
            {
                var checkLogin = await coreWebView.ExecuteScriptAsync($"JSON.parse(localStorage.getItem('mini-session'));");
                CrfToken = await coreWebView.ExecuteScriptAsync(@"function getCookie(name) {
  const cookies = document.cookie.split(';');
  for (let i = 0; i < cookies.length; i++) {
    const cookie = cookies[i].trim();
    if (cookie.startsWith(name + '=')) {
      return cookie.substring(name.length + 1);
    }
  }
  return null;
}
getCookie('csrftoken'); ");
                CrfToken = CrfToken.Replace("\"", "");
                if (checkLogin != "null")
                {
                    GetSession(checkLogin);
                }
            }
        }

        private async void WebView2_WebMessageReceived(object sender, CoreWebView2WebMessageReceivedEventArgs e)
        {
            try
            {
                // Check if the message type is 'json'
                if (e.WebMessageAsJson != null)
                {
                    var postMessage = JsonConvert.DeserializeObject<Shopee.PostMessage<dynamic>>(e.WebMessageAsJson);

                    if (postMessage.source == "item" && !postMessage.isError)
                    {
                        Shopee.ItemDetail detail = JsonConvert.DeserializeObject<ItemDetail>(JsonConvert.SerializeObject(postMessage.data));
                        selectedItem = detail;
                        OnGetItemDetail(detail);
                        AddLog($"Get detail success product {detail.data.item.title}", Color.Green);
                    }
                    else if (postMessage.source == "item" && postMessage.isError)
                    {
                        selectedItem = null;
                        var error = postMessage.data;
                        OnGetItemDetail(null);
                        AddLog($"Get detail error: {error}", Color.Red);
                    }
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                AddLog($"Get detail error: {ex.Message}", Color.Red);
            }
        }

        public async void GetDetailItem()
        {
            //using (var httpClient = new HttpClient())
            //{
            //    if (ItemHeaders != null)
            //    {
            //        //foreach (var headerName in ItemHeaders)
            //        //{
            //        //    string headerValue = ItemHeaders.GetHeader(headerName.Key);
            //        //    httpClient.DefaultRequestHeaders.Add(headerName.Key, headerValue);
            //        //}
            //        var dicHeader = ItemHeaders.ToList();
            //        var strHeader = @"";
            //        foreach (var ih in dicHeader)
            //        {
            //            strHeader += $@"""{ih.Key.Replace("\\", "\\\\").Replace("\"", "\\\"")}"":""{ih.Value.Replace("\\", "\\\\").Replace("\"", "\\\"")}"",";
            //        }
            //        var js = $@"fetch('{ItemUri}', {{
            //                    'headers': {{
            //                        {strHeader}
            //                    }},
            //                  'referrerPolicy': 'strict-origin-when-cross-origin',
            //                  'body': null,
            //                  'method': 'GET',
            //                  'mode': 'cors',
            //                  'credentials': 'include'
            //                }})
            //                .then(response => {{
            //                  // Process the response here
            //                  if (!response.ok) {{
            //                    throw new Error('Network response was not ok.');
            //                  }}
            //                  return response.json();
            //                }})
            //                .then(data => {{
            //                  const message = JSON.stringify(data);
            //                    window.chrome.webview.postMessage({{
            //                        'source':'item',
            //                        'isError':false,
            //                        'data':data
            //                    }});
            //                }})
            //                .catch(error => {{
            //                    window.chrome.webview.postMessage({{
            //                        'source':'item',
            //                        'isError':true,
            //                        'data':error
            //                    }});
            //                }});";
            //        coreWebView.ExecuteScriptAsync(js);
            //        //// Make the GET request
            //        //HttpResponseMessage response = await httpClient.GetAsync(ItemUri);

            //        //// Check if the request was successful
            //        //if (response.IsSuccessStatusCode)
            //        //{
            //        //    // Read the content of the response
            //        //    string content = await response.Content.ReadAsStringAsync();
            //        //    return content;
            //        //    Console.WriteLine(content);
            //        //}
            //        //else
            //        //{
            //        //    return response;
            //        //    // Handle the error if the request was not successful
            //        //    Console.WriteLine($"Request failed with status code: {response.StatusCode}");
            //        //}
            //    }
            //    else
            //    {
            //    }
            //}
        }

        static long GenerateLongId()
        {
            Random random = new Random();
            long minValue = 100000000;
            long maxValue = 999999999;

            return random.Next((int)(minValue >> 32), (int)(maxValue >> 32)) << 32 | random.Next((int)minValue, (int)maxValue);
        }

        void GetSession(string checkLogin)
        {
            try
            {
                AddLog("Connecting to your account...", Color.White);
                var user = JsonConvert.DeserializeObject<UserData>(checkLogin);
                SopiUser = user;
                IsLoggedIn = true;
                AddLog($"Connected as {SopiUser.user.name}", Color.Green);
            }
            catch (Exception exc)
            {
                AddLog($"Error to connect : {exc.Message}", Color.Red);
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        public void AddLog(string text,Color color)
        {
            _log.AddToLog(text, color);
            richTextBoxLog.Rtf = _log.GetLogAsRichText(false);
            richTextBoxLog.SelectionStart = richTextBoxLog.Text.Length;
            richTextBoxLog.ScrollToCaret();
        }


        static string FormatNumberWithThousandsSeparator(string input)
        {
            input = input.Replace("00000", "");
            if (!int.TryParse(input, out int number))
            {
                throw new ArgumentException("Invalid input string. It should be a valid integer.");
            }

            return number.ToString("N0");
        }

        public void OnGetItemDetail(Shopee.ItemDetail detail)
        {
            if(detail != null)
            {
                if(detail.data.item.stock != null)
                {
                    Stock.Text = detail.data.item.stock.ToString();
                }
                if(detail.data.item.title != null)
                {
                    ProductName.Text = detail.data.item.title;
                }
                if(detail.data.item.price != null)
                {
                    Price.Text = $"Rp {FormatNumberWithThousandsSeparator(detail.data.item.price.ToString())}";
                }
                if(detail.data.flash_sale_preview != null)
                {
                    if (detail.data.flash_sale_preview.start_time.HasValue)
                    {
                        DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(detail.data.flash_sale_preview.start_time.Value);
                        DateTime dateTime = dateTimeOffset.DateTime;
                        avaibleAt.Value = TimeZoneInfo.ConvertTimeFromUtc(dateTime, TimeZoneInfo.Local);
                    }
                }
                else
                {
                    avaibleAt.Value = DateTime.Now;
                }
                // Variant
                if (detail.data.item.models != null&& detail.data.item.models.Count != 0)
                {
                    comboVariant.Enabled = true;
                    comboVariant.Items.Clear();
                    comboVariant.DisplayMember = "name";
                    comboVariant.ValueMember = "item_id";
                    var arrVari = detail.data.item.models.ToArray();
                    comboVariant.Items.AddRange(arrVari);
                    if(arrVari.Length != 0)
                    {
                        comboVariant.SelectedIndex = 0;
                    }
                }
                else
                {
                    comboVariant.Enabled = false;
                    comboVariant.Items.Clear();
                }
                // Shipping
                comboShipping.Items.Clear();
                comboShipping.DisplayMember = "name";
                comboShipping.ValueMember = "channel_id";
                comboShipping.Items.AddRange(detail.data.product_shipping.ungrouped_channel_infos.ToArray());
                comboShipping.SelectedIndex = 0;
            }
            else
            {
                comboVariant.Items.Clear();
                comboVariant.Enabled = false;
            }
        }

        private void comboVariant_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Perform actions based on the selected item in the ComboBox
            if (comboVariant.SelectedItem != null)
            {
                Model selectedOption = (Model)comboVariant.SelectedItem;
                if(selectedOption != null)
                {
                    if (selectedOption.price != null)
                    {
                        Price.Text = $"Rp {FormatNumberWithThousandsSeparator(selectedOption.price.ToString())}";
                    }
                    if (selectedOption.stock != null)
                    {
                        Stock.Text = selectedOption.stock.ToString();
                    }
                }
            }
        }

        private void comboShipping_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Perform actions based on the selected item in the ComboBox
            if (comboShipping.SelectedItem != null)
            {
                UngroupedChannelInfo selectedOption = (UngroupedChannelInfo)comboShipping.SelectedItem;
                if(selectedOption != null)
                {
                    if (selectedOption.price_before_discount != null)
                    {
                        ShippingPrice.Text = $"Rp {FormatNumberWithThousandsSeparator(selectedOption.price_before_discount.single_value.ToString())}";
                    }
                }
            }
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            AddLog("Application Started",Color.Green);
            AddLog("Initializing WebView2.....", Color.White);
            webView21.CoreWebView2InitializationCompleted += WebView2_CoreWebView2InitializationCompleted;
            webView21.EnsureCoreWebView2Async(null);
        }

        private DateTime targetTime;
        private Timer timer;
        private bool isAutobuyRun=false;
        private bool isProcess=false;
        private void buttonBuy_Click(object sender, EventArgs e)
        {
            if (selectedItem != null)
            {
                if (!isAutobuyRun)
                {
                    AddLog("Starting Auto Checkout..", Color.White);
                    isAutobuyRun = true;
                    buttonBuy.Text = "Stop Auto Buy";
                    countDownBuy.ForeColor = Color.DarkGreen;
                    if (avaibleAt.Value <= DateTime.Now)
                    {
                        AutoBuy();
                        //coreWebView.Reload();
                    }
                    else
                    {
                        targetTime = avaibleAt.Value;

                        timer = new Timer();
                        timer.Interval = 1;
                        timer.Tick += Timer_Tick;
                        timer.Start();
                    }
                }
                else
                {
                    AddLog("Stopping Auto Checkout..", Color.White);
                    isProcess = false;
                    isAutobuyRun = false;
                    buttonBuy.Text = "Start Auto Buy";
                    if(timer!=null)
                    timer.Stop();
                }
            }
        }
        static async Task ClickElementBySelector(string selector)
        {
            sini:
            var Oke  = await coreWebView.ExecuteScriptAsync($@"document.querySelector(""{selector}"").innerHTML");
            if(Oke != "null")
            {
                string script = $@"document.querySelector(""{selector}"").click();";
                await coreWebView.ExecuteScriptAsync(script);
            }
            else
            {
                goto sini;
            }
        }

        private DateTime doneBuyStart = DateTime.Now;
        public async void AutoBuy()
        {
            AddLog("Running Auto Checkout", Color.White);
            if (timer != null)
                timer.Stop();
            Step = 1;
            isProcess = true;
            isAutobuyRun = true;
            countDownBuy.ForeColor = Color.Red;
            countDownBuy.Text = "00:00:00:000";

            timer = new Timer();
            timer.Interval = 1;
            timer.Tick += Timer_Tick;
            timer.Start();
            doneBuyStart = DateTime.Now;
            if (comboVariant.SelectedText != null)
            {
                var value = (Model)comboVariant.SelectedItem;
                var arrVariant = value.name.Split(',').ToList();
                arrVariant.ForEach(async x =>
                {
                    await ClickElementBySelector($".product-variation[aria-label='{x}']");
                });
            }
            await ClickElementBySelector($".product-briefing button.btn.btn-solid-primary.btn--l");
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Calculate the remaining time
            TimeSpan remainingTime = targetTime - DateTime.Now;
            if (isProcess)
            {

                TimeSpan elapsedTime = DateTime.Now - doneBuyStart;
                countDownBuy.Text = elapsedTime.ToString(@"hh\:mm\:ss\.ff");
            }
            else
            {
                // If the remaining time is still positive (countdown ongoing)
                if (remainingTime.TotalMilliseconds > 0)
                {
                    // Update the label to display the remaining time in "HH:mm:ss:fff" format
                    countDownBuy.Text = remainingTime.ToString(@"hh\:mm\:ss\:fff");
                }
                else
                {
                    //coreWebView.Reload();
                    AutoBuy();
                    timer.Stop();
                    countDownBuy.Text = "00:00:00:000";
                }
            }
        }

        private void getProduct_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(LinkProduct.Text))
            {
                if(Uri.TryCreate(LinkProduct.Text, UriKind.Absolute, out Uri productUri))
                {
                    coreWebView.Navigate(LinkProduct.Text);
                }
            }
        }

        private void getSession_Click(object sender, EventArgs e)
        {
            IsLoggedIn = false;
            coreWebView.Navigate("https://shopee.co.id/");
        }
        private void CoreWebView2_WebResourceResponseReceived(object sender, CoreWebView2WebResourceResponseReceivedEventArgs e)
        {
            var result = e.Response.GetContentAsync().GetAwaiter();
            result.OnCompleted(() =>
            {
                try
                {
                    if (e.Request.Uri.Contains("checkout/get"))
                    {
                        AddLog("trying to checkout...", Color.White);
                        //ClickElementBySelector($"span.stardust-popup-button.stardust-popup-button--main");
                        //ClickElementBySelector($"button.stardust-button.stardust-button--primary.stardust-button--large");
                    }
                    else
                    if (e.Request.Uri.Contains("get_pc?"))
                    {
                        var res = result.GetResult();
                        StreamReader reader = new StreamReader(res);
                        string text = reader.ReadToEnd();
                        Shopee.ItemDetail detail = JsonConvert.DeserializeObject<ItemDetail>(text);
                        if (isAutobuyRun)
                        {
                            if (detail.data != null)
                            {
                                if (detail.data.flash_sale != null || (detail.data.flash_sale == null && detail.data.flash_sale_preview == null))
                                {
                                    AutoBuy();
                                    AddLog("Product is open", Color.White);
                                }
                                else
                                {
                                    AddLog("Checking flash sale...", Color.White);
                                    coreWebView.Reload();
                                }
                            }
                        }
                        else
                        {
                            if (ItemUri != e.Request.Uri)
                            {
                                countDownBuy.ForeColor = Color.Green;
                                countDownBuy.Text = "00:00:00:000";
                                AddLog("Get detail product...", Color.White);
                                ItemHeaders = e.Request.Headers;
                                ItemUri = e.Request.Uri;
                                LinkProduct.Text = coreWebView.Source;

                                selectedItem = detail;
                                OnGetItemDetail(detail);
                                AddLog($"Get detail success product {detail.data.item.title}", Color.Green);
                            }
                        }
                    }
                    else
                    if (e.Request.Uri.Contains("place_order"))
                    {
                        var res = result.GetResult();
                        StreamReader reader = new StreamReader(res);
                        string text = reader.ReadToEnd();
                        AddLog($"Chechkout product is done result = {text}", Color.White);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            });
        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
