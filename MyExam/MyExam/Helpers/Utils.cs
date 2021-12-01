using MyExam.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.GoogleMaps;

namespace MyExam.Helpers
{
    public static class Utils
    {
        /// <summary>
        /// Gets random calification.
        /// </summary>
        /// <returns>The calification.</returns>
        public static double GetCalification()
        {
            var rnd = new Random(Guid.NewGuid().GetHashCode());
            return Enumerable.Range(0, 10)
                .Select(s => rnd.Next(0, 5))
                .Average();
        }

        /// <summary>
        /// Gets the user position.
        /// </summary>
        /// <returns>The user position.</returns>
        /// <param name="location">Location.</param>
        public static async Task<string> GetUserPosition(Location location)
        {
            var geoCoder = new Geocoder();
            var approximateLocations = await geoCoder.GetPositionsForAddressAsync(location.Street + "," + location.City + "," + location.State);
            var firstPostion = approximateLocations.FirstOrDefault();
            return string.Format("{0},{1}", firstPostion.Latitude, firstPostion.Longitude);
        }

        /// <summary>
        /// Strings to position.
        /// </summary>
        /// <returns>The to position.</returns>
        /// <param name="stringPosition">String position.</param>
        public static Position StringToPosition(string stringPosition)
        {
            var arr = stringPosition.Split(',');
            var latLon = Array.ConvertAll(arr, double.Parse);
            return new Position(latLon.ElementAt(0), latLon.ElementAt(1));
        }

        /// <summary>
        /// Ugly workaround to separate objects from realm context
        /// </summary>
        /// <typeparam name="T">Object</typeparam>
        /// <param name="obj">Extension object</param>
        /// <returns></returns>
        public static List<T> SeparateFromRealm<T>(this List<T> obj) where T : Realms.RealmObject
        {
            return JsonConvert.DeserializeObject<List<T>>(JsonConvert.SerializeObject(obj));
        }
    }
}
