using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using XamarinSmsSample.Droid.Services;

[assembly: Dependency(typeof(SmsService))]
namespace XamarinSmsSample.Droid.Services
{
    public class SmsService : XamarinSmsSample.Services.ISmsService
    {
        public List<string> ReadSms(string p0)
        {
            var ret = new List<string>();

            string INBOX = "content://sms/inbox";
            string[] reqCols = new string[] { "_id", "thread_id", "address", "person", "date", "body", "type" };
            Android.Net.Uri uri = Android.Net.Uri.Parse(INBOX);
            
            var cursor = Android.App.Application.Context.ContentResolver.Query(uri, reqCols, null, null, null);

            if (cursor.MoveToFirst())
            {
                do
                {
                    String messageId = cursor.GetString(cursor.GetColumnIndex(reqCols[0]));
                    String threadId = cursor.GetString(cursor.GetColumnIndex(reqCols[1]));
                    String address = cursor.GetString(cursor.GetColumnIndex(reqCols[2]));
                    String name = cursor.GetString(cursor.GetColumnIndex(reqCols[3]));
                    String date = cursor.GetString(cursor.GetColumnIndex(reqCols[4]));
                    String msg = cursor.GetString(cursor.GetColumnIndex(reqCols[5]));
                    String type = cursor.GetString(cursor.GetColumnIndex(reqCols[6]));

                    ret.Add($"{messageId}:{name},{msg}");

                } while (cursor.MoveToNext());

            }

            return ret;
        }
    }
}