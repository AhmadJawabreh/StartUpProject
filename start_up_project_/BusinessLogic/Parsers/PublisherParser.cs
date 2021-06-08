using Entities;

namespace BusinessLogic.Parsers
{
    public class PublisherParser
    {
        public static Publisher Parser(Publisher OldPublisherData, Publisher NewPublisherData)
        {
            OldPublisherData.Name = NewPublisherData.Name;
            OldPublisherData.Phone = NewPublisherData.Phone;
            OldPublisherData.Email = NewPublisherData.Email;
            OldPublisherData.Address = NewPublisherData.Address;
            OldPublisherData.Books = NewPublisherData.Books;
            return OldPublisherData;
        }
    }
}
