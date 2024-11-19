using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain
{
    /*
     * Value Object her DDD yaklaşımında olmak zorunda değil!
     * 1. İki entity'i bir özellik üzerinden karşılaştırmanız gerekiyorsa (sıralama karşılaştırmayı gerektirir)
     * 2. Bu özellik kompleks bir tip ise 
     * 
     */
    public record ImageInfo
    {
        public string ImageUrl { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

    }
}
