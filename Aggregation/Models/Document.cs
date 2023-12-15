namespace Aggregation.Models
{
    public class Document
    {
        public Guid Id { get; set; }
        public string DocumentsTitle { get; set; } = string.Empty;
        public string DocumentsLink { get; set; } = string.Empty;
        public string DocumentsDetails { get; set; } = string.Empty;
        public Guid DocumentsTypesId { get; set; }
        public Guid PatientsId { get; set; }
        public Guid PatientCaseId { get; set; }
        public Guid InDepartmentId { get; set; }
    }
}
