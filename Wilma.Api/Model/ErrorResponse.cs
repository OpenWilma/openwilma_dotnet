using System.Net;

namespace Wilma.Api.Model
{
    public class ErrorResponse
    {
        public WilmaError Error { get; set; }
    }

    public class WilmaError
    {
        public string Id { get; set; }
        public string Message { get; set; }
        public string Description { get; set; }
        public string WhatNext { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
