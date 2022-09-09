using System.Net;

namespace OpenWilma.Model;

public record ErrorResponse(WilmaError Error);

public record WilmaError(string Id, string Message, string Description, string WhatNext, HttpStatusCode StatusCode);
