using HtmlAgilityPack;
using HtmlAgilityPack.CssSelectors.NetCore;
using MatecProjectWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml;

namespace MatecProjectWebUI.Controllers
{
    public class WebScraperController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<WebScraperViewModel> model = new List<WebScraperViewModel>();
            // Burada sayfanın pagedList'nin uzunluguna erişerek alinan sayi kadar sayfaları dolasarak bilgileri elde etmektir.
            var urlPage = "https://www.matecelectronics.com/kategori/circular-connectors";
            HtmlWeb webPage = new HtmlWeb();
            HtmlDocument values = webPage.Load(urlPage);
            var pagedNumber = Convert.ToInt16(values.QuerySelector("div.paginate-content a:last-child").InnerText);

            //Bu döngüde yukarıda alinmis olan pagedNumber ile dongunun bu sayı kadar donulmesi saglanabilir suanlık bu kadar veriyi alırken yavas calismasi sebebiyle elle sayı girilmistir.
            var tasks = new List<Task>();
            for (int i = 1; i <= 3/*sayfa sayısı*/; i++)
            {
                var url = $"https://www.matecelectronics.com/kategori/circular-connectors?tp={i}";
                tasks.Add(GetDataAsync(url, model));
            }

            await Task.WhenAll(tasks);

            return View(model);
        }

        private async Task GetDataAsync(string url, List<WebScraperViewModel> model)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = await web.LoadFromWebAsync(url);
            IList<HtmlNode> nodes = doc.QuerySelectorAll("div.col-6.col-lg-51 div.showcase");

            var data = nodes.Select((node) =>
            {
                return new
                {
                    name = node.SelectSingleNode(".//div[@class='showcase-content']/div[@class='showcase-title']/a").InnerText,
                    code = node.SelectSingleNode(".//div[@class='showcase-content']/div[@class='showcase-stock-code']").InnerText,
                    stock = node.SelectSingleNode(".//div[@class='showcase-content']/div[@class='showcase-quantity']").InnerText,
                    imgUrl = node.SelectSingleNode(".//div[@class='showcase-image']/a/img")
                        .GetAttributeValue("data-src", "https://www.maltepeotel.com.tr/tema/genel/uploads/haberler/gorsel-hazirlaniyor_1.gif")
                };
            });

            foreach (var x in data)
            {
                model.Add(new WebScraperViewModel
                {
                    Name = x.name,
                    Code = x.code,
                    Stock = x.stock,
                    Image = "https:" + x.imgUrl
                });
            }
        }
    }
}
