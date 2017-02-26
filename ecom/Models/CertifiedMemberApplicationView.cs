using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ecom.Models
{
    public class CertifiedMemberApplicationView
    {
        public ViewMember Company { get; set; }

        public string Status { get; set; }

        public EcomCert EcomCert { get; set; }

        /* Company Details */
        public EcomCert_CompDetail Company_Detail { get; set; }
        public IEnumerable<int> Products_Handled { get; set; }

        public EcomCert_Service Company_Service { get; set; }
        public IEnumerable<int> Services { get; set; }
        public IEnumerable<int> CrossBorderServices { get; set; }
        public IEnumerable<int> GroundServices { get; set; }
        public IEnumerable<int> TransportFleets { get; set; }
        public IEnumerable<int> PayOnDelivery { get; set; }
        public IEnumerable<int> InternalBounds { get; set; }


        public EcomCert_IT Company_IT { get; set; }

        public CertifiedMemberApplicationView()
        {
            this.Company = new ViewMember();
            this.EcomCert = new EcomCert();

            /* Company Details */
            this.Company_Detail = new EcomCert_CompDetail();
            this.Products_Handled = new List<int>();

            /* Company Services */
            this.Company_Service = new EcomCert_Service();
            this.Services = new List<int>();
            this.CrossBorderServices = new List<int>();
            this.GroundServices = new List<int>();
            this.TransportFleets = new List<int>();
            this.PayOnDelivery = new List<int>();
            this.InternalBounds = new List<int>();

            /* Company IT */
            this.Company_IT = new EcomCert_IT();
        }
    }
}