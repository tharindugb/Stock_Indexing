using Stock_Indexing.DataSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stock_Indexing.Handlers
{
    public class DataBaseHandler
    {
        StockIndexDataContext _dataContext;

        public tblCompany GetCompanyDetailsBySymbol(string symbol)
        {            
            using(_dataContext = new StockIndexDataContext())
            {
                return _dataContext.GetCompanyDetailsBySymbol(symbol).FirstOrDefault();
            }           
        }

        public tblCompany GetCompanyDetailsByName(string name)
        {
            using (_dataContext = new StockIndexDataContext())
            {
                return _dataContext.GetCompanyDetailsBySymbol(name).FirstOrDefault();
            }
        }

        public IQueryable<tblCompany> GetAllCompanyDetails()
        {
            using (_dataContext = new StockIndexDataContext())
            {
                return _dataContext.GetAllCompanyDetails().AsQueryable();
            }
        }

        public IList<GetCompanyDetailsBySymbolOrNameResult1> GetAllCompanyDetailsWithPaging(string filter, int pagesize, int curretPage, out int recordCount )
        {
            if(string.IsNullOrEmpty(filter.Trim()))
            {
                filter = null;
            }
            int start = pagesize * curretPage;
            using (_dataContext = new StockIndexDataContext())
            {
                recordCount = _dataContext.GetCompanyDetailsBySymbolOrName(filter).Count();
                var dataList = _dataContext.GetCompanyDetailsBySymbolOrName(filter).AsQueryable().OrderBy(a => a.Symbol).Skip(start).Take(pagesize).ToList();
                return dataList;
            }
        }

        public bool InsertStockValue(string symbol, decimal value)
        {
            try
            {

                var stockData = new tblStockData { Symbol = symbol, StockValue = value, StockTime = long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss")) };
                   
                using (_dataContext = new StockIndexDataContext())
                {
                    try
                    {
                        _dataContext.tblStockDatas.InsertOnSubmit(stockData);
                        _dataContext.SubmitChanges();                        
                        return true;
                    }
                    catch (Exception e)
                    {                       
                        throw e;
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool InsertStockSearchHits(IList<string> symbols)
        {
            try
            {
                using (_dataContext = new StockIndexDataContext())
                {
                    try
                    {
                        foreach(var str in symbols)
                        {
                            (from s in _dataContext.tblStockSearchHits
                             where s.Symbol == str
                             select s).ToList().ForEach(x => x.HitCount++);
                        }

                        var newHits = (from i in symbols
                                       where !(_dataContext.tblStockSearchHits.Any(h => h.Symbol == i))
                                       select i).ToList();
                        var newHitItems = new List<tblStockSearchHit>();

                        if (newHits != null)
                        {
                            newHits.ForEach(a => newHitItems.Add(new tblStockSearchHit { Symbol = a, CurrentDate = DateTime.Now, HitCount = 1 }));
                            _dataContext.tblStockSearchHits.InsertAllOnSubmit(newHitItems);
                        }                       
                        _dataContext.SubmitChanges();
                        return true;
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public IList<string> GetSearchHits(int count)
        {            
            using (_dataContext = new StockIndexDataContext())
            {
                var stockHits = (from s in _dataContext.tblStockSearchHits
                                 orderby s.HitCount descending
                                 select s).Take(count).Select(a => a.Symbol).ToList();
                return stockHits;
            }
        }

        public IList<string> GetHighFluctuationStocks(int dtRange, int count)
        {
            using (_dataContext = new StockIndexDataContext())
            {
                var stockHits = (from s in _dataContext.GetHighPerformingStockInfo(dtRange)
                                 orderby s.stockfluctuate descending, s.avgStockValue ascending
                                 select s).Take(count).Select(a => a.Symbol).ToList();
                return stockHits;
            }
        }
    }
}