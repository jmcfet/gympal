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
using GymPal.Core.Service;
using GymPal.Core.Models;
using Android.Graphics;
using GymPal.Utility;

namespace GymPal
{
    [Activity(Label = "Machine Details")]
    public class MachineDetail : Activity
    {
        private ImageView machineImageView;
        private TextView machineName;
        private TextView shortDescription;
        private TextView description;
        private GympalService dataService = new GymPal.Core.Service.GympalService();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.MachineDetailView);
           string xml = Intent.GetStringExtra("Machine");
            Machine machine = Newtonsoft.Json.JsonConvert.DeserializeObject<Machine>(xml);
           

            //// Remove the file extention from the image filename
           Android.Content.Res.Resources res = Resources;

            BitmapFactory.Options options = ImageHelper.GetBitmapOptionsOfImage(res, machine.PictureUrl);
            //// Converting Drawable Resource to Bitmap
            Bitmap bitmapToDisplay = ImageHelper.LoadScaledDownBitmapForDisplay(res, options, 150, 150, machine.PictureUrl);


            FindViewById<TextView>(Resource.Id.machineName).Text = machine.Name;
            //convertView.FindViewById<TextView>(Resource.Id.shortDescription).Text = item.shortDesc;
            ////    convertView.FindViewById<ImageView>(Android.Resource.Id.Icon).;
            FindViewById<ImageView>(Resource.Id.machineImageView).SetImageBitmap(bitmapToDisplay);
            //return convertView;
            //var selectedHotDogId = Intent.Extras.GetInt("selectedHotDogId");
            //selectedHotDog = dataService.GetHotDogById(selectedHotDogId);

            //FindViews();

            //BindData();

            //HandleEvents();
        }
    }
}

