﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Stock_Indexing.DataSource
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="StockIndexer")]
	public partial class StockIndexDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InserttblCompany(tblCompany instance);
    partial void UpdatetblCompany(tblCompany instance);
    partial void DeletetblCompany(tblCompany instance);
    partial void InserttblStockData(tblStockData instance);
    partial void UpdatetblStockData(tblStockData instance);
    partial void DeletetblStockData(tblStockData instance);
    partial void InserttblStockSearchHit(tblStockSearchHit instance);
    partial void UpdatetblStockSearchHit(tblStockSearchHit instance);
    partial void DeletetblStockSearchHit(tblStockSearchHit instance);
    #endregion
		
		public StockIndexDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["StockIndexerConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public StockIndexDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public StockIndexDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public StockIndexDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public StockIndexDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<tblCompany> tblCompanies
		{
			get
			{
				return this.GetTable<tblCompany>();
			}
		}
		
		public System.Data.Linq.Table<tblStockData> tblStockDatas
		{
			get
			{
				return this.GetTable<tblStockData>();
			}
		}
		
		public System.Data.Linq.Table<tblStockSearchHit> tblStockSearchHits
		{
			get
			{
				return this.GetTable<tblStockSearchHit>();
			}
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.GetAllCompanyDetails")]
		public ISingleResult<tblCompany> GetAllCompanyDetails()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			return ((ISingleResult<tblCompany>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.GetCompanyDetailsByName")]
		public ISingleResult<tblCompany> GetCompanyDetailsByName([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(255)")] string parmName)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), parmName);
			return ((ISingleResult<tblCompany>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.GetCompanyDetailsBySymbol")]
		public ISingleResult<tblCompany> GetCompanyDetailsBySymbol([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(10)")] string parmSymbol)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), parmSymbol);
			return ((ISingleResult<tblCompany>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.GetCompanyDetailsBySymbolOrName")]
		public ISingleResult<GetCompanyDetailsBySymbolOrNameResult1> GetCompanyDetailsBySymbolOrName([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(255)")] string parmFilter)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), parmFilter);
			return ((ISingleResult<GetCompanyDetailsBySymbolOrNameResult1>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.GetHighPerformingStockInfo")]
		public ISingleResult<GetHighPerformingStockInfoResult> GetHighPerformingStockInfo([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> parmDateRange)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), parmDateRange);
			return ((ISingleResult<GetHighPerformingStockInfoResult>)(result.ReturnValue));
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.tblCompany")]
	public partial class tblCompany : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _Symbol;
		
		private string _Name;
		
		private System.Nullable<double> _MarketCap;
		
		private string _Sector;
		
		private string _Industry;
		
		private EntitySet<tblStockData> _tblStockDatas;
		
		private EntitySet<tblStockSearchHit> _tblStockSearchHits;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnSymbolChanging(string value);
    partial void OnSymbolChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnMarketCapChanging(System.Nullable<double> value);
    partial void OnMarketCapChanged();
    partial void OnSectorChanging(string value);
    partial void OnSectorChanged();
    partial void OnIndustryChanging(string value);
    partial void OnIndustryChanged();
    #endregion
		
		public tblCompany()
		{
			this._tblStockDatas = new EntitySet<tblStockData>(new Action<tblStockData>(this.attach_tblStockDatas), new Action<tblStockData>(this.detach_tblStockDatas));
			this._tblStockSearchHits = new EntitySet<tblStockSearchHit>(new Action<tblStockSearchHit>(this.attach_tblStockSearchHits), new Action<tblStockSearchHit>(this.detach_tblStockSearchHits));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Symbol", DbType="NVarChar(10) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string Symbol
		{
			get
			{
				return this._Symbol;
			}
			set
			{
				if ((this._Symbol != value))
				{
					this.OnSymbolChanging(value);
					this.SendPropertyChanging();
					this._Symbol = value;
					this.SendPropertyChanged("Symbol");
					this.OnSymbolChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(255)")]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MarketCap", DbType="Float")]
		public System.Nullable<double> MarketCap
		{
			get
			{
				return this._MarketCap;
			}
			set
			{
				if ((this._MarketCap != value))
				{
					this.OnMarketCapChanging(value);
					this.SendPropertyChanging();
					this._MarketCap = value;
					this.SendPropertyChanged("MarketCap");
					this.OnMarketCapChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Sector", DbType="NVarChar(255)")]
		public string Sector
		{
			get
			{
				return this._Sector;
			}
			set
			{
				if ((this._Sector != value))
				{
					this.OnSectorChanging(value);
					this.SendPropertyChanging();
					this._Sector = value;
					this.SendPropertyChanged("Sector");
					this.OnSectorChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Industry", DbType="NVarChar(255)")]
		public string Industry
		{
			get
			{
				return this._Industry;
			}
			set
			{
				if ((this._Industry != value))
				{
					this.OnIndustryChanging(value);
					this.SendPropertyChanging();
					this._Industry = value;
					this.SendPropertyChanged("Industry");
					this.OnIndustryChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="tblCompany_tblStockData", Storage="_tblStockDatas", ThisKey="Symbol", OtherKey="Symbol")]
		public EntitySet<tblStockData> tblStockDatas
		{
			get
			{
				return this._tblStockDatas;
			}
			set
			{
				this._tblStockDatas.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="tblCompany_tblStockSearchHit", Storage="_tblStockSearchHits", ThisKey="Symbol", OtherKey="Symbol")]
		public EntitySet<tblStockSearchHit> tblStockSearchHits
		{
			get
			{
				return this._tblStockSearchHits;
			}
			set
			{
				this._tblStockSearchHits.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_tblStockDatas(tblStockData entity)
		{
			this.SendPropertyChanging();
			entity.tblCompany = this;
		}
		
		private void detach_tblStockDatas(tblStockData entity)
		{
			this.SendPropertyChanging();
			entity.tblCompany = null;
		}
		
		private void attach_tblStockSearchHits(tblStockSearchHit entity)
		{
			this.SendPropertyChanging();
			entity.tblCompany = this;
		}
		
		private void detach_tblStockSearchHits(tblStockSearchHit entity)
		{
			this.SendPropertyChanging();
			entity.tblCompany = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.tblStockData")]
	public partial class tblStockData : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _Symbol;
		
		private decimal _StockTime;
		
		private System.Nullable<decimal> _StockValue;
		
		private EntityRef<tblCompany> _tblCompany;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnSymbolChanging(string value);
    partial void OnSymbolChanged();
    partial void OnStockTimeChanging(decimal value);
    partial void OnStockTimeChanged();
    partial void OnStockValueChanging(System.Nullable<decimal> value);
    partial void OnStockValueChanged();
    #endregion
		
		public tblStockData()
		{
			this._tblCompany = default(EntityRef<tblCompany>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Symbol", DbType="NVarChar(10) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string Symbol
		{
			get
			{
				return this._Symbol;
			}
			set
			{
				if ((this._Symbol != value))
				{
					if (this._tblCompany.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnSymbolChanging(value);
					this.SendPropertyChanging();
					this._Symbol = value;
					this.SendPropertyChanged("Symbol");
					this.OnSymbolChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StockTime", DbType="Decimal(18,0) NOT NULL", IsPrimaryKey=true)]
		public decimal StockTime
		{
			get
			{
				return this._StockTime;
			}
			set
			{
				if ((this._StockTime != value))
				{
					this.OnStockTimeChanging(value);
					this.SendPropertyChanging();
					this._StockTime = value;
					this.SendPropertyChanged("StockTime");
					this.OnStockTimeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StockValue", DbType="Decimal(10,2)")]
		public System.Nullable<decimal> StockValue
		{
			get
			{
				return this._StockValue;
			}
			set
			{
				if ((this._StockValue != value))
				{
					this.OnStockValueChanging(value);
					this.SendPropertyChanging();
					this._StockValue = value;
					this.SendPropertyChanged("StockValue");
					this.OnStockValueChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="tblCompany_tblStockData", Storage="_tblCompany", ThisKey="Symbol", OtherKey="Symbol", IsForeignKey=true)]
		public tblCompany tblCompany
		{
			get
			{
				return this._tblCompany.Entity;
			}
			set
			{
				tblCompany previousValue = this._tblCompany.Entity;
				if (((previousValue != value) 
							|| (this._tblCompany.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._tblCompany.Entity = null;
						previousValue.tblStockDatas.Remove(this);
					}
					this._tblCompany.Entity = value;
					if ((value != null))
					{
						value.tblStockDatas.Add(this);
						this._Symbol = value.Symbol;
					}
					else
					{
						this._Symbol = default(string);
					}
					this.SendPropertyChanged("tblCompany");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.tblStockSearchHits")]
	public partial class tblStockSearchHit : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _Symbol;
		
		private System.DateTime _CurrentDate;
		
		private System.Nullable<decimal> _HitCount;
		
		private EntityRef<tblCompany> _tblCompany;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnSymbolChanging(string value);
    partial void OnSymbolChanged();
    partial void OnCurrentDateChanging(System.DateTime value);
    partial void OnCurrentDateChanged();
    partial void OnHitCountChanging(System.Nullable<decimal> value);
    partial void OnHitCountChanged();
    #endregion
		
		public tblStockSearchHit()
		{
			this._tblCompany = default(EntityRef<tblCompany>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Symbol", DbType="NVarChar(10) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string Symbol
		{
			get
			{
				return this._Symbol;
			}
			set
			{
				if ((this._Symbol != value))
				{
					if (this._tblCompany.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnSymbolChanging(value);
					this.SendPropertyChanging();
					this._Symbol = value;
					this.SendPropertyChanged("Symbol");
					this.OnSymbolChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CurrentDate", DbType="Date NOT NULL", IsPrimaryKey=true)]
		public System.DateTime CurrentDate
		{
			get
			{
				return this._CurrentDate;
			}
			set
			{
				if ((this._CurrentDate != value))
				{
					this.OnCurrentDateChanging(value);
					this.SendPropertyChanging();
					this._CurrentDate = value;
					this.SendPropertyChanged("CurrentDate");
					this.OnCurrentDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HitCount", DbType="Decimal(9,0)")]
		public System.Nullable<decimal> HitCount
		{
			get
			{
				return this._HitCount;
			}
			set
			{
				if ((this._HitCount != value))
				{
					this.OnHitCountChanging(value);
					this.SendPropertyChanging();
					this._HitCount = value;
					this.SendPropertyChanged("HitCount");
					this.OnHitCountChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="tblCompany_tblStockSearchHit", Storage="_tblCompany", ThisKey="Symbol", OtherKey="Symbol", IsForeignKey=true)]
		public tblCompany tblCompany
		{
			get
			{
				return this._tblCompany.Entity;
			}
			set
			{
				tblCompany previousValue = this._tblCompany.Entity;
				if (((previousValue != value) 
							|| (this._tblCompany.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._tblCompany.Entity = null;
						previousValue.tblStockSearchHits.Remove(this);
					}
					this._tblCompany.Entity = value;
					if ((value != null))
					{
						value.tblStockSearchHits.Add(this);
						this._Symbol = value.Symbol;
					}
					else
					{
						this._Symbol = default(string);
					}
					this.SendPropertyChanged("tblCompany");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	public partial class GetCompanyDetailsBySymbolOrNameResult1
	{
		
		private string _Symbol;
		
		private string _Name;
		
		private System.Nullable<double> _MarketCap;
		
		private string _Sector;
		
		private string _Industry;
		
		private decimal _MarketValue;
		
		public GetCompanyDetailsBySymbolOrNameResult1()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Symbol", DbType="NVarChar(10) NOT NULL", CanBeNull=false)]
		public string Symbol
		{
			get
			{
				return this._Symbol;
			}
			set
			{
				if ((this._Symbol != value))
				{
					this._Symbol = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(255)")]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this._Name = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MarketCap", DbType="Float")]
		public System.Nullable<double> MarketCap
		{
			get
			{
				return this._MarketCap;
			}
			set
			{
				if ((this._MarketCap != value))
				{
					this._MarketCap = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Sector", DbType="NVarChar(255)")]
		public string Sector
		{
			get
			{
				return this._Sector;
			}
			set
			{
				if ((this._Sector != value))
				{
					this._Sector = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Industry", DbType="NVarChar(255)")]
		public string Industry
		{
			get
			{
				return this._Industry;
			}
			set
			{
				if ((this._Industry != value))
				{
					this._Industry = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MarketValue", DbType="Decimal(3,3) NOT NULL")]
		public decimal MarketValue
		{
			get
			{
				return this._MarketValue;
			}
			set
			{
				if ((this._MarketValue != value))
				{
					this._MarketValue = value;
				}
			}
		}
	}
	
	public partial class GetHighPerformingStockInfoResult
	{
		
		private string _Symbol;
		
		private System.Nullable<decimal> _stockfluctuate;
		
		private System.Nullable<decimal> _avgStockValue;
		
		public GetHighPerformingStockInfoResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Symbol", DbType="NVarChar(10) NOT NULL", CanBeNull=false)]
		public string Symbol
		{
			get
			{
				return this._Symbol;
			}
			set
			{
				if ((this._Symbol != value))
				{
					this._Symbol = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_stockfluctuate", DbType="Decimal(11,2)")]
		public System.Nullable<decimal> stockfluctuate
		{
			get
			{
				return this._stockfluctuate;
			}
			set
			{
				if ((this._stockfluctuate != value))
				{
					this._stockfluctuate = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_avgStockValue", DbType="Decimal(38,6)")]
		public System.Nullable<decimal> avgStockValue
		{
			get
			{
				return this._avgStockValue;
			}
			set
			{
				if ((this._avgStockValue != value))
				{
					this._avgStockValue = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
