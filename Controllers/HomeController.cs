using System;
using System.Web.Mvc;
using Mavis.Trading.BusinessLayer.Interfaces;

namespace Mavis.Trading.StockQuote
{
    using System.Linq;

    public class HomeController : Controller
    {
        // GET: /Home/

        /// <summary>
        /// The index.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult Index()
        {
            return this.View();
        }

        // I would have implemented as async task in practical task due to lag of time I couldnt implement

        /// <summary>
        /// The add stock.
        /// </summary>
        /// <param name="stockSymbol">
        /// The stock symbol.
        /// </param>
        public void AddStock(string stockSymbol)
        {
            // Ideally I would inject this dependency
            IStockQuote stockQuoteBl = new BusinessLayer.StockQuote();
            stockQuoteBl.AddStockQuote(stockSymbol, new Random().Next(1, 10));
        }


        // I would have implemented as async task in practical task due to lag of time I couldnt implement

        /// <summary>
        /// The get stock list.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult GetStockList()
        {
            // Ideally I would inject this dependency
            IStockQuote stockQuoteBl = new BusinessLayer.StockQuote();
            var stockList = stockQuoteBl.GetStockList();
            return this.Json(
                stockList.Select(kv => new { stockSymbol = kv.Key, stockPrice = kv.Value }).ToArray(),
                JsonRequestBehavior.AllowGet);
        }
    }
}
