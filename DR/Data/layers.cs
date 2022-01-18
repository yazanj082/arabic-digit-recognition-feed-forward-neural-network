using DR.shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace DR.Data
{
    public class layers
    {
        public static List<Layer> layer;
        public layers()
        {
            if (layer == null)
            {
                layer = new List<Layer>();
            }
        }
        public List<Layer> Get() {
            return layer;
        }
    }
}
