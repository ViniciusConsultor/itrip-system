
//-------------------------------------------------------------------
//版权所有：版权所有  2008，Microsoft(China) Co.,LTD
//系统名称：公用控件
//文件名称：IsPageControl
//模块名称：分页控件

//作　　者：Yin Bo
//完成日期：
//功能说明：公用分页
//-----------------------------------------------------------------
//修改记录：

//修改人：  
//修改时间：

//修改内容：

//---------------------------------------
//.Net framework

using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using iTrip.Utility;

namespace iTrip.Controls
{
    public partial class IsPageControl : System.Web.UI.UserControl
    {
        string currentPageSizeFlag = "currentPageSizeFlag";
        int currentPageSize = 1;
        int allPageSize = 1;
        int pageSize = 1;
        int allRecordCount = 0;

        public delegate void PageHandler(int newPageIndex);   //声明委托

        public event PageHandler PageIndexChanging;        //声明事件


        string pageSizeFlag = "_pageSizeFlag";//一页要显示多少条
        string showPageNumFlag = "_showPageNumFlag";//显示的页码
        string allRecordCountFlag = "_allRecordCountFlag";//所有数据条数

        public IsPageControl()
        {
            currentPageSizeFlag = string.Format("{0}{1}", currentPageSizeFlag, this.ClientID);//this.ClientID+
            pageSizeFlag = string.Format("{0}{1}", pageSizeFlag, this.ClientID);//this.ClientID+
            showPageNumFlag = string.Format("{0}{1}", showPageNumFlag, this.ClientID);//this.ClientID+
            allRecordCountFlag = string.Format("{0}{1}", allRecordCountFlag, this.ClientID);//this.ClientID+
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                //  currentPageSizeFlag=string.Format("{0}{1}",currentPageSizeFlag,)
                if (ViewState[pageSizeFlag] != null)
                {
                    pageSize = int.Parse(ViewState[pageSizeFlag].ToString());

                }

                if (ViewState[currentPageSizeFlag] != null)
                {
                    currentPageSize = int.Parse(ViewState[currentPageSizeFlag].ToString());
                }

                if (ViewState[allRecordCountFlag] != null)
                {
                    allRecordCount = int.Parse(ViewState[allRecordCountFlag].ToString());
                    allPageSize = OprationPage(allRecordCount, pageSize);
                }
            }

            SetImageState();

        }

        public override void DataBind()
        {
            if (ViewState[pageSizeFlag] != null)
            {
                pageSize = int.Parse(ViewState[pageSizeFlag].ToString());

            }

            if (ViewState[currentPageSizeFlag] != null)
            {
                currentPageSize = int.Parse(ViewState[currentPageSizeFlag].ToString());
            }

            if (ViewState[allRecordCountFlag] != null)
            {
                allRecordCount = int.Parse(ViewState[allRecordCountFlag].ToString());
                allPageSize = OprationPage(allRecordCount, pageSize);
            }
            SetImageState();
        }

        private int OprationPage(int allRecordSize, int pageSize)
        {
            return (allRecordSize / pageSize) + (allRecordSize % pageSize == 0 ? 0 : 1);

        }
        protected virtual void OnPageChanged()
        {
            //DataBind();
            if (this.PageIndexChanging != null)
                PageIndexChanging(currentPageSize);
        }

        private void SetImageState()
        {
            this.ImageButtonNext.Enabled = true;
            this.ImageButtonPre.Enabled = true;
            this.ImageButtonFirst.Enabled = true;
            this.ImageButtonLast.Enabled = true;
            if (currentPageSize >= allPageSize)
            {
                this.ImageButtonNext.Enabled = false;
                this.ImageButtonLast.Enabled = false;
                currentPageSize = allPageSize;
            }
            if (currentPageSize <= 1)
            {
                this.ImageButtonFirst.Enabled = false;
                this.ImageButtonPre.Enabled = false;
            }
			 LabeltotalCount.Text = allRecordCount.ToString();
             LabelTotalPage.Text =
                allPageSize == 0 ? "1" : allPageSize.ToString(); 
             LabelcurrentPage.Text =
                currentPageSize==0 ? "1" : currentPageSize.ToString();
        }
        /// <summary>
        /// 页面的数量
        /// </summary>
        public int PageSize
        {
            set
            {
                pageSize = value;
                ViewState[pageSizeFlag] = pageSize;
            }
            get
            {
                return pageSize;
            }

        }

        /// <summary>
        /// 当前页
        /// </summary>
        public int CurrentPage
        {
            set
            {
                currentPageSize = value;
                ViewState[currentPageSizeFlag] = currentPageSize;
            }
            get
            {
                return currentPageSize;
            }

        }
        /// <summary>
        /// 所有的记录数
        /// </summary>
        public int AllRecordCount
        {
            set
            {
                allRecordCount = value;
                ViewState[allRecordCountFlag] = allRecordCount;

            }
            get
            {
                return allRecordCount;
            }

        }

        protected void ImageButtonFirst_Click(object sender, ImageClickEventArgs e)
        {
            currentPageSize = 1;
            ViewState[currentPageSizeFlag] = 1;
            this.OnPageChanged();

        }

        protected void ImageButtonPre_Click(object sender, ImageClickEventArgs e)
        {
            currentPageSize = currentPageSize - 1;
            currentPageSize = currentPageSize == 0 ? 1 : currentPageSize;
            ViewState[currentPageSizeFlag] = currentPageSize;
            this.OnPageChanged();
        }

        protected void ImageButtonNext_Click(object sender, ImageClickEventArgs e)
        {
            currentPageSize = currentPageSize + 1;
            ViewState[currentPageSizeFlag] = currentPageSize;
            this.OnPageChanged();
        }

        protected void ImageButtonLast_Click(object sender, ImageClickEventArgs e)
        {
            currentPageSize = allPageSize;
            ViewState[currentPageSizeFlag] = currentPageSize;
            this.OnPageChanged();
        }
    }
}