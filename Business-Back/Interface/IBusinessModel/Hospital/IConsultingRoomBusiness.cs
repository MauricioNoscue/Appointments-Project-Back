using Business_Back.Interface.BaseModelBusiness;
using Entity_Back;
using Entity_Back.Dto.HospitalDto.RelatedPerson;

namespace Business_Back
{
    public interface IConsultingRoomBusiness : IBaseModelBusiness<ConsultingRoomCreateDto, ConsultingRoomEditDto, ConsultingRoomListDto>
    {
    }
}

