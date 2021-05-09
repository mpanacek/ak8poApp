namespace SecretaryApp.Domain.Models
{
    public class SubjectGroups : DomainObject
    {
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}
