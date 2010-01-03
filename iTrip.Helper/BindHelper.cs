using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using System.Web;
using iTrip.Utility;
namespace iTrip.Helper
{
    public class BindHelper
    {

        /// <summary>
        /// 绑定DropDownList对象
        /// </summary>
        /// <param name="ddl">DropDownList对象</param>
        /// <param name="dt">datatable对象</param>
        /// <param name="strValueName">值</param>
        /// <param name="strTextName">显示文本</param>
        /// <param name="isNull">是否必选</param>
        /// <returns></returns>
        public static void BindDropDownList(DropDownList ddl, DataTable dt, string strValueName, string strTextName, bool isNull)
        {
            ddl.DataSource = dt.DefaultView;
            ddl.DataTextField = strTextName;
            ddl.DataValueField = strValueName;
            ddl.DataBind();

            if (isNull)
            {
                ListItem li = new ListItem();
                li.Value = "";
                li.Text = "-->请选择<--";
                ddl.Items.Insert(0, li);
            }
        }

        //绑定空值到控件
        public static void BindDropDownListByNull(DropDownList ddl, bool isClear)
        {
            if (isClear)
                ddl.Items.Clear();

            ddl.Items.Add(new ListItem("-->请选择<--",string.Empty));
        }

        //根据GridView中记录来定位高度
        public static void BindDataGridViewFixHeightD(YYControls.SmartGridView GridID, int ViewRowSize, double? _RecordHeight)
        {
            double TableTotalHeight = 48;
            if (Utils.IsNotEmpty(GridID.FixRowColumn.TableHeight) && GridID.FixRowColumn.TableHeight.IndexOf("px") != -1)
            {
                string dbStr = GridID.FixRowColumn.TableHeight.Substring(0, GridID.FixRowColumn.TableHeight.IndexOf("px"));
                if (Utils.isDecimal(dbStr))
                {
                    TableTotalHeight = double.Parse(GridID.FixRowColumn.TableHeight.Substring(0, GridID.FixRowColumn.TableHeight.IndexOf("px")));
                }
            }

            double RecordHeight = 28;
            int rowsCount = 0;
            rowsCount = GridID.Rows.Count;
            if (_RecordHeight.HasValue)
            {
                RecordHeight = _RecordHeight.Value;
            }
            if (rowsCount > 0)
            {
                if (rowsCount > ViewRowSize)
                {
                    TableTotalHeight =
                        (TableTotalHeight + RecordHeight * ViewRowSize);
                }
                else
                {
                    TableTotalHeight =
                       (TableTotalHeight + RecordHeight * rowsCount);
                }
            }
            GridID.FixRowColumn.TableHeight = Convert.ToString(TableTotalHeight) + "px";
        }
    }
}
