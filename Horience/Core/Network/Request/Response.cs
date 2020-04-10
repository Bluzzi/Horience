namespace Horience.Core.Network.Request
{
    class Response
    {
        private readonly string Reply;

        public Response(string Response)
        {
            this.Reply = Response;
        }

        public string[] ToArray()
        {
            string[] SeparatingStrings = { "/-/" };
            string[] Messages = Reply.Split(SeparatingStrings, System.StringSplitOptions.RemoveEmptyEntries);

            return Messages;
        }

        public string GetString()
        {
            return Reply;
        }
    }
}
