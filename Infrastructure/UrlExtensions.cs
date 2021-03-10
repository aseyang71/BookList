using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BookList.Infrastructure
{
    public static class UrlExtensions
    {/*
        if querystirng has value then return the requested path and querystr, otherwise, just return the path as */
        public static string PathAndQuery(this HttpRequest request) =>
        request.QueryString.HasValue ? $"{request.Path}{request.QueryString}" : request.Path.ToString();
    }
}
