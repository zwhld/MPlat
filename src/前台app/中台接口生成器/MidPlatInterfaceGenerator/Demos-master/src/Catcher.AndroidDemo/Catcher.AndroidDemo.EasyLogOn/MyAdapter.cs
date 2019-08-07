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
using Java.Lang;

namespace Catcher.AndroidDemo.EasyLogOn
{
    public class MyAdapter : BaseAdapter<Model>
    {

        private readonly Activity _context;
        private readonly IList<Model> _types;
        public MyAdapter(Activity context,IList<Model> type)
        {
            this._context = context;
            this._types = type;
        }

        public override Model this[int position]
        {
            get
            {
                return this._types[position];
            }
        }

        public override int Count
        {
            get
            {
                return this._types.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            if (view == null)
            {
                view = this._context.LayoutInflater.Inflate(Resource.Layout.custom, null);
            }

            //set display value
            view.FindViewById<TextView>(Resource.Id.tv_lv1).Text =" ���ࣺ"+ this._types[position].CategoryName;

            view.FindViewById<TextView>(Resource.Id.tv_lv2).Text = "��" + this._types[position].MoneyValue;


            view.FindViewById<TextView>(Resource.Id.tv_lv3).Text = "���ͣ�" + this._types[position].MoneyType;

            view.FindViewById<TextView>(Resource.Id.tv_lv4).Text = "��ע��" + this._types[position].MoneyAbout;

            view.FindViewById<TextView>(Resource.Id.tv_lv5).Text = " ���ڣ�" + DateTime.Parse(this._types[position].MoneyDate).ToString("yyyy-MM-dd");
            
            return view;
        }
    }
}