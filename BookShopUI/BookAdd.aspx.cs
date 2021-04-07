using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookShopModel;
using BookShopBLL;
using System.IO;

namespace BookShopUI
{
    public partial class BookAdd : System.Web.UI.Page
    {
        int a = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        /// <summary>
        /// 上传按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            if(a==0){
                BookModel myBook = new BookModel();
                myBook.BookID = BookID.Text;
                int success = BookBLL.oldBook(myBook);
                if (success == 0)
                {
                    BookAgain.Text = "图书号无重复";
                    a = 2;
                }
                else
                {
                    BookAgain.Text = "图书号重复";
                    a = 1;
                }
                }
            if (a == 1) {
                LabelShow.Text = "书号重复";
            }
             if(a==2){ 
                     if (IsValid)
                {
                    string strSavePath = Server.MapPath("~/Uploads/");
                    if (!Directory.Exists(strSavePath))
                        Directory.CreateDirectory(strSavePath);

                    if (fupImg.HasFile)
                    {
                        string fileName = fupImg.FileName;
                        string extName = Path.GetExtension(fileName).ToLower();
                        if (extName == ".gif" || extName == ".jpg" || extName == ".png")
                        {
                            if (fupImg.FileContent.Length <= 2 * 1024 * 1024)
                            {
                                fileName = BookName.Text + extName;
                                strSavePath = strSavePath + fileName;
                                fupImg.SaveAs(strSavePath);
                                labTips.Text = "<h2>文件上传成功</h2><p/>";
                                labTips.Text += "服务器端路径：" + strSavePath + "<p/>";
                                labTips.Text += "<img src='../Uploads/" + fileName + "'/>";
                                BookModel myBook = new BookModel();
                                myBook.BookID = BookID.Text;
                                myBook.BookName = BookName.Text;
                                myBook.BookAuthor = BookAuthor.Text;
                                myBook.BookThings = BookThings.Text;
                                myBook.BookPrice = Convert.ToSingle(BookPrice.Text);
                                myBook.BookFrom = BookFrom.Text;
                                myBook.BookNum = Convert.ToInt32(BookNum.Text);
                                myBook.BookPic = "../Uploads/" + fileName;
                                int success = BookBLL.BookUpload(myBook);
                                if (success == 1)
                                {
                                    LabelShow.Text = "图书上传成功";
                                }
                                else
                                {
                                    LabelShow.Text = "图书上传失败";
                                }


                            }
                            else
                            {
                                labTips.Text = "上传文件大小不能超过2MB";
                            }
                        }
                        else
                        {
                            labTips.Text = "只能上传.jpg、.png和.bmp格式的文件，请重新上传";
                        }
                    }
                    else
                    {
                        labTips.Text = "上传文件不存在，请先选择上传文件";
                    }
                }
                 
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
           
        }
    }
}