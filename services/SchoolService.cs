using System.Net.Http.Json;
using SchoolDirectoryApp.Models;

namespace SchoolDirectoryApp.Services;

public class SchoolService
{
    private readonly HttpClient _http;

    public SchoolService(HttpClient http)
    {
        _http = http;
    }

    /// <summary>
    /// Gets all schools from https://edutots.net/api/school.
    /// Throws HttpRequestException / JsonException on failure so the page can show an error state.
    /// </summary>
    public async Task<List<School>> GetSchoolsAsync()
    {
        // GetFromJsonAsync uses case-insensitive web defaults,
        // so "schoolName" in the JSON maps to SchoolName in C#.
        var result = await _http.GetFromJsonAsync<List<School>>("api/school");
        return result ?? new List<School>();
    }
}
