namespace BookShop.DataProcessor.ImportDto
{
    using Newtonsoft.Json;

    //this is internal DTO
    public class ImportAuthorBookDto
    {
        [JsonProperty("Id")]
        //with ? we make it nullable 
        public int? BookId { get; set; }
    }
}
