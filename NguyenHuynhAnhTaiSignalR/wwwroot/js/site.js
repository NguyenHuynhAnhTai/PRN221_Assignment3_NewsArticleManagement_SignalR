// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

"use strict";

var connection = new signalR.HubConnectionBuilder()
    .withUrl("/Webhub")
    .build();
connection.on("ArticleModified", function (accountId) {
    var currentPath = window.location.pathname;
    var queryString = window.location.search;
    var reloadPaths = ["/News/ViewNews", "/NewsArticleManagement/Index"];

    // Check if the current path starts with any of the reload paths
    var shouldReload = reloadPaths.some(function (path) {
        return currentPath.startsWith(path);
    });

    if (shouldReload) {
        location.reload();
    }
});
connection.start().catch(function (err) {
    return console.error(err.toString());
});