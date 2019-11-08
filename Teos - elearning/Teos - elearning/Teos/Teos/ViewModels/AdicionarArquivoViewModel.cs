using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Teos.ViewModels
{
    public class AdicionarArquivoViewModel
    {
        public IEnumerable<HttpPostedFileBase> httpPosteds { get; set; }
    }
}