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
    [Activity(Label = "selectMachines")]
    public class selectMachines : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.selectMachines);
            ListView allMachinesView = FindViewById<ListView>(Resource.Id.listMachines);
            string xml = Intent.GetStringExtra("Machines");
            List<Machine> machines = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Machine>>(xml);
            allMachinesView.Adapter = new AllMachinesAdapter(this, machines);
        }
    }
}