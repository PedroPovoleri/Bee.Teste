
using System.Collections.Generic;
using Web.WebModel.ModelView;

namespace Web.WebModel.Response
{
    public class CustumersResponse
    {

        public CustumersResponse()
        {
            this.Custumers = new List<Custumer>();
        }

        public List<Custumer> Custumers { get; set; }

        public bool IsCrud { get; set; }

    }
}
