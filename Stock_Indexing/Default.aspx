<%@ Page Title="Stock Index Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Stock_Indexing._Default" Async="true" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript" >
        var total = 0;
        var current = 0;
            function loadMarketPrices(sender) {
                if (sender == 'OnDatBind') {                   
                    var grid = grdvInfo;
                    total = grid.rows.length - 2;
                    current = 0;
                    for (var index = 1; index < grid.rows.length-1; index++) {
                        var symbol = grid.rows[index].cells[1].innerText;
                        var postData = { ticker: symbol };
                        $.ajax({
                            type: "POST",
                            url: "Default.aspx/UpdateStockPrice",
                            data: JSON.stringify(postData),
                            contentType: 'application/json; charset=utf-8',
                            dataType: 'json',                            
                            async: true,
                            error: function (XMLHttpRequest, textStatus, errorThrown) {
                                current++;
                                alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                            },
                            success: function (result) {
                                current++;
                                for (var i = 1; i < grdvInfo.rows.length - 1; i++) {
                                    if (grdvInfo.rows[i].cells[1].innerText == result.d.Key)
                                    {
                                        grdvInfo.rows[i].cells[6].innerText = result.d.Value;
                                    }
                                }
                                if (current == total) {
                                    OrderGridView(6);
                                }
                            },
                            
                        });
                    }
                    //OrderGridView(6);
                    return true;
                }
        };

        function OrderGridView(idx) {
            var columnIndex = idx;
            var tdArray = $("#grdvInfo").closest("table").find("tr td:nth-child(" + (columnIndex + 1) + ")").not('a');
            
            if (tdArray.has('a').length>0) {
                tdArray = tdArray.slice(0, -1);
            }
            tdArray.sort(function (p, n) {
                var pData = parseFloat($(p).text());
                var nData = parseFloat($(n).text());
                return pData < nData ? -1 : 1;
            });
            tdArray.each(function () {
                var row = $(this).parent();
                $("#grdvInfo tr").first().after(row);
            });

        }
       
    </script>
    <div class="jumbotron">
        <h1>Stock Indexing</h1>
    </div>

    <div class="row">

        <div class="col-md-12">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional"><Triggers><asp:AsyncPostBackTrigger ControlID="grdvInfo" /> <asp:AsyncPostBackTrigger ControlID="txtFilter" /></Triggers>
                <ContentTemplate>
                    <p>
                        Filter By Ticker(Symbol) Or Name : 
             <asp:TextBox ID="txtFilter" runat="server" Width="100%" AutoCompleteType="Search" OnTextChanged="txtFilter_TextChanged"></asp:TextBox>
                    </p>

                    <asp:GridView ID="grdvInfo"  ClientIDMode="Static" runat="server" AllowPaging="True" AllowCustomPaging="true"  CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanging="grdvInfo_PageIndexChanging" Height="100%" Width="100%" RowStyle-Wrap="false" AutoGenerateSelectButton="True" OnSelectedIndexChanged="grdvInfo_SelectedIndexChanged">
                        
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775"  />
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"  />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                    </asp:GridView>  
                      <script type="text/javascript" language="javascript">                         
                          Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(pageLoaded);                          
                          function pageLoaded(sender, args) {
                              var isPostBack = sender.get_isInAsyncPostBack();
                              if (!isPostBack) {
                                  loadMarketPrices('OnDatBind');
                                  return;
                              }
                              else {                                  
                                  loadMarketPrices('OnDatBind');
                              }                              
                          }
                      </script>
   
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <div class="col-md-4">
        </div>
        <div class="col-md-4">
            <asp:Chart ID="chrtView" runat="server">
                <series>
                    <asp:Series ChartType="Line" Name="Series1">
                    </asp:Series>
                </series>
                <chartareas>
                    <asp:ChartArea Name="ChartArea1">
                    </asp:ChartArea>
                </chartareas>
            </asp:Chart>
        </div>
    </div>
  
</asp:Content>
