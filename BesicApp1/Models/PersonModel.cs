using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BesicApp1.Models
{
    public class PersonModel
    {
        ///<summary>
        /// Gets or sets Name.
        ///</summary>
        public string Name { get; set; }

        ///<summary>
        /// Gets or sets DateTime.
        ///</summary>
        public string DateTime { get; set; }
    }

    public class PersonModel2
    {
        ///<summary>
        /// Gets or sets FName.
        ///</summary>
        public string FName { get; set; }

        ///<summary>
        /// Gets or sets MName.
        ///</summary>
        public string MName { get; set; }

        ///<summary>
        /// Gets or sets LName.
        ///</summary>
        public string LName { get; set; }

        ///<summary>
        /// Gets or sets Age.
        ///</summary>
        public string Age { get; set; }
    }

    public class perCountry
    {
        public List<TBL_COUNTRY_MASTER> country { get; set; }
    }

    public class status
    {
        public string statusCode { get; set; }
        public string StatusMsg { get; set; }
    }
}