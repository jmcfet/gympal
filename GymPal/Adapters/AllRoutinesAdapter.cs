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
using GymPal.Core.Models;
using GymPal.Utility;
using System.Threading.Tasks;
using Android.Graphics;
using Android.Content.Res;

namespace GymPal.Adapters
{
    public class AllRoutinesAdapter : BaseAdapter<Routine>
    {
        List<Routine> routines;
        Activity context;
        public AllRoutinesAdapter(Activity context, List<Routine> items) : base()
        {
            this.context = context;
            this.routines = items;
        }
        public override Routine this[int position]
        {
            get
            {
                return routines[position];
            }
        }

        public override int Count
        {
            get
            {
                return routines.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = routines[position];

           
            if (convertView == null)
            {
                
                    convertView = context.LayoutInflater.Inflate(Resource.Layout.RoutineRow, null);
                    convertView.FindViewById<TextView>(Resource.Id.routineName).Text = item.Name;
                   
               
            
            }
                   
            return convertView;
        }

       
       

    }
}