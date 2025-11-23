using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Back.Models.Request;
using Entity_Back;

namespace Business_Back.Interface.IBusinessModel
{
    public interface IModificationRequestHandler
    {
        Task HandleAsync(ModificationRequest request);
        Task ReprogramAsync(Citation cita);
        Task CancelAsync(Citation cita);
    }
}
