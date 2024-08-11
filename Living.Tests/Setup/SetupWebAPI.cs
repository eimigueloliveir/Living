﻿using Living.Tests.Setup.Factory;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Json;

namespace Living.Tests.Setup;

[CollectionDefinition("WebAPI")]
public record WebAPIFactoryCollection : ICollectionFixture<WebAPIFactory>;

[Collection("WebAPI")]
public partial class SetupWebAPI(WebAPIFactory webAPI)
{
    protected HttpClient Client => webAPI.HttpClient;
    protected T GetService<T>()
        where T : notnull
    {
        return webAPI.Services.GetRequiredService<T>();
    }


    protected async Task<T> PostAsync<T>(string path, object? body = null)
    {
        var response = await webAPI.HttpClient.PostAsJsonAsync(path, body);
        var data = await response.Content.ReadFromJsonAsync<T>();
        return data!;
    }

    protected async Task<T> GetAsync<T>(string path)
    {
        var response = await webAPI.HttpClient.GetAsync(path);
        //var json = await response.Content.ReadAsStringAsync();

        var data = await response.Content.ReadFromJsonAsync<T>();
        return data!;
    }
}