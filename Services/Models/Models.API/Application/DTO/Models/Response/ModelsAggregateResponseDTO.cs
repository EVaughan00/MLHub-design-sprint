using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.Domain.Aggregates;

namespace Models.API.DTO {
    public class ModelsAggregateResponseDTO {

        public string name { get; set; }
        public string status { get; set; }
        public string visibility { get; set; }
        public string dateCreated { get; set; }
        public string classification { get; set; }

    }
}
