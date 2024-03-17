using Iqra_Quran_Center.Domain.Enums;

namespace Iqra_Quran_Center.Application.RRModels
{
    public record StudentFeeHistoryRequest(Guid StudentId,double TotalFeeSubmitted,PaymentMethod PaymentMethod,DateOnly Date);

    public class StudentFeeHistoryResponse
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public Guid GroupId { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; } = null!;
        public string GroupName { get; set; } = null!;
        public double TotalFeeSubmitted { get; set; }
        public double TotalFee { get; set; }
        public double Balance { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }

    public record StudentFeeHistoryFilterRequest
        (
        Guid? StudentId,
        Guid? GroupId,
        DateTime? Date
        );

    public record UpdateStudentFeeRequest
        (
        Guid Id,
        DateOnly Date,
        double TotalFeeSubmitted,
        PaymentMethod PaymentMethod
        );
}
