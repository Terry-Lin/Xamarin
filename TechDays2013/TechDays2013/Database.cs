// This file has been autogenerated from parsing an Objective-C header file added in Xcode.

using System;
using System.IO;
using System.Drawing;
using System.Data;
using System.Text;
using Mono.Data.Sqlite;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Mono.Data.Sqlcipher;


namespace TechDays2013
{
	public partial class Database : UIViewController
	{
		public Database (IntPtr handle) : base (handle)
		{
			this.Title = "SQLite & SQL Cipher";
		}

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            this.lblmsg.Text = "";
            btnSQLite.TouchUpInside += btnSQLite_TouchUpInside;
            btnCipher.TouchUpInside += btnCipher_TouchUpInside;
            btnRead.TouchUpInside += btnRead_TouchUpInside; 
        }

        //建立SQLite 資料庫
        void btnSQLite_TouchUpInside(object sender, EventArgs e)
        {
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var pathToDatabase = Path.Combine(documents, "normal.db");
            Mono.Data.Sqlite.SqliteConnection.CreateFile(pathToDatabase);

            var msg = "資料庫路徑為: " + pathToDatabase;

            //建立Table
            var connectionString = String.Format("Data Source={0};Version=3;", pathToDatabase);


            using (var conn = new Mono.Data.Sqlite.SqliteConnection(connectionString))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "CREATE TABLE People (PersonID INTEGER PRIMARY KEY AUTOINCREMENT , FirstName ntext, LastName ntext)";
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }

            //新增資料
            using (var conn = new Mono.Data.Sqlite.SqliteConnection(connectionString))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "Insert into People(FirstName,LastName) Values('Terry','Lin') ;";
                    cmd.CommandText += "Insert into People(FirstName,LastName) Values('Ben','Lu') ";
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }

            // 訊息輸出並停用Button
            lblmsg.Text = msg;
            this.btnSQLite.Enabled = false;
        }
        

        //建立SQL Cipher資料庫
        void btnCipher_TouchUpInside(object sender, EventArgs e)
        {
            // 建立資料庫
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var pathToDatabase = Path.Combine(documents, "cipher.db");
            Mono.Data.Sqlcipher.SqliteConnection.CreateFile(pathToDatabase);

            var msg = "資料庫名稱為: " + pathToDatabase;

            //建立Table
            var connectionString = String.Format("Data Source={0};Version=3;", pathToDatabase);

            using (var conn = new Mono.Data.Sqlcipher.SqliteConnection(connectionString))
            {
                conn.SetPassword("test");
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "CREATE TABLE People (PersonID INTEGER PRIMARY KEY AUTOINCREMENT , FirstName ntext, LastName ntext)";
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }

            //新增資料
            using (var conn = new Mono.Data.Sqlcipher.SqliteConnection(connectionString))
            {
                conn.SetPassword("test");
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "Insert into People(FirstName,LastName) Values('Terry','Lin') ;";
                    cmd.CommandText += "Insert into People(FirstName,LastName) Values('Ben','Lu') ";
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }

            // 訊息輸出並停用Button
            lblmsg.Text = msg;
            this.btnCipher.Enabled = false;   
        }
        

        //讀取加密資料庫資料
        void btnRead_TouchUpInside(object sender, EventArgs e)
        {
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var pathToDatabase = Path.Combine(documents, "cipher.db");
            var connectionString = String.Format("Data Source={0};Version=3;", pathToDatabase);
            this.lblmsg.Text = "";
            using (var conn = new Mono.Data.Sqlcipher.SqliteConnection(connectionString))
            {
                conn.SetPassword("test");
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "Select * from People";
                    cmd.CommandType = CommandType.Text;
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        this.lblmsg.Text += string.Format("First Name:{0} Last Name:{1}\r\n", reader[1].ToString(), reader[2].ToString());
                    }
                    reader.Close();
                }
            }
        }
       
    }
}
