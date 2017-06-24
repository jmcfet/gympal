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
    [Activity(Label = "AllMachines")]
    public class AllMachinesActivity : Activity
    {
        ListView allMachinesView;
        List<Machine> listllMachines;
        GympalService service;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ListMachines);
            // Create your application here
            allMachinesView = FindViewById<ListView>(Resource.Id.AllMachinesListView);
            allMachinesView.ItemClick += AllMachinesView_ItemClick;
            service = new GympalService();
            listllMachines = service.GetAllMachines();
            allMachinesView.Adapter = new AllMachinesAdapter(this, listllMachines);
        }

        private void AllMachinesView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Machine  machine = listllMachines[e.Position];
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(machine);
            Intent intent = new Intent(this, typeof(MachineDetail));
            intent.PutExtra("Machine", json);
            
           
            StartActivity(intent);
        }
    }
}