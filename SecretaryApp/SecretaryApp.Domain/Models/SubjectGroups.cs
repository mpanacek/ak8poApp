namespace SecretaryApp.Domain.Models
{
    public class SubjectGroups : DomainObject
    {
        public Subject Subject { get; set; }
        public Group Group { get; set; }
    }
}
