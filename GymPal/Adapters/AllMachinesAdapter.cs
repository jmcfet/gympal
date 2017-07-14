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
    public class MachineCheckEventArgs : EventArgs
    {
        string mname;
        bool m_state;
        public string mName
        {
            get { return mname; }
            set { mname = value; }
        }
        public bool state
        {
            get { return m_state; }
            set { m_state = value; }
        }
        public MachineCheckEventArgs(string name) : base()
        {
            mname = name;

        }
    }
    public class AllMachinesAdapter : BaseAdapter<Machine>
    {
        List<Machine> machines;
        Activity context;
        public event EventHandler<MachineCheckEventArgs> selectDone;
        public AllMachinesAdapter(Activity context, List<Machine> items) : base()
        {
            this.context = context;
            this.machines = items;
        }
        public override Machine this[int position]
        {
            get
            {
                return machines[position];
            }
        }

        public override int Count
        {
            get
            {
                return machines.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = machines[position];

            // Remove the file extention from the image filename
            Android.Content.Res.Resources res = context.Resources;

            BitmapFactory.Options options = ImageHelper.GetBitmapOptionsOfImage(res, item.PictureUrl);
            // Converting Drawable Resource to Bitmap
            Bitmap bitmapToDisplay = ImageHelper.LoadScaledDownBitmapForDisplay(res, options, 150, 150, item.PictureUrl);

            if (convertView == null)
            {
                if (this.context.GetType() == typeof(BuildRoutine) || this.context.GetType() == typeof(selectMachines))
                {
                    convertView = context.LayoutInflater.Inflate(Resource.Layout.MachinewithCheck, null);
                    convertView.FindViewById<TextView>(Resource.Id.MachineName1).Text = item.Name;
                    convertView.FindViewById<TextView>(Resource.Id.shortDescription1).Text = item.shortDesc;
                    //    convertView.FindViewById<ImageView>(Android.Resource.Id.Icon).;
                    convertView.FindViewById<ImageView>(Resource.Id.machineIcon1).SetImageBitmap(bitmapToDisplay);
                    CheckBox check = convertView.FindViewById<CheckBox>(Resource.Id.selectMachineCheck);
                    check.SetTag(Resource.Id.selectMachineCheck, item.Name);
                    check.Click += AllMachinesAdapter_Click;
                }
                else
                {
                    convertView = context.LayoutInflater.Inflate(Resource.Layout.MachineListRow, null);
                    convertView.FindViewById<TextView>(Resource.Id.MachineName).Text = item.Name;
                    convertView.FindViewById<TextView>(Resource.Id.shortDescription).Text = item.shortDesc;
                    //    convertView.FindViewById<ImageView>(Android.Resource.Id.Icon).;
                    convertView.FindViewById<ImageView>(Resource.Id.machineIcon).SetImageBitmap(bitmapToDisplay);
                }
            
            }
                   
            return convertView;
        }
        //user checked a box so broadcast ann event
        private void AllMachinesAdapter_Click(object sender, EventArgs e)
        {
            CheckBox box = sender as CheckBox;
            if (box.Checked == true)
            {
                string machineName = (string)box.GetTag(Resource.Id.selectMachineCheck);
                selectDone.Invoke(this, new MachineCheckEventArgs(machineName));
            }
            
        }
    }
}