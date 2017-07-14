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
        List<Machine> toAdd = new List<Machine>();
        List<Machine> machines;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.selectMachines);
            ListView allMachinesView = FindViewById<ListView>(Resource.Id.listMachines);
            FindViewById<Button>(Resource.Id.DoneSelect).Click += SelectMachines_Click; ;
          
            string xml = Intent.GetStringExtra("Machines");
            machines = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Machine>>(xml);
           
            AllMachinesAdapter adapter = new AllMachinesAdapter(this, machines);
            allMachinesView.Adapter = adapter;
            adapter.selectDone += Adapter_selectDone; 
            
        }
        //event
        private void Adapter_selectDone(object sender, MachineCheckEventArgs e)
        {
            Machine selected = machines.Where(m => m.Name == e.mName).SingleOrDefault();
            toAdd.Add(selected);

        }

        private void SelectMachines_Click(object sender, EventArgs e)
        {
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(toAdd);
            Intent intent = new Intent(this, typeof(selectMachines));
            intent.PutExtra("Machines", json);


            SetResult(Result.Ok,intent);
            Finish();
        }
    }
}