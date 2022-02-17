using Stock_Indexing.DataSource;
using Stock_Indexing.Handlers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Stock_Indexing
{
    public partial class _Default : Page
    {
        bool addTOHits = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadStockInfo(0);
                int dtRange = int.Parse(ConfigurationManager.AppSettings["FluctutationDateRange"]);
                int count = int.Parse(ConfigurationManager.AppSettings["MAXRankingCache"]);
                Session["CacheStocks"] = new DataBaseHandler().GetHighFluctuationStocks(dtRange, count);
            }
            
        }

        private void LoadStockInfo(int currentIdx)
        {
            int totalRecords;
            var dbHandler = new DataBaseHandler();
            var dataList = dbHandler.GetAllCompanyDetailsWithPaging(txtFilter.Text, grdvInfo.PageSize, currentIdx, out totalRecords);
                      
            grdvInfo.DataSource = dataList;            
            grdvInfo.VirtualItemCount = totalRecords;            
            grdvInfo.DataBind();

            if(addTOHits)
            {
                int count = int.Parse(ConfigurationManager.AppSettings["MAXHitsCache"]);
                dbHandler.InsertStockSearchHits(dataList.Take(count).Select(a => a.Symbol).ToList());

                var maxHits = dbHandler.GetSearchHits(count);
                if(Session["CacheStocks"] != null)
                {
                    var cachList = Session["CacheStocks"] as IList<string>;
                    cachList = cachList.Union(maxHits).ToList();
                    Session["CacheStocks"] = cachList;
                }
            }
            addTOHits = false;

        }

        protected void grdvInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdvInfo.PageIndex = e.NewPageIndex;
            LoadStockInfo(e.NewPageIndex);
        }

        protected void txtFilter_TextChanged(object sender, EventArgs e)
        {
            if (txtFilter.Text.Length > 2)
            {
                addTOHits = true;
            }
            LoadStockInfo(0);           
        }

        protected void grdvInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
                      
            var grdView = (sender) as GridView;
            string ticker;
            if (grdView.SelectedRow.Cells.Count > 0)
            {
                ticker = grdView.SelectedRow.Cells[1].Text;
            }            
        }


        [WebMethod(EnableSession = true)]        
        public static KeyValuePair<string,decimal> UpdateStockPrice(string ticker)
        {
            var stockApi = new StockApiHandler();
            var cachList = HttpContext.Current.Session["CacheStocks"] as IList<string>;
            var rst = stockApi.GetStockDataByTicker(ticker, cachList);
           // var rst = RandomDecimal();
            if (!new DataBaseHandler().InsertStockValue(ticker, rst))
            { 
            //Exception when not updated
            }
            //var data = HttpContext.Current.Session["GrdView"] as IList<GetCompanyDetailsBySymbolOrNameResult1>;           
            //data.Where(w => w.Symbol == ticker).ToList().ForEach(w => w.MarketValue = rst);
            //HttpContext.Current.Session["GrdView"] = data;
            //HttpContext.Current.Session["GrdView"] = data.Where(w => w.Name == "Tom").Select(w => w.MarketValue = 10).ToList();

            return new KeyValuePair<string, decimal>(ticker, rst);           
        }

        private static decimal RandomDecimal()
        {
            int a = RandomNumber(2, 10);
            int b = RandomNumber(0, 99);

            string c = a + "." + b;
            decimal d = decimal.Parse(c);
            return d;
        }

        private static int RandomNumber(int min, int max)
        {
            return new Random().Next(min, max);
        }

        
    }
}