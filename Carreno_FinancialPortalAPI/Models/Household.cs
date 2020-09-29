using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Carreno_FinancialPortalAPI.Models
{
    /// <summary>
    /// This class models a Household
    /// </summary>
    public class Household
    {

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The Identifier.
        /// </value>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the created.
        /// </summary>
        /// <value>
        /// The Created.
        /// </value>
        public DateTime Created { get; set; }
        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        /// <value>
        /// The Name.
        /// </value>
        public string Name { get; set; }
        /// <summary>
        /// GEts or sets the Greeting.
        /// </summary>
        /// <value>
        /// The Greeting.
        /// </value>
        public string Greeting { get; set; }



    }
}