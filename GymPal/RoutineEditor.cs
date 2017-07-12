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
using GymPal.Adapters;

namespace GymPal
{
    [Activity(Label = "RoutineEditor")]
    public class RoutineEditor : Activity
    {
        Routine routine;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.RoutineEditor);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetActionBar(toolbar);
            
            string xml = Intent.GetStringExtra("Routine");
            routine = Newtonsoft.Json.JsonConvert.DeserializeObject<Routine>(xml);
            ListView allMachinesView = FindViewById<ListView>(Resource.Id.machines);
            //allMachinesView.ItemClick += AllMachinesView_ItemClick;
            //service = new GympalService();
            //listllMachines = service.GetAllMachines();
            ActionBar.Title = routine.Name;
            allMachinesView.Adapter = new AllMachinesAdapter(this, routine.Machines);

        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.RoutinesMenu, menu);
            return base.OnCreateOptionsMenu(menu);
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.Add:
                    {
                        GymPal.Core.Service.GympalService service = new GymPal.Core.Service.GympalService();
                        List<Machine> machines = service.getmachinesNotInRoutine(routine);
                        
                        string json = Newtonsoft.Json.JsonConvert.SerializeObject(machines);
                        Intent intent = new Intent(this, typeof(selectMachines));
                        intent.PutExtra("Machines", json);


                        StartActivity(intent);
                        return true;
                    }
                   
            }

            return base.OnOptionsItemSelected(item);
        }
    }
}