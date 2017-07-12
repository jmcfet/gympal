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
using GymPal.Core.Service;
using GymPal.Adapters;

namespace GymPal
{
    [Activity(Label = "BuildRoutine")]
    public class BuildRoutine : Activity
    {
        ListView allRoutinesView;
        Button add;
        List<Routine> listallRoutines;
        GympalService service = new GympalService();
        AllRoutinesAdapter adapter;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.BuildRoutine);
            allRoutinesView = FindViewById<ListView>(Resource.Id.listRoutines);
            FindViewById<Button>(Resource.Id.Add).Click += BuildRoutine_Click;
            allRoutinesView.ItemClick += AllRoutinesView_ItemClick;
            listallRoutines = service.GetAllRoutines();
            adapter = new AllRoutinesAdapter(this, listallRoutines);
            allRoutinesView.Adapter = new AllRoutinesAdapter(this, listallRoutines);

            // Create your application here
        }

        private void AllRoutinesView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Routine  routine = listallRoutines[e.Position];
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(routine);
            Intent intent = new Intent(this, typeof(RoutineEditor));
            intent.PutExtra("Routine", json);


            StartActivity(intent);
        }

        private void BuildRoutine_Click(object sender, EventArgs e)
        {
            FragmentTransaction transcation = FragmentManager.BeginTransaction();
            GetNameDialog signup = new GetNameDialog();
            signup.Show(transcation, "Dialog Fragment");
            signup.mOnsignupDone += Signup_mOnOK;
           
        }

        //public override bool OnCreateOptionsMenu(IMenu menu)
        //{
        //    MenuInflater.Inflate(Resource.Menu.RoutinesMenu, menu);
        //    return true;
        //}
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.Add:
                    {
                        FragmentTransaction transcation = FragmentManager.BeginTransaction();
                        GetNameDialog signup = new GetNameDialog();
                        signup.Show(transcation, "Dialog Fragment");
                        signup.mOnsignupDone += Signup_mOnOK ;
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

        private void Signup_mOnOK(object sender, OnNameEventArgs e)
        {
            string test = e.mName;
            listallRoutines.Add(new Routine() { Name = e.mName });
            //    RunOnUiThread(() => adapter.NotifyDataSetChanged());
       
            allRoutinesView.Adapter = new AllRoutinesAdapter(this, listallRoutines);

        }
    }
}