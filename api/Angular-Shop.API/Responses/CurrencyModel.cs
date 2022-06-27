namespace Angular_Shop.API.Responses
{
    public class CurrencyModel
    {
        public Response Response { get; set; }
    }

    public class Response
    {
        public string From { get; set; }
        public string To { get; set; }
        public double Amount { get; set; }
    }
}
