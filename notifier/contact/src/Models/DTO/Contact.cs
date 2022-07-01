namespace contacts.Models.DTO
{
    public struct Contact
    {
        public Guid? contactId { get; set; }
        public string contact { get; set; }
        public bool active { get; set; }

    }
}
