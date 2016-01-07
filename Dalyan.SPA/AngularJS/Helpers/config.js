var config = {
    apiurl: "http://localhost/Dalyan.WebApi/",
    weburl: "http://localhost/Dalyan.SPA/",

    generateApiUrl: function (serviceUrl) {
        return config.apiurl + serviceUrl;
    }
}