using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using BookShopModel;
using BookShopDAL;
using System.Data;

namespace BookShopBLL
{
    public class UserBLL
    {

        /// <summary>
        /// 比较登录密码
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="userpwd">密码</param>
        /// <returns></returns>11
        public static int UserLogin(string myuser)
        {
            string sqlStr = "select count(*) from UserTable where UserPwd = @userpwd";
            SqlParameter[] sqlParames = new SqlParameter[]{
                new SqlParameter("@userpwd", myuser)
            };
            return Convert.ToInt32(BookShopDAL.SqlHelper.ExecuteScalar(sqlStr, sqlParames));
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns></returns>
        public static int UserRegiste(UserModel newUser)
        {
            string sqlStr = "insert into UserTable(UserName,UserPwd,Email,Tel) values(@username,@userpwd,@email,@tel)";
            SqlParameter[] sqlParames = new SqlParameter[]{
                new SqlParameter("@username", newUser.UserName),
                new SqlParameter("@userpwd", newUser.UserPwd),
                new SqlParameter("@email", newUser.Email),
                new SqlParameter("@tel", newUser.Tel)
            };
            return BookShopDAL.SqlHelper.ExecuteNonQuery(sqlStr, sqlParames);
        }
        /// <summary>
        /// 比较用户名
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns></returns>
        public static int UserNames(UserModel newUser)
        {
            string sqlStr = "select count(*) from UserTable where UserName=@username";
            SqlParameter[] sqlParames = new SqlParameter[]{
                new SqlParameter("@username", newUser.UserName),
            };
            return Convert.ToInt32(BookShopDAL.SqlHelper.ExecuteScalar(sqlStr, sqlParames));
        }
        /// <summary>
        /// 找回密码
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns></returns>
        public static int FindPwd(UserModel newUser)
        {
            string sqlStr = "select count(*) from UserTable where UserName=@username and Email = @email";
            SqlParameter[] sqlParames = new SqlParameter[]{
                new SqlParameter("@username", newUser.UserName),
                new SqlParameter("@email",newUser.Email)
            };
            return Convert.ToInt32(BookShopDAL.SqlHelper.ExecuteScalar(sqlStr, sqlParames));
        }
        public static int ChangePwd(UserModel newUser)
        {
            string sqlStr = "update UserTable set UserPwd=@userpwd where UserName = @username";
            SqlParameter[] sqlParames = new SqlParameter[]{
                new SqlParameter("@username", newUser.UserName),
                new SqlParameter("@userpwd", newUser.UserPwd)
            };
            return BookShopDAL.SqlHelper.ExecuteNonQuery(sqlStr, sqlParames);
        }
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public static UserModel GetUser(string UserName)
        {
            string sql = "select * from UserTable where UserName =@username";
            UserModel myuser = new UserModel();
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@username",UserName)
            };
            using (SqlDataReader sdr = SqlHelper.ExcuteReader(sql, paras))
            {
                if (sdr != null)
                {
                    if (sdr.HasRows)
                    {

                        sdr.Read();
                        //NewsId = Convert.ToInt32(sdr["NewsId"]);
                        //news.Title = sdr["Title"].ToString();
                        //news.typename = sdr["TypeName"].ToString();
                        //news.UserName = sdr["UserName"].ToString();
                        //news.cdate = Convert.ToDateTime(sdr["cdate"]);
                        //news.Contents = sdr["Contents"].ToString();
                        //return news;
                        myuser.ID = sdr["ID"].ToString();
                        myuser.UserName = sdr["UserName"].ToString();
                        myuser.UserPwd = sdr["UserPwd"].ToString();
                        myuser.Email = sdr["Email"].ToString();
                        myuser.Tel = sdr["Tel"].ToString();
                        myuser.Address = sdr["Address"].ToString();
                        return myuser;
                    }
                    else
                        return null;
                }
                else
                    return null;
            }
        }
        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns></returns>
        public static int ChangeInfo(UserModel newUser)
        {
            string sqlStr = "update UserTable set UserName=@username,Email=@email,Tel=@tel,Address=@address where ID = @id";
            SqlParameter[] sqlParames = new SqlParameter[]{
                new SqlParameter("@username", newUser.UserName),
                new SqlParameter("@email",newUser.Email),
                new SqlParameter("@tel",newUser.Tel),
                new SqlParameter("@id",newUser.ID),
                new SqlParameter("@address",newUser.Address)
                
            };
            return BookShopDAL.SqlHelper.ExecuteNonQuery(sqlStr, sqlParames);
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns></returns>
        public static int ComparePwd(UserModel newUser)
        {
            string sqlStr = "select count(*) from UserTable where UserName=@username and UserPwd = @userpwd";
            SqlParameter[] sqlParames = new SqlParameter[]{
                new SqlParameter("@username", newUser.UserName),
                new SqlParameter("@userpwd",newUser.UserPwd)
            };
            return Convert.ToInt32(BookShopDAL.SqlHelper.ExecuteScalar(sqlStr, sqlParames));
        }
        public static int NewPwd(UserModel newUser)
        {
            string sqlStr = "update UserTable set UserPwd=@userpwd where UserName = @username";
            SqlParameter[] sqlParames = new SqlParameter[]{
                new SqlParameter("@username", newUser.UserName),
                new SqlParameter("@userpwd", newUser.UserPwd)
            };
            return BookShopDAL.SqlHelper.ExecuteNonQuery(sqlStr, sqlParames);
        }
        /// <summary>
        /// 获取用户ID
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public static string GetID(string UserName)
        {
            string sql = "select ID from UserTable where UserName =@username";
            string ID = "";
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@username",UserName)
            };
            using (SqlDataReader sdr = SqlHelper.ExcuteReader(sql, paras))
            {
                if (sdr != null)
                {
                    if (sdr.HasRows)
                    {

                        sdr.Read();
                        ID = sdr["ID"].ToString();
                        return ID;
                    }
                    else
                        return null;
                }
                else
                    return null;
            }
        }
        /// <summary>
        /// 获取用户封禁状态
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public static string GetDelete(string UserName)
        {
            string sql = "select Del from UserTable where UserName=@username";
            string Del = "";
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@username",UserName)
            };
            using (SqlDataReader sdr = SqlHelper.ExcuteReader(sql, paras))
            {
                if (sdr != null)
                {
                    if (sdr.HasRows)
                    {
                        sdr.Read();
                        Del = sdr["Del"].ToString();
                        return Del;
                    }
                    else
                        return null;
                }
                else
                    return null;
            }
        }
        /// <summary>
        /// 获取用户地址信息
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public static string GetAddress(string UserName)
        {
            string sql = "select Address from UserTable where UserName=@username";
            string Address = "";
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@username", UserName)
            };
            using (SqlDataReader sdr = SqlHelper.ExcuteReader(sql, paras))
            {
                if (sdr != null)
                {
                    if (sdr.HasRows)
                    {
                        sdr.Read();
                        Address = sdr["Address"].ToString();
                        return Address;
                    }
                    else
                        return null;
                }
                else
                    return null;
            }
        }
        /// <summary>
        /// 管理员权限判断
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public static string GetAdmin(string UserName)
        {
            string sql = "select Admin from UserTable where UserName =@username";
            string Admin = "";
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@username",UserName)
            };
            using (SqlDataReader sdr = SqlHelper.ExcuteReader(sql, paras))
            {
                if (sdr != null)
                {
                    if (sdr.HasRows)
                    {

                        sdr.Read();
                        Admin = sdr["Admin"].ToString();
                        return Admin;
                    }
                    else
                        return null;
                }
                else
                    return null;
            }
        }
        /// <summary>
        /// 封禁用户
        /// </summary>
        /// <returns></returns>
        public static List<UserModel> GetUserList()
        {
            string sqlStr = "select * from UserTable where Del = 0 and Admin = 0";
            List<UserModel> UserList = new List<UserModel>();
            using (SqlDataReader sdr = SqlHelper.ExcuteReader(sqlStr, null))
            {
                if (sdr != null)
                {
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            UserModel myuser = new UserModel();
                            myuser.ID = sdr["ID"].ToString();
                            myuser.UserName = sdr["UserName"].ToString();
                            myuser.UserPwd = sdr["UserPwd"].ToString();
                            myuser.Email = sdr["Email"].ToString();
                            myuser.Tel = sdr["Tel"].ToString();
                            UserList.Add(myuser);
                        }
                        return UserList;
                    }
                    else
                        return null;
                }
                else
                    return null;
            }

        }
        public static int DeleteUser2(UserModel User)
        {
            string sqlStr = "update UserTable set Del =1 where ID = @id";
            SqlParameter[] sqlParames = new SqlParameter[]{
                new SqlParameter("@id", User.ID)
            };
            return BookShopDAL.SqlHelper.ExecuteNonQuery(sqlStr, sqlParames);
        }
        /// <summary>
        /// 用户解封
        /// </summary>
        /// <param name="User"></param>
        /// <returns></returns>
        public static int UserRecover(UserModel User)
        {
            string sqlStr = "update UserTable set Del = 0 where ID = @id";
            SqlParameter[] sqlParames = new SqlParameter[]{
                new SqlParameter("@id", User.ID)
            };
            return BookShopDAL.SqlHelper.ExecuteNonQuery(sqlStr,sqlParames);
        }
        public static List<UserModel> GetDelUser()
        {
            string sqlStr = "select * from UserTable where Del = 1 and Admin = 0";
            List<UserModel> UserList = new List<UserModel>();
            using (SqlDataReader sdr = SqlHelper.ExcuteReader(sqlStr, null))
            {
                if (sdr != null)
                {
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            UserModel myuser = new UserModel();
                            myuser.ID = sdr["ID"].ToString();
                            myuser.UserName = sdr["UserName"].ToString();
                            myuser.UserPwd = sdr["UserPwd"].ToString();
                            myuser.Email = sdr["Email"].ToString();
                            myuser.Tel = sdr["Tel"].ToString();
                            UserList.Add(myuser);
                        }
                        return UserList;
                    }
                    else
                        return null;
                }
                else
                    return null;
            }

        }
        /// <summary>
        /// 管理员修改用户信息
        /// </summary>
        /// <param name="chooseBook"></param>
        /// <returns></returns>
        public static int changeinfo(UserModel user)
        {
            string sqlStr = "update UserTable set UserName =@username,Email =@email,Tel =@tel where ID =@id";
            SqlParameter[] sqlParames = new SqlParameter[]{
                new SqlParameter("@id", user.ID),
                new SqlParameter("@username", user.UserName),
                new SqlParameter("@email", user.Email),
                new SqlParameter("@tel", user.Tel),
            };
            return BookShopDAL.SqlHelper.ExecuteNonQuery(sqlStr, sqlParames);
        }

    }
}
