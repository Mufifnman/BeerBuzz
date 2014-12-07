using System;

namespace BeerBuzzBackend
{
    [Serializable]
    public class BuzzInfo
    {
        public string Name { get; set; }

        public string FilePath { get; set; }

        public string Contributor { get; set; }
    }
}