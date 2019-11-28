using CdcSoftware.Pivotal.Engine;
using CdcSoftware.Pivotal.Engine.Types.DataTemplates;
using CdcSoftware.Pivotal.Engine.Types.ServerTasks;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIV.ContaminationTest.FormTasks
{
    public class ContaminationTest : DataTemplateServerTask
    {
        protected override Id AddData(DataTemplate dataTemplate, DataSet data, ParameterList parameters)
        {
            return Id.NewTemporaryId();
        }
    }
}
