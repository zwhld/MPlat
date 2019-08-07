using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Catcher.AndroidDemo.EasyLogOn
{
    public static class DB
    {
        public static List<Model> Types { get; private set; }

        static DB()
        {
            Types = new List<Model>();
            Types.Add(new Model { CategoryName="�·�", MoneyDate="2016-01-01 0:00:00", MoneyAbout="zzz", MoneyType="֧��", MoneyValue="29.7" });
            Types.Add(new Model { CategoryName = "����", MoneyDate = "2016-01-02 0:00:00", MoneyAbout = "", MoneyType = "֧��", MoneyValue = "27" });  
        }
    }
}