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
using Android;

namespace GymPal
{
    [Activity(Label = "MenuActivity", MainLauncher = true)]
    public class MenuActivity : Activity
    {
        private Button listallButton;
        private Button cartButton;
        private Button aboutButton;
        private Button mapButton;
        private Button takePictureButton;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MainMenu);

            FindViews();

            HandleEvents();
        }

        private void FindViews()
        {
            listallButton = FindViewById<Button>(Resource.Id.listallButton);
            cartButton = FindViewById<Button>(Resource.Id.cartButton);
            aboutButton = FindViewById<Button>(Resource.Id.aboutButton);
            mapButton = FindViewById<Button>(Resource.Id.mapButton);
            takePictureButton = FindViewById<Button>(Resource.Id.takePictureButton);
        }

        private void HandleEvents()
        {
            listallButton.Click += listallButton_Click;
            aboutButton.Click += AboutButton_Click;
            takePictureButton.Click += TakePictureButton_Click;
            mapButton.Click += MapButton_Click;
        }

        private void TakePictureButton_Click(object sender, EventArgs e)
        {
      //      var intent = new Intent(this, typeof(TakePictureActivity));
      //      StartActivity(intent);
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
      //      var intent = new Intent(this, typeof(AboutActivity));
       //     StartActivity(intent);
        }

        private void listallButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(AllMachinesActivity));
            StartActivity(intent);
        }

        private void MapButton_Click(object sender, EventArgs e)
        {
     //       var intent = new Intent(this, typeof(RayMapActivity));
      //      StartActivity(intent);
        }
    }
}

