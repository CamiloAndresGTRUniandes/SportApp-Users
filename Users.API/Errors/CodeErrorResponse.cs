namespace Users.API.Errors
{
    public class CodeErrorResponse
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; } = string.Empty;

        public CodeErrorResponse(int statusCode, string message=null)
        {
            StatusCode = statusCode;
            Message = message??GetDefaultMessageCode(StatusCode);
        }


        private string GetDefaultMessageCode(int statusCode)
        {

            return statusCode switch
            {
                    400=>"El  request enviado tiene errores",
                    401=> "No tienes autorizacion",
                    404=>"No se encuentra el recurso solicitado",
                    500=>"Hay errores en el server",
                    _=> string.Empty

            };
        }

    }
}
