﻿using Messenger.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Messenger.Services
{
    public class DataService
    {

        private static readonly DataService _dataService = new DataService();
        private readonly HttpClient _httpClient = new HttpClient
        {
                DefaultRequestHeaders = { IfModifiedSince = DateTimeOffset.Now}
        };

        private readonly string _baseUrl = "http://192.168.43.147:9000/";

        protected DataService () {

        }



        public static DataService GetInstance()
        {
            return _dataService;
        }
       
        public async Task<HttpStatusCode> LoginAsync(string userName, string password)
        {
            try{
                var json = new JObject { { "UserName", userName }, { "Password", password } }.ToString();
                return (await _httpClient.PostAsync(new Uri($"{_baseUrl}/auth/credentials "),
                new StringContent(json, Encoding.UTF8, "application/json"))).StatusCode;
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
                return HttpStatusCode.SeeOther;
            }
        }
        public async Task<List<ContactModel>>LoadContactsAsync()
        {
            try
            {
                var json = await _httpClient.GetStringAsync(new Uri($"{_baseUrl}/contacts.json"));
                var jObj = JObject.Parse(json);
                return JsonConvert.DeserializeObject<List<ContactModel>>(jObj["Contacts"].ToString());
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
                return new List<ContactModel>();
            }
        }
}
}
