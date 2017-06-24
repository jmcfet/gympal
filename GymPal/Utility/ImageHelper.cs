

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
using Android.Graphics;
using System.Net;
using Java.IO;
using System.Threading.Tasks;
using Android.Content.Res;

namespace GymPal.Utility
{
    public class ImageHelper
    {
        public static Bitmap GetImageBitmapFromUrl(string url)
        {
            Bitmap imageBitmap = null;

            using (var webClient = new WebClient())
            {
                var imageBytes = webClient.DownloadData(url);
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }
            }

            return imageBitmap;
        }

        public static Bitmap GetImageBitmapFromFilePath(string fileName, int width, int height)
        {
            // First we get the the dimensions of the file on disk
            BitmapFactory.Options options = new BitmapFactory.Options { InJustDecodeBounds = false };
            File imgFile = new File("IMG_1039.JPG");
            try
            {
                Bitmap test = BitmapFactory.DecodeFile("IMG_1039.JPG", options);
            }
            catch
            {

            }
            // Next we calculate the ratio that we need to resize the image by
            // in order to fit the requested dimensions.
            int outHeight = options.OutHeight;
            int outWidth = options.OutWidth;
            int inSampleSize = 1;

            if (outHeight > height || outWidth > width)
            {
                inSampleSize = outWidth > outHeight
                                   ? outHeight / height
                                   : outWidth / width;
            }

            // Now we will load the image and have BitmapFactory resize it for us.
            options.InSampleSize = inSampleSize;
            options.InJustDecodeBounds = false;
            Bitmap resizedBitmap = BitmapFactory.DecodeFile(fileName, options);
           
            return resizedBitmap;
        }
        public static BitmapFactory.Options GetBitmapOptionsOfImage(Android.Content.Res.Resources res, string imageName)
        {
            BitmapFactory.Options options = new BitmapFactory.Options
            {
                InJustDecodeBounds = true
            };
            //use reflection to get the resource id from resources
            int resourceId = (int)typeof(Resource.Drawable).GetField(imageName).GetValue(null);
            // The result will be null because InJustDecodeBounds == true.  
            Bitmap result = BitmapFactory.DecodeResource(res, resourceId, options);
            return options;

        }
        //If set to a value > 1, requests the decoder to subsample the original image, returning a smaller image to save memory.
        public static int CalculateInSampleSize(BitmapFactory.Options options, int reqWidth, int reqHeight)
        {
            float height = options.OutHeight;
            float width = options.OutWidth;
            double inSampleSize = 1D;
            if (height > reqHeight || width > reqWidth)

                inSampleSize *= 2;

            return (int)inSampleSize;
        }
        public async Task<Bitmap> LoadScaledDownBitmapForDisplayAsync(Resources res, BitmapFactory.Options options, int reqWidth, int reqHeight)
        {
            options.InSampleSize = CalculateInSampleSize(options, reqWidth, reqHeight);
            options.InJustDecodeBounds = false;
            return await BitmapFactory.DecodeResourceAsync(res, Resource.Drawable.IMG_1039, options);
        }

        public static Bitmap LoadScaledDownBitmapForDisplay(Resources res, BitmapFactory.Options options, int reqWidth, int reqHeight, string imageName)
        {
            options.InSampleSize = CalculateInSampleSize(options, reqWidth, reqHeight);
            options.InJustDecodeBounds = false;
            int resourceId = (int)typeof(Resource.Drawable).GetField(imageName).GetValue(null);
            return BitmapFactory.DecodeResource(res, resourceId, options);
        }
    }
}