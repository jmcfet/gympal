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
    public class OnNameEventArgs : EventArgs
    {
        string mname;
     
        public string mName
        {
            get { return mname; }
            set { mname = value; }
        }
       
    }
    class GetNameDialog : DialogFragment
    {
        EditText txtEmail;
        Button btnOK;
        public event EventHandler<OnNameEventArgs> mOnsignupDone;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.GetName, container, false);
            txtEmail = view.FindViewById<EditText>(Resource.Id.RoutineName);
            btnOK = view.FindViewById<Button>(Resource.Id.Ok);
   //         btnSignup.Click += BtnSignup_Click;
            return base.OnCreateView(inflater, container, savedInstanceState);

        }
    }
}