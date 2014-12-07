using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace BeerBuzzBackend
{
    public class BuzzInfoStore
    {
        public const string RootDir = @"C:/BeerBuzz/";
        public string BuzzFileStoreDir = Path.Combine(RootDir, "BuzzFileStore");

        public Dictionary<string, BuzzInfo> BuzzInfos = new Dictionary<string, BuzzInfo>();

        private static BuzzInfoStore instance;
        public static BuzzInfoStore Instance 
        { 
            get 
            {
                if (instance == null)
                {
                    instance = new BuzzInfoStore();
                }

                return instance;
            }
        } 

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Load()
        {
            throw new NotImplementedException();
        }
    }
}