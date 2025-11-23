using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Back.Models.SecurityModels;
using Entity_Back;

namespace Business_Back.Interface.IBusinessModel.Services
{
    public interface ICitationNotificationService
    {
        Task SendCitationConfirmationAsync(Citation citation, CancellationToken ct);
    }

}
