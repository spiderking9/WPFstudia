using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrlopyApiXaml.Models.Entities;

namespace UrlopyApiXaml.Models.BusinessLogic
{
    public class DatebaseClass
    {
        #region Fields
        protected UrlopyEntities urlopyApiXaml;
        #endregion Fields

        #region Constructor
        public DatebaseClass(UrlopyEntities urlopyApiXaml)
        {
            this.urlopyApiXaml = urlopyApiXaml;
        }
        #endregion Constructor
    }
}
