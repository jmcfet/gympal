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

namespace GymPal
{
    [Activity(Label = "BuildRoutine")]
    public class BuildRoutine : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.RoutinesMenu, menu);
            return true;
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.Add:
                    {
                        // add your code  
                        return true;
                    }
                //case Resource.Id.menuItem2:
                //    {
                //        // add your code  
                //        return true;
                //    }
                //case Resource.Id.menuItem3:
                //    {
                //        // add your code  
                //        return true;
                //    }
            }

            return base.OnOptionsItemSelected(item);
        }
    }
}